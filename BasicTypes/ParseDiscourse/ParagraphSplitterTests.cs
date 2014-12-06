using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.CollectionsDiscourse;
using NUnit.Framework;

namespace BasicTypes.ParseDiscourse
{
    [TestFixture]
    public class ParagraphSplitterTests
    {
        [Test]
        public void TestOneSentence()
        {
            ParagraphSplitter ps = new ParagraphSplitter(Dialect.LooseyGoosey);
            Prose prose= ps.ParseProse("ni li pona kin.");
            Assert.NotNull(prose);
            Console.WriteLine(prose.ToString());
        }
    }
}
