using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TpLogic.Compress
{
    public class Tokenizer
    {
        public string[] TokenizeByWhiteSpace(string input)
        {
            return Regex.Split(input, @"(?=[ .,:{}|!@#$%^&*()_+=])|(?<=[ .,:{}|!@#$%^&*()_+=])");
        }
    }
}
