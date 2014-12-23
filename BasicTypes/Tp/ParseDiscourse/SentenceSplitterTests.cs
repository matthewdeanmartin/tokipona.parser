using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;
using BasicTypes.ParseDiscourse;
using NUnit.Framework;

namespace BasicTypes.Tp.ParseDiscourse
{
    [TestFixture]
    public class SentenceSplitterTests
    {
        [Test]
        public void QuotedSentence()
        {
            string s = @"""Saint Augustine Prophecy"".";
            Dialect dialect = Dialect.LooseyGoosey;
            SentenceSplitter ss = new SentenceSplitter(dialect);
            string[] results= ss.ParseIntoNonNormalizedSentences(s);
            Console.WriteLine(results[0]);

            Assert.IsTrue(!results[0].Contains("\""));
            //Assert.IsTrue(results[0].StartCheck("\""));
        }
    }
}
