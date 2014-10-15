using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.FundamentalTests
{
    

    [TestFixture]
    public class TestObjectInterface
    {
        [Test]
        public void TestToString()
        {
            TestToString(Words.Dictionary.Values.ToArray());
        }

        [Test]
        public void TestToStringAndParse()
        {
            TestToStringAndParseIt<Word>(Words.Dictionary.Values.ToArray());
            TestToStringAndParseIt<Word>(Words.Dictionary.Values.ToArray(),Word.Parse);

        }

        private void TestToStringAndParseIt<T>(object[] objects, Func<string,T> parser)
            where T : class
        {
            foreach (object o in objects)
            {
                string value = o.ToString();
                Console.WriteLine(value);
                T parsed = parser.Invoke(value) as T;
                Assert.AreEqual(parsed.ToString(), value);
            }
        }
        public void TestToStringAndParseIt<T>(IParse<T>[] objects)
            where T: class
        {
            foreach (IParse<T> o in objects)
            {
                string value= o.ToString();
                T parsed = o.Parse(value) as T;
                Assert.AreEqual(parsed.ToString(), value); 
            }
        }

        [Test]
        public void TestFormattable()
        {
            TestToString(Words.Dictionary.Values.ToArray());
        }

        public void TestToString(object[] objects)
        {
            foreach (object test in objects)
            {
                string value = test.ToString();
                Assert.IsNotNullOrEmpty(value);

            }
        }



        public void TestCustomFormattable(object[] objects, ICustomFormatter[] formatters, IFormatProvider[] providers)
        {
            foreach (object o in objects)
            {
                foreach (ICustomFormatter customFormatter in formatters)
                {
                    string value = customFormatter.Format("g", o, CultureInfo.CurrentCulture);
                    Assert.IsNotNull(value);

                    string valueNull = customFormatter.Format(null, o, CultureInfo.CurrentCulture);
                    Assert.AreEqual(value, valueNull); //

                    string valueEmpty = customFormatter.Format(string.Empty, o, CultureInfo.CurrentCulture);
                    Assert.AreEqual(value, valueEmpty); //
                    
                }
            }

            foreach (object o in objects)
            {
                foreach (IFormatProvider provider in providers)
                {
                    string value = String.Format(provider, "{0:g}", o);
                    Assert.IsNotNullOrEmpty(value);

                }
            }

        }

        public void TestFormattable(IFormattable[] objects)
        {
            try

            {
             string value=   objects[0].ToString(Guid.NewGuid().ToString(), CultureInfo.CurrentCulture);
                Assert.Fail("Should have thrown FormatExcptoin on impossible format string");
            }
            catch (FormatException)
            {}

        //Must support G (or g?)
            foreach (IFormattable test in objects)
            {
                string value = test.ToString("G", CultureInfo.InvariantCulture);
                Assert.IsNotNullOrEmpty(value);

                string valueNull = test.ToString("G", CultureInfo.InvariantCulture);
                Assert.AreEqual(value, valueNull);

                string valueEmpty = test.ToString("G", CultureInfo.InvariantCulture);
                Assert.AreEqual(value, valueEmpty);

                string valueLowerG = test.ToString("g", CultureInfo.InvariantCulture);
                Assert.AreEqual(value, valueLowerG);

                string someFallBackFormat = test.ToString("g", null);
                string currentCultureFormat = test.ToString("g", CultureInfo.CurrentCulture);

                Assert.AreEqual(someFallBackFormat,currentCultureFormat);
                //ToString() should be same as ToString(null,Culturenfo.CurrentCulture) for all cultures.
            }

            //Works with a variety of number,datetime,cultures from thread (Which could vary)
            foreach (IFormattable test in objects)
            {
                foreach (CultureInfo cultureInfo in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
                {
                    string value = test.ToString("g", cultureInfo);
                    Assert.IsNotNullOrEmpty(value);

                }
            }

            //ToString should return something unique, if possible.
            Dictionary<string, string> s = new Dictionary<string, string>(objects.Length);
            foreach (IFormattable test in objects)
            {
                string value = test.ToString("G", CultureInfo.InvariantCulture);
                s.Add(value,value);
            }
        }

    }
}
