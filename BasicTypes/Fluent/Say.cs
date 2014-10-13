using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Fluent
{
    public class Say
    {
        public Say That(string jan)
        {
            return this;
        }

        public Say Did(string liUnpa)
        {
            return this;
        }

        public Say The(string empty)
        {
            return this;
        }

        public Sentence Okay()
        {
            return null;
        }
    }



    [TestFixture]
    public class TestFluent
    {
        [Test]
        public void Test()
        {
            Say well = new Say();
            //Have to keep thinking about this.
            Sentence s= well.That("jan ilo").Did("li unpa").The("").Okay();
        }
    }
}
