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
            Console.WriteLine("\n\nDone!");
            Console.ReadKey();
        }

        private static void WhatEver()
        {
            //Strict or loose text?
            //Loose -> Normalize
            //
        }
    }
}
