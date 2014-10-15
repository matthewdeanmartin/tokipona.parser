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

    public class Number
    {
        private string number;
        public Number(string number)
        {
            this.number = number;
        }


        //            0 ala (nothing)
        //* 1 nena (nose) (or wan)
        //* 2 oko (eyes) (or tu)
        //3 kute (ears) (sum of everything inbetween)
        //4 uta (mouth)
        //* 5 luka (hand)
        //6 insa (belly)
        //7 monsi (butt)
        //8 palisa/lupa (netherregions, obviously depends on who's counting)
        //9 noka (leg)
        //* 10 noka pini (toes) (nena ala would be proper decimal)

        public static string ConvertToBodyNumber(decimal i, string gender = "M")
        {
            StringBuilder sb = new StringBuilder();
            ConvertDigits(i.ToString(), gender, sb);
            return ProcessNegatives(i.ToString(), sb);
        }
        public static string ConvertToBodyNumber(double i, string gender = "M")
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine(i.ToString("E2"));
            ConvertDigits(i.ToString("E2"), gender, sb);
            return ProcessNegatives(i.ToString(), sb);
        }
        public static string ConvertToBodyNumber(int i, string gender = "M")
        {
            StringBuilder sb = new StringBuilder();
            ConvertDigits(i.ToString(), gender, sb);
            return ProcessNegatives(i.ToString(), sb);
        }

        private static string ProcessNegatives(string i, StringBuilder sb)
        {

            string temp = "#" + sb.ToString().Trim(new[] {'-'});
            if (i.Contains("-"))
            {
                temp = "nanpa-anpa " + temp;
            }
            while(temp.Contains("--"))
            {
                temp = temp.Replace("--", "-");
            }
            while (temp.Contains("wawa-ala"))
            {
                temp = temp.Replace("wawa-ala", "wawa-");
            }
            while (temp.Contains("wawa-ala"))
            {
                temp = temp.Replace("wawa-ala", "wawa-");
            }
            while (temp.Contains("--"))
            {
                temp = temp.Replace("--", "-");
            }
            while (temp.Contains("wawa-lili-ala"))
            {
                temp = temp.Replace("wawa-lili-ala", "wawa-lili-");
            }
            while (temp.Contains("wawa-lili-ala"))
            {
                temp = temp.Replace("wawa-lili-ala", "wawa-lili-");
            }
            while (temp.Contains("--"))
            {
                temp = temp.Replace("--", "-");
            }
            return temp;
        }

        private static void ConvertDigits(string  representation, string gender, StringBuilder sb)
        {
            foreach (char c in representation.Replace("E-","E~"))
            {
                switch (c)
                {
                    case '1':
                        sb.Append("wan");
                        break;
                    case '2':
                        sb.Append("tu");
                        break;
                    case '3':
                        sb.Append("kute");
                        break;
                    case '4':
                        sb.Append("uta");
                        break;
                    case '5':
                        sb.Append("luka");
                        break;
                    case '6':
                        sb.Append("insa");
                        break;
                    case '7':
                        sb.Append("tu");
                        break;
                    case '8':
                        sb.Append("monsi");
                        break;
                    case '9':
                        sb.Append(gender == "M" ? "palisa" : "lupa");
                        break;
                    case '0':
                        sb.Append("ala");
                        break;
                    case '.':
                        sb.Append("sike");
                        break;
                    case 'E':
                        sb.Append("wawa");
                        break;
                    case '-':
                        //skip deal with elsewhere.
                    case '+':
                        //default to positive
                        break;
                    case '~':
                        sb.Append("lili");
                        break;
                    default:
                        sb.Append("[" + c + "]");
                        break;
                }
                sb.Append("-");
            }
        }

        
    }
}
