using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.Dictionary;
using BasicTypes.Extensions;
using BasicTypes.Globalization;
using BasicTypes.Parts;
using Humanizer;
using Microsoft.SqlServer.Server;

namespace BasicTypes.Glosser
{
    //Culture aware! TP = InvariantCulture.
    public class GlossMaker
    {
        public string Gloss(string normalized, string original, Dialect dialect)
        {
            dialect.ThrowOnSyntaxError = false;
            dialect.TargetGloss = "en";
            dialect.GlossWithFallBacks = true;
            ParserUtils pu = new ParserUtils(dialect);

            Sentence sentenceTree = pu.ParsedSentenceFactory(normalized, original);

            return GlossOneSentence(false, sentenceTree, dialect);
        }

        public string Gloss(string normalized, string original, string language = "en", bool includePos = false)
        {
            Dialect config = Dialect.DialectFactory;
            config.ThrowOnSyntaxError = false;
            config.TargetGloss = language;
            config.GlossWithFallBacks = true;
            ParserUtils pu = new ParserUtils(config);

            Sentence sentenceTree = pu.ParsedSentenceFactory(normalized, original);

            return GlossOneSentence(includePos, sentenceTree, config);
        }

        public string GlossOneSentence(bool includePos, Sentence sentenceTree, Dialect config)
        {
            List<string> gloss = new List<string>();

            if (sentenceTree.Preconditions != null)
            {
                //At such time as...
                //If

                foreach (Sentence condition in sentenceTree.Preconditions)
                {
                    gloss.Add("if");
                    //Conditions have head sentences, but not conclusions
                    ProcessSimpleSentence(includePos, condition, gloss, config);
                }
                //Then
                gloss.Add(", then");


                ProcessSimpleSentence(includePos, sentenceTree.Conclusion, gloss, config);
            }
            else
            {
                //Does this work for vocatives? Fragments?
                ProcessSimpleSentence(includePos, sentenceTree, gloss, config);
            }

            //HACK:
            string result = gloss.SpaceJoin("g");
            if (result.Contains("and of of"))
            {
                result = result.Replace("and of of", "");
            }

            return result;
        }

        private void ProcessSimpleSentence(bool includePos, Sentence s, List<string> gloss, Dialect config)
        {
            if (s.Vocative != null)
            {
                //TODO: extend to many vocatives?
                ProcessOneChain(includePos, gloss, config, s.Vocative.Nominal);
                //Need o?
            }

            //The whole sentence is a fragment, ending in la.
            if (s.Fragment != null)
            {
                //Simpler to treat fragments as degenerate, independent things.
                ProcessOneChain(includePos, gloss, config, s.Fragment.Nominal);
                //Need ...?
            }

            //mabye lots of fragents, all attached to the sentence.
            if (s.LaFragment != null && s.LaFragment.Count > 0)
            {
                foreach (Fragment bit in s.LaFragment)
                {
                    
                    if (bit.Nominal != null)
                    {
                        string ordinaryTp = bit.ToString("g").Replace(" ", "-");
                        if (!ordinaryTp.EndCheck("la"))
                        {
                            ordinaryTp = ordinaryTp + "-la";
                        }
                        CompoundWord cw = new CompoundWord(ordinaryTp);
                        string attempt = cw.TryGloss("en", "noun");
                        if (!attempt.StartCheck("["))
                        {
                            gloss.Add(attempt);
                        }
                        else
                        {
                            ProcessOneChain(includePos, gloss, config, bit.Nominal);
                        }
                    }
                    else
                    {
                        string ordinaryTp = bit.ToString("g").Replace(" ", "-");
                        if (!ordinaryTp.EndCheck("la"))
                        {
                            ordinaryTp = ordinaryTp + "-la";
                        }
                        CompoundWord cw = new CompoundWord(ordinaryTp);
                        string attempt = cw.TryGloss("en", "noun");
                        if (!attempt.StartCheck("["))
                        {
                            gloss.Add(attempt);
                        }
                        else
                        {
                            foreach (PrepositionalPhrase phrase in bit.Prepositionals)
                            {
                                ProcessPrepositionalPhrase(gloss, phrase, includePos, config);    
                            }
                        }

                    }

                    

                }
            }

            //Although if you have predicates, you should always have subjects.
            if (s.Subjects != null)
            {
                ProcessSubjects(includePos, s, gloss, config);
            }

            if (s.Predicates != null)
            {
                ProcessPredicates(includePos, s, gloss, config);
            }

        }

        public void ProcessPredicates(bool includePos, Sentence s, List<string> gloss, Dialect config)
        {

            int j = 0;
            foreach (TpPredicate predicate in s.Predicates)
            {
                bool isImperative = predicate.Particle == Particles.o;

                j++;
                if (j == 1)
                {
                    if (isImperative)
                    {
                        gloss.Add("please, you must");
                    }
                    else
                    {
                        gloss.Add("is");
                    }

                }
                else if (j != 1)
                {
                    gloss.Add("and");
                }

                string verb = PartOfSpeech.VerbIntransitive;

                if (predicate.Directs != null)
                {
                    verb = PartOfSpeech.VerbTransitive;
                }

                if (predicate.VerbPhrase != null) //This is possible
                {
                    if (predicate.VerbPhrase.NounComplement != null)
                    {
                        if (verb == PartOfSpeech.VerbTransitive)
                        {
                            gloss.Add("transforms into ");
                            ProcessOneChain(includePos, gloss, config, predicate.VerbPhrase.NounComplement);
                            gloss.Add(", these targets: ");
                        }
                        else
                        {
                            ProcessOneChain(includePos, gloss, config, predicate.VerbPhrase.NounComplement);
                        }
                    }
                    else
                    {
                        //Try to guess if this is a verb or something else.
                        if (predicate.VerbPhrase.HeadVerb.ToString(verb, config).Contains("Error")
                            && (predicate.VerbPhrase.Modals == null || predicate.VerbPhrase.Modals.Count == 0))
                        {
                            //No modals, Can't gloss as verb, assume we have a noun phrase

                            if (predicate.VerbPhrase.Adverbs != null)
                            {
                                foreach (Word modifier in predicate.VerbPhrase.Adverbs)
                                {
                                    gloss.Add(GlossWithFallBack(includePos, config, modifier, PartOfSpeech.Adjective));
                                }
                            }

                            if (predicate.VerbPhrase.HeadVerb.ToString(PartOfSpeech.Noun, config).Contains("Error"))
                            {
                                //Oh, this might be an adjective. jan li laso.
                                //gloss.Add(predicate.VerbPhrase.HeadVerb.ToString(PartOfSpeech.Adjective + ":" + includePos, config));
                                gloss.Add(GlossWithFallBack(includePos, config, predicate.VerbPhrase.HeadVerb, PartOfSpeech.Adjective));
                            }
                            else
                            {
                                //gloss.Add(predicate.VerbPhrase.HeadVerb.ToString(PartOfSpeech.Noun + ":" + includePos, config));
                                gloss.Add(GlossWithFallBack(includePos, config, predicate.VerbPhrase.HeadVerb, PartOfSpeech.Noun));
                            }
                        }
                        else
                        {
                            // I can really eat.
                            // I can eat quickly. (uh-oh!)
                            if (predicate.VerbPhrase.Modals != null)
                            {
                                foreach (Word modal in predicate.VerbPhrase.Modals)
                                {
                                    //HACK: What no separate POS For modal verbs?
                                    //modal.ToString(PartOfSpeech.VerbIntransitive + ":" + includePos, config)
                                    gloss.Add(GlossWithFallBack(includePos, config, modal, PartOfSpeech.VerbIntransitive));
                                }
                            }

                            if (predicate.VerbPhrase.Adverbs != null)
                            {
                                foreach (Word modifier in predicate.VerbPhrase.Adverbs)
                                {
                                    gloss.Add(GlossWithFallBack(includePos, config, modifier, PartOfSpeech.Adverb));
                                }
                            }

                            gloss.Add(predicate.VerbPhrase.HeadVerb.ToString(verb, config));
                        }

                    }

                }


                int directCount = 0;
                if (predicate.Directs != null)
                {
                    if (predicate.Directs.SubChains != null)
                    {
                        foreach (Chain sub in predicate.Directs.SubChains)
                        {
                            if (directCount > 0)
                            {
                                gloss.Add("and");
                            }
                            directCount++;

                            //deeper levels?
                            foreach (HeadedPhrase hp in sub.HeadedPhrases)
                            {
                                ProcessingleHeadedPhrase(includePos, gloss, config, hp);
                                //foreach (Word modifier in hp.Modifiers)
                                //{
                                //    gloss.Add(GlossWithFallBack(includePos, config, modifier, PartOfSpeech.Adjective));
                                //}
                                //
                                //gloss.Add(GlossWithFallBack(includePos, config, hp.Head, PartOfSpeech.Noun));
                            }
                        }
                    }
                }

                if (predicate.Prepositionals != null)
                {
                        foreach (PrepositionalPhrase sub in predicate.Prepositionals)
                        {
                            //gloss.Add(sub.Preposition.ToString(PartOfSpeech.Preposition, config));
                            ProcessPrepositionalPhrase(gloss, sub, includePos, config);
                        }   
                    //leaf?
                }
            }
        }

        public static string GlossWithFallBack(bool includePos, IFormatProvider config, Word word, PartOfSpeech pos)
        {
            string firstAttempt = word.ToString(pos + ":" + includePos, config);

            //Don't want fall backs or it was fine.
            if (!(config as Dialect).GlossWithFallBacks || !firstAttempt.StartCheck("[Error"))
            {
                return firstAttempt;
            }

            if (pos.Value == PartOfSpeech.Adjective)
            {
                foreach (PartOfSpeech alt in new PartOfSpeech[] { PartOfSpeech.Noun, PartOfSpeech.VerbIntransitive, PartOfSpeech.VerbTransitive, PartOfSpeech.Adverb })
                {
                    string tryAgain = word.ToString(alt + ":" + includePos, config);

                    //Don't want fall backs or it was fine.
                    if (!tryAgain.StartCheck("[Error"))
                    {
                        return tryAgain;
                    }
                }
            }
            else if (pos.Value == PartOfSpeech.VerbIntransitive)
            {
                foreach (PartOfSpeech alt in new PartOfSpeech[] { PartOfSpeech.VerbIntransitive, PartOfSpeech.VerbTransitive, PartOfSpeech.Noun, PartOfSpeech.Adverb, PartOfSpeech.Adjective })
                {
                    string tryAgain = word.ToString(alt + ":" + includePos, config);

                    //Don't want fall backs or it was fine.
                    if (!tryAgain.StartCheck("[Error"))
                    {
                        return tryAgain;
                    }
                }
            }
            else if (pos.Value == PartOfSpeech.VerbIntransitive)
            {
                foreach (PartOfSpeech alt in new[] { PartOfSpeech.VerbTransitive, PartOfSpeech.Noun, PartOfSpeech.Adverb, PartOfSpeech.Adjective })
                {
                    string tryAgain = word.ToString(alt + ":" + includePos, config);

                    //Don't want fall backs or it was fine.
                    if (!tryAgain.StartCheck("[Error"))
                    {
                        return tryAgain;
                    }
                }
            }
            else if (pos.Value == PartOfSpeech.VerbTransitive)
            {
                foreach (PartOfSpeech alt in new[] { PartOfSpeech.VerbIntransitive, PartOfSpeech.Noun, PartOfSpeech.Adverb, PartOfSpeech.Adjective })
                {
                    string tryAgain = word.ToString(alt + ":" + includePos, config);

                    //Don't want fall backs or it was fine.
                    if (!tryAgain.StartCheck("[Error"))
                    {
                        return tryAgain;
                    }
                }
            }
            else if (pos.Value == PartOfSpeech.Noun)
            {
                foreach (PartOfSpeech alt in new[] { PartOfSpeech.Adverb, PartOfSpeech.Adjective, PartOfSpeech.VerbIntransitive, PartOfSpeech.VerbTransitive })
                {
                    string tryAgain = word.ToString(alt + ":" + includePos, config);

                    //Don't want fall backs or it was fine.
                    if (!tryAgain.StartCheck("[Error"))
                    {
                        return tryAgain;
                    }
                }
            }

            //Try anything!
            foreach (PartOfSpeech alt in new PartOfSpeech[]
            {
                PartOfSpeech.Kama, PartOfSpeech.Conjunction, PartOfSpeech.Pronoun, PartOfSpeech.Preposition, PartOfSpeech.Interjection, PartOfSpeech.Conditional, PartOfSpeech.Adverb,
                PartOfSpeech.Noun, PartOfSpeech.Adjective,PartOfSpeech.VerbIntransitive, PartOfSpeech.VerbTransitive
            })
            {
                string finalTryAgain = word.ToString(alt + ":" + includePos, config);

                //Don't want fall backs or it was fine.
                if (!finalTryAgain.StartCheck("[Error"))
                {
                    return finalTryAgain;
                }
            }

            return firstAttempt;
        }

        private static void ProcessSubjects(bool includePos, Sentence s, List<string> gloss, Dialect config)
        {
            ComplexChain c = s.Subjects;
            if (c == null)
            {
                //Imperatives have implicit subjects.
                return;
            }
            ProcessOneChain(includePos, gloss, config, c);
        }

        private static void ProcessOneChain(bool includePos, List<string> gloss, Dialect config, ComplexChain c, bool surpressFirstPreposition=false)
        {
            //Recurse
            if (c.ComplexChains != null)
            {
                int k = 0;
                foreach (var innerComplexChain in c.ComplexChains)
                {
                    k++;
                    if (k != 1)
                    {
                        gloss.Add(innerComplexChain.Particle.ToString(PartOfSpeech.Conjunction + ":" + includePos, config));
                    }
                    ProcessOneChain(includePos, gloss, config, innerComplexChain);
                }
            }

            //Almost to a leaf
            int i = 0;
            if (c.SubChains != null)
            {
                foreach (Chain sub in c.SubChains)
                {
                    i++;
                    if (i != 1)
                    {
                        gloss.Add(sub.Particle.ToString(PartOfSpeech.Conjunction + ":" + includePos, config));
                    }

                    foreach (HeadedPhrase hp in sub.HeadedPhrases)
                    {
                        ProcessingleHeadedPhrase(includePos, gloss, config, hp);
                    }
                }
            }
        }


        private static void ProcessingleHeadedPhrase(bool includePos, List<string> gloss, Dialect config, HeadedPhrase hp)
        {
            bool shouldSupressJan = WordByValue.Instance.Equals(hp.Head, Words.jan) && hp.Modifiers.Any(x => x.IsProperModifier);

            foreach (Word modifier in hp.Modifiers)
            {
                
                gloss.Add(GlossWithFallBack(includePos, config, modifier, PartOfSpeech.Adjective));
            }
            if (shouldSupressJan)
            {
                //skip!
            }
            else
            {
                string nounPossiblePlural = GlossWithFallBack(includePos, config, hp.Head, PartOfSpeech.Noun);

                if ((!new String[]{"I","we","he","she","it","they"}.Contains(nounPossiblePlural)) && hp.IsPlural())
                {
                    nounPossiblePlural= nounPossiblePlural.Pluralize();
                }
                gloss.Add(nounPossiblePlural);
            }
        }

        private void ProcessPrepositionalPhrase(List<string> gloss, PrepositionalPhrase sub, bool includePos, Dialect formatProvider)
        {
            //HACK: I think the parser is wrapping a whole Perp phrase in a complex chain with just one Prep. Maybe that is correct & leave open option of treating chains of preps as a chains.
            gloss.Add(GlossWithFallBack(includePos, formatProvider, sub.Preposition, PartOfSpeech.Preposition));

            ProcessOneChain(includePos, gloss, formatProvider, sub.Complement);

        }

        private void ProcessChain(List<string> gloss, Chain sub, bool includePos, Dialect formatProvider)
        {
            throw new NotImplementedException();
            ////deeper levels?
            //if (sub.HeadedPhrases != null && sub.HeadedPhrases.Length > 0)
            //{
            //    //Leaf
            //    foreach (HeadedPhrase hp in sub.HeadedPhrases)
            //    {
            //
            //        gloss.Add(GlossWithFallBack(includePos, formatProvider, hp.Head, PartOfSpeech.Noun));// hp.Head.ToString(PartOfSpeech.Noun + ":" + includePos, formatProvider));
            //
            //        foreach (Word modifier in hp.Modifiers)
            //        {
            //            gloss.Add(GlossWithFallBack(includePos, formatProvider, modifier, PartOfSpeech.Adjective));
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (Chain subChain in sub.SubChains)
            //    {
            //        gloss.Add(subChain.Particle.ToString(PartOfSpeech.Adjective + ":" + includePos, formatProvider));
            //
            //        ProcessChain(gloss, subChain, includePos, formatProvider);
            //    }
            //}
        }

        public bool ThrowOnSyntaxErrors { get; set; }
    }
}
