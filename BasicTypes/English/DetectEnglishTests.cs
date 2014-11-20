using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHunspell;
using NUnit.Framework;

namespace BasicTypes.English
{
    [TestFixture]
    public class DetectEnglishTests
    {
        [Test]
        public void Test()
        {
            using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
            {
                Console.WriteLine("Hunspell - Spell Checking Functions");
                Console.WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");

                Console.WriteLine("Check if the word 'Recommendation' is spelled correct");
                bool correct = hunspell.Spell("Recommendation");
                Console.WriteLine("Recommendation is spelled " +
                   (correct ? "correct" : "not correct"));

                Console.WriteLine("");
                Console.WriteLine("Make suggestions for the word 'Recommendatio'");
                List<string> suggestions = hunspell.Suggest("Recommendatio");
                Console.WriteLine("There are " +
                   suggestions.Count.ToString() + " suggestions");
                foreach (string suggestion in suggestions)
                {
                    Console.WriteLine("Suggestion is: " + suggestion);
                }
            }
        }
    }
}
