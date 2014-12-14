using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Collections
{
    [TestFixture]
    public class VerbPhraseTests
    {
        [Test]
        public void Construction()
        {
            VerbPhrase vp = new VerbPhrase(
                Words.moku, 
                new WordSet(){ Words.ken},
                new WordSet(){ Words.wawa});
            Console.WriteLine(vp.ToString());
            Console.WriteLine(vp.ToString("b"));

        }
    }
}
