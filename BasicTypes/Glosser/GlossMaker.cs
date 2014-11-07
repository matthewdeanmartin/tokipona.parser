﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.Extensions;
using BasicTypes.Globalization;

namespace BasicTypes.Glosser
{
    //Culture aware! TP = InvariantCulture.
    public class GlossMaker
    {
        public string Gloss(string normalized, string original, string language = "en", bool includePos = false)
        {
            Dialect config = Dialect.DialectFactory;
            config.ThrowOnSyntaxError = false;
            config.TargetGloss = "en";
            ParserUtils pu = new ParserUtils(config);

            List<string> gloss = new List<string>();
            Sentence sentenceTree = pu.ParsedSentenceFactory(normalized, original);

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

            if (s.LaFragment != null && s.LaFragment.Count > 0)
            {
                foreach (Chain bit in s.LaFragment )
                {
                    ProcessOneChain(includePos, gloss, config, bit);
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

        private void ProcessPredicates(bool includePos, Sentence s, List<string> gloss, Dialect config)
        {
            int j = 0;
            foreach (TpPredicate predicate in s.Predicates)
            {
                j++;
                if (j == 1)
                {
                    gloss.Add("is");
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

                            foreach (Word modifier in predicate.VerbPhrase.Adverbs)
                            {
                                gloss.Add(modifier.ToString(PartOfSpeech.Adjective + ":" + includePos, config));
                            }

                            if (predicate.VerbPhrase.HeadVerb.ToString(PartOfSpeech.Noun, config).Contains("Error"))
                            {
                                //Oh, this might be an adjective. jan li laso.
                                gloss.Add(predicate.VerbPhrase.HeadVerb.ToString(PartOfSpeech.Adjective + ":" + includePos, config));
                            }
                            else
                            {
                                gloss.Add(predicate.VerbPhrase.HeadVerb.ToString(PartOfSpeech.Noun + ":" + includePos, config));
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
                                    gloss.Add(modal.ToString(PartOfSpeech.VerbIntransitive + ":" + includePos, config));
                                }
                            }

                            if (predicate.VerbPhrase.Adverbs != null)
                            {
                                foreach (Word modifier in predicate.VerbPhrase.Adverbs)
                                {
                                    string maybeAdverb = modifier.ToString(PartOfSpeech.Adverb + ":" + includePos, config);
                                    if (maybeAdverb.Contains("Error"))
                                    {
                                        //jan Sonja dictionary treats Adv & Adj the same.
                                        maybeAdverb = modifier.ToString(PartOfSpeech.Adjective + ":" + includePos, config);
                                    }
                                    gloss.Add(maybeAdverb);
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
                                foreach (Word modifier in hp.Modifiers)
                                {
                                    PartOfSpeech pos = PartOfSpeech.Adjective;
                                    string adjectiveWithFallBack =
                                        GlossWithFallBack(includePos, config, modifier, pos);
                                    gloss.Add(adjectiveWithFallBack);
                                }

                                gloss.Add(hp.Head.ToString(PartOfSpeech.Noun + ":" + includePos, config));
                            }
                        }
                    }
                }

                if (predicate.Prepositionals != null)
                {
                    if (predicate.Prepositionals.SubChains != null)
                    {
                        foreach (Chain sub in predicate.Prepositionals.SubChains)
                        {
                            gloss.Add(sub.Particle.ToString(PartOfSpeech.Preposition, config));

                            ProcessChain(gloss, sub, includePos, config);
                        }
                    }
                    //leaf?
                }
            }
        }

        private static string GlossWithFallBack(bool includePos, Dialect config, Word modifier, PartOfSpeech pos)
        {
            return modifier.ToString(pos+ ":" + includePos, config);
        }

        private static void ProcessSubjects(bool includePos, Sentence s, List<string> gloss, Dialect config)
        {
            foreach (Chain c in s.Subjects)
            {
                if (c == null)
                {
                    //Imperatives have implicit subjects.
                    continue;
                }
                ProcessOneChain(includePos, gloss, config, c);
            }
        }

        private static void ProcessOneChain(bool includePos, List<string> gloss, Dialect config, Chain c)
        {
            //Odd chain if the subchains and headedphrase are missing.

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

                    int k = 0;
                    if (sub.SubChains != null)
                    {
                        foreach (Chain subsub in sub.SubChains)
                        {
                            k++;
                            if (k != 1)
                            {
                                gloss.Add(subsub.Particle.ToString(PartOfSpeech.Conjunction + ":" + includePos, config));
                            }

                            //deeper levels?
                            ProcessSimpleHeadedPhrase(includePos, gloss, config, subsub.HeadedPhrases);
                        }
                    }
                    else
                    {
                        ProcessSimpleHeadedPhrase(includePos, gloss, config, sub.HeadedPhrases);
                        //deeper levels?
                        //foreach (HeadedPhrase hp in sub.HeadedPhrases)
                        //{
                        //    foreach (Word modifier in hp.Modifiers)
                        //    {
                        //        gloss.Add(modifier.ToString(PartOfSpeech.Adjective + ":" + includePos, config));
                        //    }

                        //    gloss.Add(hp.Head.ToString(PartOfSpeech.Noun + ":" + includePos, config));
                        //}
                    }
                }
            }

            if (c.HeadedPhrases != null)
            {
                ProcessSimpleHeadedPhrase(includePos, gloss, config, c.HeadedPhrases);
                //foreach (HeadedPhrase hp in c.HeadedPhrases)
                //{
                //    foreach (Word modifier in hp.Modifiers)
                //    {
                //        gloss.Add(modifier.ToString(PartOfSpeech.Adjective + ":" + includePos, config));
                //    }
                //
                //    gloss.Add(hp.Head.ToString(PartOfSpeech.Noun + ":" + includePos, config));
                //}
            }
        }

        private static void ProcessSimpleHeadedPhrase(bool includePos, List<string> gloss, Dialect config, HeadedPhrase[] phrases)
        {
            //BUG: Forgot to deal with particles!

            foreach (HeadedPhrase hp in phrases)
            {
                ProcessingleHeadedPhrase(includePos, gloss, config, hp);
            }
        }

        private static void ProcessingleHeadedPhrase(bool includePos, List<string> gloss, Dialect config, HeadedPhrase hp)
        {
            bool shouldSupressJan = WordByValue.Instance.Equals(hp.Head, Words.jan) && hp.Modifiers.Any(x => x.IsProperModifier);

            foreach (Word modifier in hp.Modifiers)
            {
                gloss.Add(modifier.ToString(PartOfSpeech.Adjective + ":" + includePos, config));
            }
            if (shouldSupressJan)
            {
                //skip!
            }
            else
            {
                gloss.Add(hp.Head.ToString(PartOfSpeech.Noun + ":" + includePos, config));
            }
        }

        private void ProcessChain(List<string> gloss, Chain sub, bool includePos, IFormatProvider formatProvider)
        {
            //deeper levels?
            if (sub.HeadedPhrases != null && sub.HeadedPhrases.Length > 0)
            {
                //Leaf
                foreach (HeadedPhrase hp in sub.HeadedPhrases)
                {
                    gloss.Add(hp.Head.ToString(PartOfSpeech.Noun + ":" + includePos, formatProvider));

                    foreach (Word modifier in hp.Modifiers)
                    {
                        gloss.Add(modifier.ToString(PartOfSpeech.Adjective + ":" + includePos, formatProvider));
                    }
                }
            }
            else
            {
                foreach (Chain subChain in sub.SubChains)
                {
                    gloss.Add(subChain.Particle.ToString(PartOfSpeech.Adjective + ":" + includePos, formatProvider));

                    ProcessChain(gloss, subChain, includePos, formatProvider);
                }
            }

        }

        public bool ThrowOnSyntaxErrors { get; set; }
    }
}
