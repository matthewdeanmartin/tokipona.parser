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
        public string Gloss(string sentence, string language = "en")
        {
            using (new UseCulture(new CultureInfo("en-US")))
            {
                List<string> gloss = new List<string>();
                Sentence s = ParserUtils.ParsedSentenceFactory(sentence);

                foreach (Chain c in s.Subjects)
                {
                    int i = 0;
                    foreach (Chain sub in c.SubChains)
                    {
                        i++;
                        if (i != 1)
                        {
                            gloss.Add(sub.Particle.ToString("conj"));
                        }
                        //deeper levels?
                        foreach (HeadedPhrase hp in sub.HeadedPhrases)
                        {
                            gloss.Add(hp.Head.ToString("n"));

                            foreach (Word modifier in hp.Modifiers)
                            {
                                gloss.Add(modifier.ToString("adj"));
                            }
                        }
                    }

                    if (c.HeadedPhrases != null)
                    {
                        foreach (HeadedPhrase hp in c.HeadedPhrases)
                        {
                            gloss.Add(hp.Head.ToString("n"));

                            foreach (Word modifier in hp.Modifiers)
                            {
                                gloss.Add(modifier.ToString("adj"));
                            }
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

                    string verb = "vi";
                    if (predicate.Directs != null)
                    {
                        verb = "vt";
                    }
                    gloss.Add(predicate.VerbPhrases.Head.ToString(verb));

                    foreach (Word modifier in predicate.VerbPhrases.Modifiers)
                    {
                        gloss.Add(modifier.ToString("adv"));
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
                                    gloss.Add(hp.Head.ToString("n"));

                                    foreach (Word modifier in hp.Modifiers)
                                    {
                                        gloss.Add(modifier.ToString("adj"));
                                    }
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
                                gloss.Add("PREP GOES HERE");

                                //deeper levels?
                                foreach (HeadedPhrase hp in sub.HeadedPhrases)
                                {
                                    gloss.Add(hp.Head.ToString("n"));

                                    foreach (Word modifier in hp.Modifiers)
                                    {
                                        gloss.Add(modifier.ToString("adj"));
                                    }
                                }
                            }
                        }
                        //leaf?
                    }
                }

                return gloss.SpaceJoin("g");
            }
        }
    }
}
