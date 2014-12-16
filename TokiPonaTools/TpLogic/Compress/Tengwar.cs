using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpLogic.Compress
{
    public class TengwarMaker
    {
        public StringBuilder sb = new StringBuilder();

        public string convertToken(string token)
        {
            if ("aeiou".Contains(token[0]))
                token = "q" + token;

            if (token.Length > 1)
            {
                var index = 1;
                var len = token.Length;
                while (index < len)
                {

                    //NotVowel
                    if ("aoeui".Contains(token[index]))
                    {
                        if ("lmnMN".Contains(token[index - 1]))
                        {
                            if (token.Length != index || index<token.Length)
                                token = Captitalize(token, index);
                            //if(token.Length<index + 2)
                            //{
                            //    token = token.Substring(0, index + 1) +
                            //        char.ToUpper(token[index + 1]) +
                            //        token.Substring(index + 2);
                            //}
                            //else
                            //{
                            //    token =
                            //        token.Substring(0, index + 1) +
                            //        char.ToUpper(token[index + 1]);
                            //            //+ token.Substring(index + 2);
                            
                            //}
                        }
                    }

                    var replace = "";
                    if (token[index]== 'n')
                    {
                        var penult = token[index - 1];
                        //if (index == token.length -1 || "aoeui".indexOf(token.charAt(index+1)) == -1) {
                        if (index == token.Length - 1 || !"aoeui".Contains(token[index + 1]))
                        {
                            if (penult == 'o' || penult == 'u')
                                replace = "M";
                            else
                                replace = "N";

                            token = token.Substring(0, index) 
                                    + replace 
                                    + token.Substring(index + 1);
                        }
                    }
                    index++;
                }

            }
            return token;
        }



        public string Convert(string input)
        {
            var alpha = "abcdefghijklmnopqrstuvwxyz";
            var terminators = "!?";
            //v a r input = document.getElementById("input").value;
            var index = 0;
            var token = "";
            var curr = '?';
            var last = '?';

            //document.getElementById("output").innerHTML = ""

            while (index < input.Length)
            {
                if (curr != ' ') last = curr;
                curr = char.ToLower(input[index]);

                if (!alpha.Contains(curr))
                {
                    // not an alpha character
                    if (token != "")
                    {
                        sb.Append(convertToken(token));
                        token = "";
                    }

                    sb.Append(curr);
                }
                else
                {
                    if (terminators.Contains(last)) sb.Append(".");
                    token = token + curr;
                }
                index++;
            }

            if (token != "") sb.Append(convertToken(token));
            if (curr != '.') sb.Append(".");
            return "";
        }

        public string Captitalize(string token, int index)
        {
            if (index >= token.Length) return token;

            string part1 = token.Substring(0, index);
            char part2 = char.ToUpper(token[index]);
            string part3 = token.Substring(index+1);
            return part1 + part2 + part3;
        }
    }
}
