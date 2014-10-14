using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes
{
    [TestFixture]
    public class Tester
    {
        [Test]
        public void Tester1()
        {
            Console.WriteLine(String.Format(new WordFormatInfo(), "g", Words.jan));
        }
    }

    public class WordFormatInfo : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            //Why?
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        //Other Properties
        //public string ToString(string format, IFormatProvider formatProvider)
        //{
        //    throw new NotImplementedException();
        //}

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof (Word))
            {
                WordFormatInfo info = formatProvider as WordFormatInfo;
                Word word = arg as Word;
                if (format == "g")
                {
                    return word.Text;
                }
                else
                {
                    throw new FormatException("Unknown format code");
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
