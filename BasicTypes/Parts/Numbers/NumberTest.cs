using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Parts
{
    [TestFixture]
    public class NumberTest
    {

        [Test]
        public void StringToNumber_One_To_OneHundred_Stupid()
        {
            string[] values =
            {
                "wan",

            };
            foreach (var VARIABLE in values)
            {
                
            }
            string ten = "luka luka";
            Number n = new Number(ten);
            int result = n.ToInteger();
            Assert.AreEqual(10,result);
        }

        [Test]
        public void StringToNumber_One_To_OneHundred_HalfStupid()
        {
            string[] values =
            {
                "wan",

            };
            foreach (var VARIABLE in values)
            {

            }
            string ten = "luka luka";
            Number n = new Number(ten);
            int result = n.ToInteger();
            Assert.AreEqual(10, result);
        }

        [Test]
        public void StringToNumber_One_To_OneHundred_Poman()
        {
            string[] values =
            {
                "wan",

            };
            foreach (var VARIABLE in values)
            {

            }
            string ten = "luka luka";
            Number n = new Number(ten);
            int result = n.ToInteger();
            Assert.AreEqual(10, result);
        }

        [Test]
        public void StringToNumber_One_To_OneHundred_Decimal()
        {
            //Configurable.

            string[] values =
            {
                "wan",

            };
            foreach (var VARIABLE in values)
            {

            }
            string ten = "luka luka";
            Number n = new Number(ten);
            int result = n.ToInteger();
            Assert.AreEqual(10, result);
        }

        [Test]
        public void TestIt()
        {
            Console.WriteLine(Number.ConvertToBodyNumber(6));
            Console.WriteLine(Number.ConvertToBodyNumber(5));
            Console.WriteLine(Number.ConvertToBodyNumber(1973));

            Console.WriteLine();
            Console.WriteLine(Number.ConvertToBodyNumber(42));
            Console.WriteLine(Number.ConvertToBodyNumber(1234563459));
            Console.WriteLine(Number.ConvertToBodyNumber(1023456789));
            Console.WriteLine();
            Console.WriteLine(Number.ConvertToBodyNumber(42, "F"));
            Console.WriteLine(Number.ConvertToBodyNumber(1234563459, "F"));
            Console.WriteLine(Number.ConvertToBodyNumber(1023456789, "F"));
            Console.WriteLine();

            Console.WriteLine(Number.ConvertToBodyNumber(-4.2M));
            Console.WriteLine(Number.ConvertToBodyNumber(-12.34563459M));
            Console.WriteLine(Number.ConvertToBodyNumber(-1023.456789M));
            Console.WriteLine();
            Console.WriteLine(Number.ConvertToBodyNumber(-42, "F"));
            Console.WriteLine(Number.ConvertToBodyNumber(-12345.63459M, "F"));
            Console.WriteLine(Number.ConvertToBodyNumber(-102345.6789M, "F"));


            Console.WriteLine(Number.ConvertToBodyNumber(-4000000.0d));
            Console.WriteLine(Number.ConvertToBodyNumber(-100000000000.0d));
            Console.WriteLine(Number.ConvertToBodyNumber(-10000000000000000d));
            Console.WriteLine(Number.ConvertToBodyNumber(1234567890000000d));
            Console.WriteLine();
            Console.WriteLine(Number.ConvertToBodyNumber(-4000000000000d, "F"));
            Console.WriteLine(Number.ConvertToBodyNumber(-1234567890000000d, "F"));
            Console.WriteLine(Number.ConvertToBodyNumber(-0.102366666456789d, "F"));
        }
    }
}
