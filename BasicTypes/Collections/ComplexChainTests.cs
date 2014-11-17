using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Collections
{
    [TestFixture]
    public class ComplexChainTests
    {
        [Test]
        public void CanSerialize()
        {
            var c = SampleChain();
            Assert.NotNull(c.ToJsonDcJs());
        }


        [Test]
        public void ParseTwoPiPhrasesPlusEn()
        {
            const string value = "esun pi tenpo suno en kasi pi tenpo suno";
            ComplexChain c = ComplexChain.Parse(value);
            Assert.AreEqual(c.Particle.ToString(), Particles.en.ToString());
            Console.WriteLine(c.ToJsonDcJs());
            Assert.AreEqual(value, c.ToString(), c.ToString("b"));
        }

        public static ComplexChain SampleChain()
        {
            Chain c1 = new Chain(Particles.pi, new[]
            {
                new HeadedPhrase(Words.jelo, new WordSet {Words.esun}),
                new HeadedPhrase(Words.kasi, new WordSet {Words.esun})
            });
            Chain c2 = new Chain(Particles.pi, new[]
            {
                new HeadedPhrase(Words.jelo, new WordSet {Words.esun}),
                new HeadedPhrase(Words.kasi, new WordSet {Words.esun})
            });
            return  new ComplexChain(Particles.en,new Chain[]{c1,c2});
        }

        [Test]
        public void ParseEsunEnKasi()
        {
            const string value = "esun en kasi";
            ComplexChain c = ComplexChain.Parse(value);
            Assert.AreEqual(c.Particle.ToString(), Particles.en.ToString());
            Console.WriteLine(c.ToJsonDcJs());
            Assert.AreEqual(value, c.ToString(), c.ToString("b"));
        }


        [Test]
        public void ParseAndToString()
        {
            const string value = "jelo esun en kasi esun";
            ComplexChain c = ComplexChain.Parse(value);
            Console.WriteLine(c.ToJsonDcJs());
            Assert.AreEqual(value, c.ToString(), c.ToString("b"));
        }
    }

    
}
