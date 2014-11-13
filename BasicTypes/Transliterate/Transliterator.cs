using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Transliterate
{
    public enum LanguageForR
    {
        FrenchGerman = 1,
        TrilledTapped = 2,
        English = 3
    }

    public enum ClusterPreference
    {
        Split = 1,
        Merge = 2
    }

    public class Options
    {
        public LanguageForR RLanguage { get; set; }
        public ClusterPreference ConsonantCluster { get; set; }
        public ClusterPreference VowelCluster { get; set; }
        public string NeutralVowel { get; set; }
        public string NeutralConsonant { get; set; }
        public string SorT { get; set; }
        public bool IsFinalEPronounced { get; set; }
    }

    public class TransliterateEngine
    {
        StringBuilder sbTrace = new StringBuilder();

        public static Options DefaultOptions()
        {
            Options defaults = new Options();
            defaults.NeutralVowel = "i";
            defaults.SorT = "t";
            defaults.ConsonantCluster = ClusterPreference.Merge;
            defaults.VowelCluster = ClusterPreference.Merge;
            defaults.RLanguage = LanguageForR.English;
            return defaults;
        }
        public string OneName(string s)
        {
            Options defaults = new Options();
            defaults.NeutralVowel = "i";
            defaults.SorT = "t";
            defaults.ConsonantCluster = ClusterPreference.Merge;
            defaults.VowelCluster = ClusterPreference.Merge;
            defaults.RLanguage = LanguageForR.English;
            return OneName(s, defaults);
        }

        public string OneName(string s, Options how)
        {
            //Degenerate cases

            if (string.IsNullOrEmpty(s)) return "";
            if (s.Length == 1)
            {
                if (IsVowel(s))
                    return s;
            }


            s = s.Replace(" ", "");
            s = s.Replace("-", "");

            s = s.ToLower();

            //Crazy french-isms
            s = s.Replace("oire", "wa");

            s = s.Replace("qu", "k");

            //Crazy Englishism
            s = s.Replace("new", "nu");//New Zealand

            //bw, rw zimbabwe, rwanda
            s = s.Replace("bw", "buw");
            s = s.Replace("rw", "ruw");

            s = s.Replace("oo", "u");

            if (s.StartsWith("kl"))
                s = s.Replace("kl", "s");

            //str in australia
            s = s.Replace("str", "s");

            s = s.Replace("b", "p");
            s = s.Replace("d", "t");

            s = s.Replace("x", "k");
            s = s.Replace("ks", "k");
            s = s.Replace("cs", "k");
            s = s.Replace("zh", "j");

            s = s.Replace("ch", "s");

            //Attempt to remove final silent e
            if (!how.IsFinalEPronounced)
            {
                if (s.EndsWith("e"))
                {
                    s = s.Substring(0, s.Length - 1);
                }
            }



            s = s.Replace("v", "w");
            s = s.Replace("f", "p");

            s = s.Replace("ng", "n");// ng as in sing isn't 2 sounds.


            //niger -> zh -> sw
            s = s.Replace("ige", "ise");

            //goveror -> k
            s = s.Replace("g", "k");

            switch (how.RLanguage)
            {
                case LanguageForR.English:
                    // English
                    s = s.Replace("r", "w");
                    break;
                case LanguageForR.FrenchGerman:
                    // uvular/velar const, French R, German R
                    s = s.Replace("r", "k");
                    break;
                case LanguageForR.TrilledTapped:
                    // Trilled/tapped
                    s = s.Replace("r", "l");
                    break;
                default:
                    throw new InvalidOperationException("Unknown preferred language");
            }

            if (s.EndsWith("sh"))
            {
                s = s.Substring(0, s.Length - 2) + "si";
            }
            //schwa -- replace with neighboring non-schwa??

            //replace final m (nasal) with n

            if (s.EndsWith("m"))
            {
                s = s.Substring(0, s.Length - 1) + "n";
            }
            sbTrace.AppendLine(s);

            //m+ consonant is okay. But something zaps it before m turns to n
            s = s.Replace("amb", "anp");//Zambia Zanpija
            s = s.Replace("mb", "nb");
            s = s.Replace("mp", "np");

            s = s.Replace("mn", "m");
            s = s.Replace("nm", "n");


            s = s.Replace("ye", "je");
            s = s.Replace("yi", "ji");
            s = s.Replace("ya", "ja");
            s = s.Replace("yo", "jo");
            s = s.Replace("yu", "ju");

            s = s.Replace("y", "i");

            //Drop final consonants if not =n
            if (s.Length >= 1 & s.Length > 3)
            {
                while (IsConsonant(s.Substring(s.Length - 1, 1)))
                {
                    if (s.EndsWith("n"))
                    {
                        break; // TODO: might not be correct. Was : Exit While
                    }
                    s = s.Substring(0, s.Length - 1);
                }
            }

            if (s.Length >= 1 & s.Length <= 3)
            {
                s = s + "e";
            }
            sbTrace.AppendLine(s);

            // j/w rule ??

            s = s.Replace("ti", "si");
            s = s.Replace("wo", "o");
            s = s.Replace("wu", "u");
            sbTrace.AppendLine(s);

            if (s.EndsWith("ja"))
                s = s.Replace("ja", "ya"); //Kenja
            else
            {
                // affictive to frictive
                s = s.Replace("j", "s");
            }

            sbTrace.AppendLine(s);

            if (how.VowelCluster == ClusterPreference.Split)
            {

                if (s.EndsWith("ya")) //Libya
                    s = s.Replace("ya", "ija");

                if (s.EndsWith("ia")) //Italia
                    s = s.Replace("ia", "ija");

                if (s.EndsWith("ea")) //Etritrea
                    s = s.Replace("ea", "eja");

                //s = s.Replace("ie", "i");
                s = s.Replace("ie", "ije"); //Sierra Leon

                s = s.Replace("eo", "ijo"); //Sierra Leon

                s = s.Replace("ee", "eje"); //Equatorial Guinnea

                s = s.Replace("io", "ijo"); //Ethiopia

                s = s.Replace("ua", "uwa"); //Vanuatu

                s = s.Replace("oa", "owa"); //Samoa

                s = s.Replace("iu", "iju");//tok pisin version of papua new guinea

                foreach (char c in "aeiou")
                {
                    if (s.Contains(c.ToString() + c))
                        s = s.Replace(c.ToString() + c, c.ToString());
                }
            }
            else
            {
                foreach (char c in "aeiou")
                {
                    if (s.Contains(c.ToString() + c))
                        s = s.Replace(c.ToString() + c, c.ToString());
                }
            }
            //Vowel clusters -- inspired by african contry names
            s = s.Replace("ia", "i");

            s = s.Replace("ou", "e"); //?
            //s = s.Replace("ou", "u"); //Ddjibouti 
            s = s.Replace("ui", "i");
            s = s.Replace("ea", "e"); //New Zealand -> i
            s = s.Replace("oo", "o"); //could also be u

            if (s.StartsWith("au"))
                s = s.Replace("au", "o"); //Australia
            else
                s = s.Replace("au", "u"); //Maruitania

            s = s.Replace("iu", "i");//Mauritius

            s = s.Replace("au", "a");//Ginneau Bissau




            //If s.EndsWith(...nasal vowel...) then ' huh?
            // s = s.Substring(0, s.Length - 1) + "n"
            //End if

            //If s.EndsWith(...voiceless later consonants...) then ' huh?
            // s = s.replace( vlc's,"s")
            //End if


            // no guidance

            s = s.Replace("th", how.SorT);
            //s = s.Replace("th", "s")



            s.Replace("mn", "m");
            s.Replace("nm", "n");

            s = RemoveDoubleConstants(s);
            sbTrace.AppendLine(s);

            s = s.Replace("ts", "s");

            //Something between here and the above code for dealing with double vowels creates a double vowel
            foreach (char c in "aeiou")
            {
                if (s.Contains(c.ToString() + c))
                    s = s.Replace(c.ToString() + c, c.ToString());
            }

            // Last chance to remove invalid consonants. 
            // Don't remove these earlier because sometimes they particpate in digraphs
            s = s.Replace("c", "k");
            s = s.Replace("z", "s");
            s = s.Replace("y", "j"); //last ditch effort

            if (s.StartsWith("h"))
                s = s.Replace("h", "");

            //May create clusters
            s = s.Replace("ji", "i");
            s = s.Replace("wu", "u");
            s = s.Replace("wo", "o");
            s = s.Replace("ti", "si");


            if (how.ConsonantCluster == ClusterPreference.Split)
            {
                s = AddVowels(s, how.NeutralVowel);

                if (IsConsonant(s[s.Length - 1].ToString()) && IsConsonant(s[s.Length - 2].ToString()))
                {
                    s = s.Substring(0, s.Length - 1) + how.NeutralVowel + s.Substring(s.Length - 1, 1);
                }

                sbTrace.AppendLine(s);
            }
            else
            {
                s = DropConsonantClusters(s);


                if (IsConsonant(s[s.Length - 1].ToString()) && IsConsonant(s[s.Length - 2].ToString()))
                {
                    if (s[s.Length - 1] == 'n')
                    {
                        s = s.Substring(0, s.Length - 1); // +how.NeutralVowel + s.Substring(s.Length - 1, 1);
                    }
                    else
                    {
                        //Don't think this is right but it make the word less invalid.
                        s = s.Substring(0, s.Length - 1) + how.NeutralVowel + s.Substring(s.Length - 1, 1);
                    }
                }



                sbTrace.AppendLine(s);
            }

            s = UppercaseFirst(s);
            //if (IsValidProperModifier(s))
            //{
            //    throw new InvalidOperationException("Contains invalid letters");
            //    //sbTrace.AppendLine("Alphabet is okay");
            //}


            sbTrace.ToString();
            return s;

        }

        //http://dotnetperls.com/uppercase-first-letter
        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }

        public string Transliterate(string s, out string trace, Options how)
        {
            //StringBuilder sbTrace = new StringBuilder();

            string[] names = s.Split(' ');

            StringBuilder result = new StringBuilder();

            for (int i = 0; i <= names.Length - 1; i++)
            {
                result.Append(OneName(names[i], how).Trim());
                result.Append(" ");
            }

            trace = sbTrace.ToString().Trim();
            return result.ToString().Trim();

        }

        public bool IsValidProperModifier(string input)
        {
            if (string.IsNullOrEmpty(input)) return true;
            if (ContainsInvalidFirst(input)) return false;
            if (ContainsNonLetters(input)) return false;
            return true;
        }

        public bool ContainsInvalidFirst(string input)
        {
            if (input.Length == 0) return false;

            const string alphabet = "AEIJKLMNOPSTUW";

            return !alphabet.Contains(input[0].ToString());
        }

        public bool ContainsNonLetters(string input)
        {
            const string alphabet = "AEIJKLMNOPSTUWaeijklmnopstuw";

            foreach (char c in input)
            {
                if (!alphabet.Contains(c.ToString())) return true;
            }

            return false;
        }

        static bool IsAlphabetOk(string s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(s);
            sb.Replace("a", "");
            sb.Replace("e", "");
            sb.Replace("i", "");
            sb.Replace("o", "");
            sb.Replace("u", "");
            sb.Replace("p", "");
            sb.Replace("t", "");
            sb.Replace("k", "");
            sb.Replace("s", "");
            sb.Replace("m", "");
            sb.Replace("n", "");
            sb.Replace("w", "");
            sb.Replace("j", "");
            sb.Replace(" ", "");
            if (sb.Length > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        bool IsSyllabificationOk(string s)
        {
            throw new NotImplementedException();
        }

        public static string DropConsonantClusters(string s)
        {
            // Remove frictives first, ie f,th,s,z,sh,zh

            for (int i = 0; i <= s.Length - 3; i++)
            {
                if (!(i + 1 > s.Length - 1))
                {
                    if (IsConsonant(s.Substring(i, 1)) & IsConsonant(s.Substring(i + 1, 1)))
                    {
                        s = s.Replace(s.Substring(i, 1) + s.Substring(i + 1, 1), RemoveFrictive(s.Substring(i, 1), s.Substring(i + 1, 1)));
                    }
                }
            }

            for (int i = 0; i <= s.Length - 3; i++)
            {
                if (!(i + 1 > s.Length - 1))
                {
                    if (IsConsonant(s.Substring(i, 1)) & IsConsonant(s.Substring(i + 1, 1)))
                    {
                        s = s.Replace(s.Substring(i, 1) + s.Substring(i + 1, 1), RemoveFrictive(s.Substring(i, 1), s.Substring(i + 1, 1)));
                    }
                }
            }

            for (int i = 0; i <= s.Length - 3; i++)
            {
                if (!(i + 1 > s.Length - 1))
                {
                    if (IsConsonant(s.Substring(i, 1)) & IsConsonant(s.Substring(i + 1, 1)))
                    {
                        s = s.Replace(s.Substring(i, 1) + s.Substring(i + 1, 1), RemoveFrictive(s.Substring(i, 1), s.Substring(i + 1, 1)));
                    }
                }
            }

            return s;
        }


        static string RemoveFrictive(string l1, string l2)
        {
            // Assume c is pronounced s
            // Can't deal with th,sh,zh
            if (l1 == "n")
            {
                return l1 + l2;
            }
            if (l1 == "f" | l1 == "s" | l1 == "l" | l1 == "z" | l1 == "c")
            {
                return l2;
            }
            else
            {
                return l1;
            }
        }


        public static string RemoveDoubleConstants(string s)
        {
            for (int i = 0; i <= s.Length - 1; i++)
            {
                if (!(i + 1 > s.Length - 1))
                {
                    if (s.Substring(i, 1) == s.Substring(i + 1, 1))
                    {
                        if (IsConsonant(s.Substring(i, 1)) & IsConsonant(s.Substring(i + 1, 1)))
                        {
                            s = s.Replace(s.Substring(i, 1) + s.Substring(i + 1, 1), s.Substring(i + 1, 1));
                        }
                    }
                }
            }
            return s;
        }


        static string AddVowels(string s, string vowel)
        {
            // We should give preference to vowels that already exist in the word
            for (int i = 0; i <= s.Length - 1; i++)
            {
                if (!(i + 1 > s.Length - 1))
                {
                    if (IsConsonant(s.Substring(i, 1)) & IsConsonant(s.Substring(i + 1, 1)))
                    {
                        s = s.Substring(0, i + 1) + vowel + s.Substring(i + 1);
                    }
                }
            }
            return s;
        }

        public static bool IsVowel(string s)
        {
            return (s == "a" | s == "e" | s == "i" | s == "o" | s == "u");
        }

        public static bool IsConsonant(string s)
        {
            return !(s == "a" | s == "e" | s == "i" | s == "o" | s == "u");
        }

        public static bool DifferByOnlyOneLetter(string first, string second)
        {
            if (first.Length != second.Length) return false;

            int differ = 0;
            for (int i = 0; i < second.Length - 1; i++)
            {
                if (first[i] != second[i])
                    differ++;
            }

            return differ <= 1;
        }
    }
}
