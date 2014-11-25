using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicTypes.Parser;

namespace PerfTestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            ParserUtilsTestsStressTests t = new ParserUtilsTestsStressTests();
            t.StressTestNormalizeAndParseEverything();
            Console.ReadKey();
        }
    }
}
