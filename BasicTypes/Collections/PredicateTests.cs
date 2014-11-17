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
            TpPredicate p = new TpPredicate(Particles.li, hp, SampleDirectsChain(), ChainTests.SamplePrepsChain());
            Assert.NotNull(p.ToJsonDcJs());
        }


        [Test]
        public void ThreePreps()
        {
            const string value = "ni li ~kepeken ilo suli ~tawa ilo suli ~poka ilo suli";
            ParserUtils pu = new ParserUtils(Dialect.DialectFactory);
            Sentence s = pu.ParsedSentenceFactory(value, value);
            string predicates = s.Predicates.ToString();
            Console.WriteLine(s.Predicates[0].Prepositionals);
            Console.WriteLine(predicates);
            Console.WriteLine(s.ToString());

        }

        public static ComplexChain SampleDirectsChain()
        {
            Chain c1 = Chain.PiChainFactory(new HeadedPhrase(Words.jelo, new WordSet { Words.esun }));
            Chain c2 = Chain.PiChainFactory(new HeadedPhrase(Words.kasi, new WordSet { Words.esun }));
            ComplexChain c = new ComplexChain(Particles.e, new[] { c1, c2 });
            return c;
        }

    }
}
