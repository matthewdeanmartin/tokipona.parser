using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BasicTypes.Extensions;

namespace BasicTypes.NormalizerCode
{
    //A Whole class dedicated to putting li back after mi/sina
    public class NormalizeMiSina
    {
        private static string[] pronounModifiers = new string[]
            {
                "mi wan",
                "mi tu",
                "mi mute",
                "mi suli",

                "sina wan",
                "sina tu",
                "sina mute",
                "sina suli",

                "mi en sina",
            };


        private static string ProcessMi(string normalized)
        {
            normalized = NormalizedMiLi(normalized);
            normalized = NormalizedMiLi(normalized, "'");
            normalized = NormalizedMiLi(normalized, "«");
            normalized = NormalizedMiLi(normalized, "' ");
            normalized = NormalizedMiLi(normalized, "« ");
            normalized = NormalizedMiLi(normalized, "taso "); //conjunctions behave like leading punct
            normalized = NormalizedMiLi(normalized, "anu "); //conjunctions behave like leading punct
            normalized = NormalizedMiLi(normalized, "taso, "); //conjunctions behave like leading punct
            normalized = NormalizedMiLi(normalized, "anu, "); //conjunctions behave like leading punct


            foreach (Word possible in Words.Dictionary.Values)
            {
                //Need a new concept-- ordinary POS & fallback POS
                string pronoun = "mi";
                Dictionary<string, Dictionary<string, string[]>> glosses;
                if (Words.Glosses.TryGetValue(possible.Text, out glosses))
                {
                    Dictionary<string, string[]> enGlosses;
                    if (glosses.TryGetValue("en", out enGlosses))
                    {
                        if ((enGlosses.ContainsKey("vt") && enGlosses["vt"].Length > 0)
                            ||
                            (enGlosses.ContainsKey("vi") && enGlosses["vi"].Length > 0))
                        {
                            string unLied = " " + pronoun + " " + possible + " ";
                            if (normalized.ContainsCheck(unLied) && !pronounModifiers.Contains(unLied.Trim()))
                            {
                                normalized = normalized.Replace(unLied, " " + pronoun + " li " + possible + " ");
                            }
                        }
                    }
                }
            }
            return normalized;
        }

        public static string ProcessMiSinaOvernormalizationWithPrepositions(string normalized)
        {
            //One offs for mi li/sina li
            //It's a prep, but missing the li.
            if (normalized.ContainsCheck("sina ~tawa"))
            {
                normalized = normalized.Replace("sina ~tawa", " sina li ~tawa");
            }
            if (normalized.ContainsCheck("mi ~tawa"))
            {
                normalized = normalized.Replace("mi ~tawa", "mi li ~tawa");
            }

            //"mi li ~tawa lon" -- the other one is a prep
            if (normalized.ContainsCheck("mi li ~tawa lon"))
            {
                normalized = normalized.Replace("mi li ~tawa lon", "mi li tawa ~lon");
            }

            //overnormalized... mi li ~tawa
            if (normalized.ContainsCheck("e mi li ~tawa"))
            {
                normalized = normalized.Replace("e mi li ~tawa", "e mi ~tawa");
            }
            //overnorm
            if (normalized.ContainsCheck("sina li ~tawa mi"))
            {
                normalized = normalized.Replace("sina li ~tawa mi", "sina ~tawa mi");
            }
            if (normalized.ContainsCheck("sina li o "))
            {
                normalized = normalized.Replace("sina li o ", "sina o ");
            }
            return normalized;
        }



        public static string MiSinaProcessAndUndoOverNormalization(string normalized)
        {
            //TODO: detect start of sentence & replace mi X and sina Y with 

            if (normalized.ContainsCheck("mi"))
            {
                normalized = NormalizationTasks.ApplyNormalization(normalized, "mi li", ProcessMi);
            }

            if (normalized.ContainsCheck("sina"))
            {
                normalized = NormalizationTasks.ApplyNormalization(normalized, "sina li", ProcessSina);
            }


            Dictionary<string, string> pronounModifiersMap = new Dictionary<string, string>
            {
                {"mi wan li ", "mi li wan li "},
                {"mi tu li ", "mi li tu li "},
                {"mi mute li ", "mi li mute li "},
                {"mi suli li ", "mi li suli li "},
                {"sina wan li ", "sina li wan li "},
                {"sina tu li ", "sina li tu li "},
                {"sina mute li ", "sina li mute li "},
                {"sina suli li ", "sina li suli li "},
                {"mi en sina li ", "mi li en sina li"}
            };

            //undo overnormalization
            foreach (KeyValuePair<string, string> pair in pronounModifiersMap)
            {
                if (normalized.ContainsCheck(pair.Value))
                {
                    normalized = normalized.Replace(pair.Value, pair.Key);
                }
            }


            if (normalized.ContainsCheck("la mi"))
            {
                bool dontTouch = false;
                foreach (string pronounModifier in pronounModifiers)
                {
                    if (normalized.ContainsCheck("la " + pronounModifier))
                    {
                        dontTouch = true;
                    }
                }
                if (!dontTouch)
                {
                    normalized = Regex.Replace(normalized, @"\bla mi\b", "la mi li"); //normalize contractions

                    //If original was, say, "kin la mi li pali", we get a double li li
                    if (normalized.ContainsCheck(" li li "))
                    {
                        //undo doubling.
                        normalized = Regex.Replace(normalized, @"\bli li\b", "li"); //normalize contractions
                    }
                }
            }


            if (normalized.ContainsCheck("la sina"))
            {
                bool dontTouch = false;
                foreach (string pronounModifier in pronounModifiers)
                {
                    if (normalized.ContainsCheck("la " + pronounModifier))
                    {
                        dontTouch = true;
                    }
                }
                if (!dontTouch)
                {
                    normalized = Regex.Replace(normalized, @"\bla sina\b", "la sina li"); //normalize contractions

                    //If original was, say, "kin la sina li pali", we get a double li li
                    if (normalized.ContainsCheck(" li li "))
                    {
                        //undo doubling.
                        normalized = Regex.Replace(normalized, @"\bli li\b", "li"); //normalize contractions
                    }
                }
            }
            return normalized;
        }


        private static string ProcessSina(string normalized)
        {
            normalized = NormalizedSinaLi(normalized);
            normalized = NormalizedSinaLi(normalized, "'");
            normalized = NormalizedSinaLi(normalized, "«");
            normalized = NormalizedSinaLi(normalized, "' ");
            normalized = NormalizedSinaLi(normalized, "« ");
            normalized = NormalizedSinaLi(normalized, "taso "); //conjunctions behave like leading punct
            normalized = NormalizedSinaLi(normalized, "anu "); //conjunctions behave like leading punct
            normalized = NormalizedSinaLi(normalized, "taso, "); //conjunctions behave like leading punct
            normalized = NormalizedSinaLi(normalized, "anu, "); //conjunctions behave like leading punct

            foreach (Word possible in Words.Dictionary.Values)
            {
                //Need a new concept-- ordinary POS & fallback POS
                string pronoun = "sina";
                Dictionary<string, Dictionary<string, string[]>> glosses;
                if (Words.Glosses.TryGetValue(possible.Text, out glosses))
                {
                    Dictionary<string, string[]> enGlosses;
                    if (glosses.TryGetValue("en", out enGlosses))
                    {
                        if ((enGlosses.ContainsKey("vt") && enGlosses["vt"].Length > 0)
                            ||
                            (enGlosses.ContainsKey("vi") && enGlosses["vi"].Length > 0))
                        {
                            string unLied = " " + pronoun + " " + possible + " ";
                            if (normalized.ContainsCheck(unLied) && !pronounModifiers.Contains(unLied.Trim()))
                            {
                                normalized = normalized.Replace(unLied, " " + pronoun + " li " + possible + " ");
                            }
                        }
                    }
                }
            }
            return normalized;
        }


        private static string NormalizedMiLi(string normalized, string punctuation = "")
        {
            if (normalized.StartCheck(punctuation + "mi ") && !normalized.StartCheck(punctuation + "mi li "))
            {
                //modified mi is rare.
                bool possibleProunoun = !normalized.StartCheck(punctuation + "mi suli")
                                        && !normalized.StartCheck(punctuation + "mi mute")
                                        && !normalized.StartCheck(punctuation + "mi tu");
                //mi mute li suli.
                //mi toki.

                //modified mi will force a li.
                if (possibleProunoun && !normalized.ContainsCheck("mi li " + normalized.Substring(3 + punctuation.Length)))
                {
                    //Skip we probalby have a li already.
                }
                //else
                {
                    normalized = punctuation + "mi li " + normalized.Substring(3 + punctuation.Length);
                }
            }
            return normalized;
        }


        public static string ProcessMiSinaOverNormalizationWithoutPrepositions(string text, string normalized)
        {
            if (normalized.ContainsCheck("taso, sina soweli"))
            {
                normalized = normalized.Replace("taso, sina soweli", "taso, sina li soweli");
            }
            if (normalized.ContainsCheck("taso mi pilin"))
            {
                normalized = normalized.Replace("taso mi pilin", "taso mi li pilin");
            }


            //mi mute o  ==> mi li mute o
            if (normalized.ContainsCheck("mi li mute o "))
            {
                normalized = normalized.Replace("mi li mute o ", "mi mute o ");
            }

            //overnormalized... mama pi mi mute o
            if (normalized.ContainsCheck("mama pi mi li mute o"))
            {
                normalized = normalized.Replace("mama pi mi li mute o", "mama pi mi mute o");
            }


            if (text.StartCheck("mi la ") && normalized.StartCheck("mi li "))
            {
                //ugh what a hack.
                normalized = "mi la " + normalized.Substring(9);
            }

            if (normalized.StartCheck("sina li en "))
            {
                //ugh what a hack.
                normalized = "sina en " + normalized.Substring("sina li en ".Length);
            }

            if (normalized.StartCheck("mi li en "))
            {
                //ugh what a hack.
                normalized = "mi en " + normalized.Substring("mi li en ".Length);
            }

            //mi la
            if (normalized.StartCheck("mi li la "))
            {
                //ugh what a hack.
                normalized = "mi la " + normalized.Substring("mi li la ".Length);
            }
            if (normalized.StartCheck("taso mi li la "))
            {
                //ugh what a hack.
                normalized = "taso mi la " + normalized.Substring("taso mi li la ".Length);
            }


            //mi la
            if (normalized.StartCheck("sina li la "))
            {
                //ugh what a hack.
                normalized = "sina la " + normalized.Substring("sina li la ".Length);
            }

            //e mi li mute
            if (normalized.ContainsCheck("e mi li mute"))
            {
                normalized = normalized.Replace("e mi li mute", "e mi mute");
            }

            //mi tu e -- dual vs to split into two
            if (normalized.ContainsCheck("mi tu e"))
            {
                normalized = normalized.Replace("mi tu e", "mi li tu e");
            }
            return normalized;
        }

        private static string NormalizedSinaLi(string normalized, string punctuation = "")
        {
            if (normalized.StartCheck(punctuation + "sina ") && !normalized.StartCheck(punctuation + "sina li "))
            {
                bool possibleProunoun = !normalized.StartCheck(punctuation + "sina suli")
                                        && !normalized.StartCheck(punctuation + "sina mute")
                                        && !normalized.StartCheck(punctuation + "sina tu");
                //mi mute li suli.
                //mi toki.

                if (possibleProunoun && normalized.ContainsCheck("sina li " + normalized.Substring(5 + punctuation.Length)))
                {
                    //Skip we probalby have a li already.
                }
                else
                {
                    normalized = punctuation + "sina li " + normalized.Substring(5 + punctuation.Length);
                }
            }
            return normalized;
        }
    }
}
