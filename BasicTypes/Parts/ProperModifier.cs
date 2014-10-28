using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Parts
{
    class ProperModifier
    {
        /// <summary>
        /// Weak test, only checks capitalization, not phonotactics.
        /// </summary>
        public static bool IsProperModifer(string text)
        {
            //Degenerate cases.
            if(string.IsNullOrWhiteSpace(text))
                return false;

            if (text[0] == '"')
                return false; //Foreign text

            if (text[0] == '#')
                return false; //Number

            //People make so many mistakes-- this may confuse matters. 
            //Really need a "probably is modifier"
            foreach (char c in text)
            {
                if (!"jklmnpstwaeiou".Contains(c))
                {
                    return false; //Foreign text. Really a different thing.
                }
            }

            if (text[0].ToString() == text[0].ToString().ToUpper())
            {
                return true;
            }
            return false;
        }

        public static bool IsValidProperModifer(string text)
        {
            //Degenerate cases.
            if (string.IsNullOrWhiteSpace(text))
                return false;

            foreach (char c in text)
            {
                if (!"jklmnpstwaeiou".Contains(c))
                {
                    return false; //Foreign text. Really a different thing.
                }    
            }

            //Mato > cap-lower-lower-etc
            for (int index= 0; index < text.Length; index++)
            {
                if (index == 0)
                {
                    if (text[0].ToString() != text[0].ToString().ToUpper())
                    {
                        return false;
                    }
                }
                else
                {
                    if (text[0].ToString() != text[0].ToString().ToLower())
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
