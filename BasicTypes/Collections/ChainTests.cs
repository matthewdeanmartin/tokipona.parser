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
        public void SmallestPiChain()
        {
            const string value = "tomo pi telo nasa";
            Chain c = Chain.Parse(value);
            Assert.AreEqual(Particles.pi.ToString(),c.Particle.ToString());
            Console.WriteLine(c.ToJsonDcJs());
            Assert.AreEqual(value, c.ToString(), c.ToString("b"));
        }

        

        [Test]
        public void ParseE_eEsunESoweli()
        {
            try
            {
                //This may not stay this way-- an e phrase holds chains, not headed phrases.
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
