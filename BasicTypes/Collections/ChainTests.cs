using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;

namespace BasicTypes.Collections
{
    [TestFixture]
    public class ChainTests
    {
        [Test]
        public void CanSerialize()
        {
            var c = SampleChain();
            Assert.NotNull(c.ToJsonDcJs());
        }

        [Test]
        public void CanBinarySerialize()
        {
            TestSerialization(SampleChain,ChainByValue.Instance);

            //BinaryFormatter formatter = new BinaryFormatter();
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    formatter.Serialize(ms, f);
            //    ms.Position = 0;
            //    Chain result = formatter.Deserialize(ms) as Chain;
            //    Assert.NotNull(ChainByValue.Instance.Equals(result, f));
            //}
        }

        public void TestSerialization<T>(Func<T> generator, IEqualityComparer<T> comparer)
        {
            T f = generator.Invoke();

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, f);
                ms.Position = 0;
                T result = (T)formatter.Deserialize(ms);
                Assert.NotNull(comparer.Equals(result, f));
            }
        }

        public static ComplexChain SampleDirectsChain()
        {
            Chain c1 = Chain.PiChainFactory(new HeadedPhrase(Words.jelo, new WordSet {Words.esun}));
            Chain c2 = Chain.PiChainFactory(new HeadedPhrase(Words.kasi, new WordSet {Words.esun}));
            ComplexChain c = new ComplexChain(Particles.e, new[]{c1,c2});
            return c;
        }

        

        public static PrepositionalPhrase[] SamplePrepsChain()
        {
            //Bit over kill.
            Chain simpleChain = new Chain( Particles.pi, new[]
            {
                new HeadedPhrase(Words.jelo, new WordSet {Words.esun})
            });
            ComplexChain complexChain = new ComplexChain(Particles.en, new[] { simpleChain });

            Chain simpleChain2 = new Chain(Particles.pi, new[]
            {
                new HeadedPhrase(Words.jelo, new WordSet {Words.esun})
            });
            ComplexChain complexChain2 = new ComplexChain(Particles.en, new[] { simpleChain2 });

            PrepositionalPhrase phrase1 = new PrepositionalPhrase(Words.kepeken, complexChain);
            PrepositionalPhrase phrase2 = new PrepositionalPhrase(Words.kepeken, complexChain2);

            return new[]{phrase1, phrase2};//should these be it's own concept?
        }

        public static Chain SampleChain()
        {
            Chain c = new Chain(Particles.en, new[]
            {
                new HeadedPhrase(Words.jelo, new WordSet {Words.esun}),
                new HeadedPhrase(Words.kasi, new WordSet {Words.esun})
            });
            return c;
        }

        public static VerbPhrase SampleVerbPhrase()
        {
            return  new VerbPhrase(Words.moku,new WordSet {Words.ken}, new WordSet { Words.mute});
        }

        [Test]
        public void ToStringTest()
        {
            Chain c = new Chain(Particles.en, new[]
            {
                new HeadedPhrase(Words.jelo, new WordSet { Words.esun}),    
                new HeadedPhrase(Words.kasi, new WordSet { Words.esun})
            });
            Console.WriteLine(c.ToJsonDcJs());
            Assert.AreEqual("jelo esun en kasi esun",c.ToString());
        }

        [Test]
        public void ParseAndToString()
        {
            const string value = "jelo esun en kasi esun";
            Chain c = Chain.Parse(value);
            Console.WriteLine(c.ToJsonDcJs());
            Assert.AreEqual(value, c.ToString(), c.ToString("b"));
        }

        [Test]
        public void ParseEsunEnKasi()
        {
            const string value = "esun en kasi";
            Chain c = Chain.Parse(value);
            Assert.AreEqual(c.Particle.ToString(), Particles.en.ToString());
            Console.WriteLine(c.ToJsonDcJs());
            Assert.AreEqual(value, c.ToString(), c.ToString("b"));
        }


        [Test]
        public void ParseKepekenIlo()
        {
            const string value = "~kepeken ilo";
            Chain c = Chain.Parse(value);
            Assert.AreEqual("~kepeken",c.Particle.ToString());
            Console.WriteLine(c.ToJsonDcJs());
            Assert.AreEqual("~kepeken ilo", c.ToString(), c.ToString("b"));
        }

        [Test]
        public void ParseKepekenIloSuli()
        {
            const string value = "~kepeken ilo suli";
            Chain c = Chain.Parse(value);
            Assert.AreEqual("~kepeken",c.Particle.ToString());
            Console.WriteLine(c.ToJsonDcJs());
            Assert.AreEqual("~kepeken ilo suli", c.ToString(), c.ToString("b"));
        }

        [Test]
        public void ThreePreps()
        {
            const string value = "ni li ~kepeken ilo suli ~tawa ilo suli ~poka ilo suli";
            ParserUtils pu = new ParserUtils(Dialect.DialectFactory);
            Sentence s = pu.ParsedSentenceFactory(value, value);
            string predicates= s.Predicates.ToString();
            Console.WriteLine(s.Predicates[0].Prepositionals);
            Console.WriteLine(predicates);
            Console.WriteLine(s.ToString());
            
        }

        [Test]
        public void SmallestPiChain()
        {
            const string value = "tomo pi telo nasa";
            Chain c = Chain.Parse(value);
            Assert.AreEqual(Particles.en.ToString(),c.Particle.ToString());
            Console.WriteLine(c.ToJsonDcJs());
            Assert.AreEqual(value, c.ToString(), c.ToString("b"));
        }

        [Test]
        public void ParseKepekenIloSuliPiMaSuli()
        {
            const string value = "~kepeken ilo suli pi ma suli";
            Chain c = Chain.Parse(value);
            Assert.AreEqual("~kepeken",c.Particle.ToString() );
            Console.WriteLine(c.ToJsonDcJs());
            Assert.AreEqual("~kepeken ilo suli pi ma suli", c.ToString(), c.ToString("b"));
        }

        [Test]
        public void ParseTwoPiPhrasesPlusEn()
        {
            const string value = "esun pi tenpo suno en kasi pi tenpo suno";
            Chain c = Chain.Parse(value);
            Assert.AreEqual(c.Particle.ToString(), Particles.en.ToString());
            Console.WriteLine(c.ToJsonDcJs());
            Assert.AreEqual(value, c.ToString(), c.ToString("b"));
        }

        [Test]
        public void ParseE_eEsunESoweli()
        {
            try
            {
                const string value = "e esun e soweli";
                Chain c = Chain.Parse(value);
                Assert.AreEqual(c.Particle.ToString(), Particles.e.ToString());
                Console.WriteLine(c.ToJsonDcJs());
                Assert.AreEqual(value, c.ToString(), c.ToString("b"));
            }
            catch (NotImplementedException)
            {
                Assert.Ignore("Oh well, eventually. But don't panic just because code isn't written yet.");
            }

        }
    }
}
