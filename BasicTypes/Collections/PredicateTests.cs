using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Collections
{
    [TestFixture]
    public class PredicateTests
    {
        [Test]
        public void CanSerialize()
        {
            HeadedPhrase hp = new HeadedPhrase(Words.jan,new WordSet(){ Words.seme});
            TpPredicate p = new TpPredicate(hp, ChainTests.SampleChain(), ChainTests.SampleChain());
            Assert.NotNull(p.ToJsonDcJs());
        }
    }
}
