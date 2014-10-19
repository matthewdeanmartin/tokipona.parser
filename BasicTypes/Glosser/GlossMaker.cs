using System;
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
        public string Gloss(string sentence, string language = "en", bool includePos =false)
        {
            Config config = Config.DialectFactory;
            config.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(config);

            using (new UseCulture(new CultureInfo("en-US")))
            {
                List<string> gloss = new List<string>();
                Sentence s = pu.ParsedSentenceFactory(sentence);

                Console.WriteLine(sentence);
                Console.WriteLine(s.ToString("g"));
                Console.WriteLine(s.ToString("b")); 

                foreach (Chain c in s.Subjects)
                {
                    int i = 0;
                    foreach (Chain sub in c.SubChains)
                    {
                        i++;
                        if (i != 1)
                        {
                            gloss.Add(sub.Particle.ToString(PartOfSpeech.Conjunction + ":" + includePos));
                        }
                        //deeper levels?
                        foreach (HeadedPhrase hp in sub.HeadedPhrases)
                        {
                            foreach (Word modifier in hp.Modifiers)
                            {
                                gloss.Add(modifier.ToString(PartOfSpeech.Adjective + ":" + includePos));
                            }

                            gloss.Add(hp.Head.ToString(PartOfSpeech.Noun + ":" + includePos));
                        }
                    }

                    if (c.HeadedPhrases != null)
                    {
                        foreach (HeadedPhrase hp in c.HeadedPhrases)
                        {
                            foreach (Word modifier in hp.Modifiers)
                            {
                                gloss.Add(modifier.ToString(PartOfSpeech.Adjective + ":" + includePos));
                            }

                            gloss.Add(hp.Head.ToString(PartOfSpeech.Noun + ":" + includePos));
                        }
                    }
                }

                int j = 0;
                foreach (TpPredicate predicate in s.Predicates)
                {
                    j++;
                    if (j == 1)
                    {
                        gloss.Add("is/does");
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

                    if (predicate.VerbPhrases.Head.ToString(verb).Contains("Error"))
                    {
                        foreach (Word modifier in predicate.VerbPhrases.Modifiers)
                        {
                            gloss.Add(modifier.ToString(PartOfSpeech.Adjective + ":" + includePos));
                        }

                        //Can't gloss as verb, assume we have a noun phrase
                        if (predicate.VerbPhrases.Head.ToString(PartOfSpeech.Noun).Contains("Error"))
                        {
                            //Oh, this might be an adjective. jan li laso.
                            gloss.Add(predicate.VerbPhrases.Head.ToString(PartOfSpeech.Adjective + ":" + includePos));
                        }
                        else
                        {
                            gloss.Add(predicate.VerbPhrases.Head.ToString(PartOfSpeech.Noun + ":" + includePos));
                        }
                    }
                    else
                    {
                        foreach (Word modifier in predicate.VerbPhrases.Modifiers)
                        {
                            string maybeAdverb = modifier.ToString(PartOfSpeech.Adverb + ":" + includePos);
                            if (maybeAdverb.Contains("Error"))
                            {
                                //jan Sonja dictionary treats Adv & Adj the same.
                                maybeAdverb = modifier.ToString(PartOfSpeech.Adjective + ":" + includePos);
                            }
                            gloss.Add(maybeAdverb);
                        }

                        gloss.Add(predicate.VerbPhrases.Head.ToString(verb));
                    }

                    if (predicate.Directs != null)
                    {
                        if (predicate.Directs.SubChains != null)
                        {
                            foreach (Chain sub in predicate.Directs.SubChains)
                            {
                                //deeper levels?
                                foreach (HeadedPhrase hp in sub.HeadedPhrases)
                                {
                                    foreach (Word modifier in hp.Modifiers)
                                    {
                                        gloss.Add(modifier.ToString(PartOfSpeech.Adjective + ":" + includePos));
                                    }

                                    gloss.Add(hp.Head.ToString(PartOfSpeech.Noun + ":" + includePos));   
                                }

                                gloss.Add("and");
                            }
                        }

                    }

                    if (predicate.Prepositionals != null)
                    {
                        if (predicate.Prepositionals.SubChains != null)
                        {
                            foreach (Chain sub in predicate.Prepositionals.SubChains)
                            {
                                gloss.Add(sub.Particle.ToString(PartOfSpeech.Preposition));

                                ProcessChain(gloss, sub, includePos);
                                
                            }
                        }
                        //leaf?
                    }
                }

                return gloss.SpaceJoin("g");
            }
        }

        private void ProcessChain(List<string> gloss, Chain sub, bool includePos)
        {
            //deeper levels?
            if (sub.HeadedPhrases != null && sub.HeadedPhrases.Length > 0)
            {
                //Leaf
                foreach (HeadedPhrase hp in sub.HeadedPhrases)
                {
                    gloss.Add(hp.Head.ToString(PartOfSpeech.Noun + ":" + includePos));

                    foreach (Word modifier in hp.Modifiers)
                    {
                        gloss.Add(modifier.ToString(PartOfSpeech.Adjective + ":" + includePos));
                    }
                }
            }
            else
            {
                
                foreach (Chain subChain in sub.SubChains)
                {
                    gloss.Add(subChain.Particle.ToString(PartOfSpeech.Adjective + ":" + includePos));    

                    ProcessChain(gloss,subChain,includePos);
                }
            }

        }

        public bool ThrowOnSyntaxErrors{ get; set; }
    }
}
