using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TpLogic.Orthography;

namespace TpTests
{
    [TestFixture]
    public class SpellTests
    {
        [Test]
        public void SpellEnglish()
        {
            string result = Spell.SpellMilitary("jan Mato");

            Assert.AreEqual("jaki-akesi-nasin moku-akesi-toki-oko", result);
        }
    
        [Test]
        public void SpellZooEnglish()
        {
            string result = Spell.SpellMilitary("Zoo");

            Assert.AreEqual("sitelen Si Inli-oko-oko", result);
        }

        [Test]
        public void SpellGreek()
        {
            string result = Spell.SpellGreek("A quick brown fox");

            Assert.AreEqual("sitelen Alepa sitelen Kopa-sitelen Upilon-sitelen Jota-sitelen Ki-sitelen Kapa sitelen Peta-sitelen Lo-sitelen Omikon-sitelen Tikama-sitelen Nu sitelen Pe-sitelen Omikon-sitelen Kusai", result);
        }
    }
}
