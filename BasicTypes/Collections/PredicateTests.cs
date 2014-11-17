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
            VerbPhrase hp = new VerbPhrase(Words.jan,new WordSet(){ Words.seme});
            TpPredicate p = new TpPredicate(Particles.li, hp, ChainTests.SampleDirectsChain(), ChainTests.SamplePrepsChain());
            Assert.NotNull(p.ToJsonDcJs());
        }
    }
}
