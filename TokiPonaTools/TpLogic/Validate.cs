using System;
using System.Text;
using Microsoft.VisualBasic;

namespace TokiPona
{
    public class Validate
    {

        private string OnlyValidSyllables(string toki)
        {
            if (string.IsNullOrEmpty(toki))
            {
                return "Invalid: Is Null or Empty";
            }

            if (toki == toki.ToLower())
            {
                if (IsValidLetters(toki))
                {
                }
                //continue
                else
                {
                    return "Invalid: containts no uppercase words, but has letters outside of the 14 official letters";
                }
            }

            while (toki.Contains("  "))
            {
                toki = toki.Replace("  ", " ");
            }

            string[] words = toki.Split(' ');
            for (int i = 0; i <= words.Length - 1; i++)
            {
                if (words[i].Substring(0, words[i].Length - 1).Contains("n"))
                {
                    return "Invalid: contains n, but n isn't final letter in word";
                }
                for (int j = 0; j <= words[i].Length; j++)
                {
                    // Need to split on consonants  vcv(+n), cvcv(+n), cv(+n), cvcv+n  
                    // not sure but this maybe the most general pattern... v + cv +(n) + cv (n) ..etc
                    //If words(i).Contains Then

                    //End If
                }
            }
            throw new NotImplementedException();
        }

        // Final n must be tested separately.  the vowels likewise, because vowels on their own seem to only be at the start of words
        private bool TestSyllable(string s)
        {
            switch (s)
            {
                case "a":
                    return true;
                case "e":
                    return true;
                case "i":
                    return true;
                case "o":
                    return true;
                case "u":
                    return true;
                case "ka":
                    return true;
                case "ke":
                    return true;
                case "ki":
                    return true;
                case "ko":
                    return true;
                case "ku":
                    return true;
                case "sa":
                    return true;
                case "se":
                    return true;
                case "si":
                    return true;
                case "so":
                    return true;
                case "su":
                    return true;
                case "ta":
                    return true;
                case "te":
                    return true;
                case "ti":
                    // bad
                    return false;
                case "to":
                    return true;
                case "tu":
                    return true;
                case "ma":
                    return true;
                case "me":
                    return true;
                case "mi":
                    return true;
                case "mo":
                    return true;
                case "mu":
                    return true;
                case "na":
                    return true;
                case "ne":
                    return true;
                case "ni":
                    return true;
                case "no":
                    return true;
                case "nu":
                    return true;
                case "pa":
                    return true;
                case "pe":
                    return true;
                case "pi":
                    return true;
                case "po":
                    return true;
                case "pu":
                    return true;
                case "ja":
                    return true;
                case "je":
                    return true;
                case "ji":
                    return false;
                case "jo":
                    return true;
                case "ju":
                    return true;
                case "la":
                    return true;
                case "le":
                    return true;
                case "li":
                    return false;
                case "lo":
                    return true;
                case "lu":
                    return true;
                case "wa":
                    return true;
                case "we":
                    return true;
                case "wi":
                    return false;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool IsValidLetters(string s)
        {
            StringBuilder sb = new StringBuilder(s);
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
            sb.Replace("l", "");
            sb.Replace("w", "");
            sb.Replace("j", "");
            sb.Replace(" ", "");
            if (sb.ToString().Trim().Length > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}