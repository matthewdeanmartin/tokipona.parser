using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Knowledge
{
    [TestFixture]
    public class PhoneNumberTests
    {
        [Test]
        public void Test()
        {
            PhoneNumberFactGenerator generator = new PhoneNumberFactGenerator();
            var x = generator.GetEnumerator();
            x.MoveNext();
            string value = x.Current.ToString();
            Console.WriteLine(value);
            Assert.AreEqual("jan Mato li jo e nanpa 555-1523.", value , x.Current.ToString("b"));
            x.MoveNext();
            value = x.Current.ToString();
            Console.WriteLine(value);
            Assert.AreEqual("jan Seko li jo e nanpa 123-4568.", value , x.Current.ToString("b"));
        }
    }
}
