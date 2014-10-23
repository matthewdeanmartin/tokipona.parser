using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Parts
{
    public class TemplatedPhrase
    {
        public TemplatedPhrase(string template, string glossTemplate)
        {
            
        }



    }

    [TestFixture]
    public class TemplatedPhraseTests
    {
        [Test]
        public void TemplatedPhraseTests1()
        {
            string template = "{0} li pona {1}tawa {2}";
            string corpusText = "ni li pona kin tawa mi";
            string glossTemplate = "{2} {1} likes {0}";

            string [] parts;
            corpusText.TryExtract(template, out parts);
            List<string> s = new List<string>();
            foreach (string part in parts)
            {
                Word w = Words.Dictionary[part.Trim()];
                string g= w.GlossMap["en"].First().Value.First();
                s.Add(g);
            }
            Console.WriteLine(glossTemplate,s.ToArray());
        }
    }


}
