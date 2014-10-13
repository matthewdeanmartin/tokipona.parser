using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.Knowledge;
using NUnit.Framework;

namespace BasicTypes
{
    [TestFixture]
    public class DiscourseTests
    {
        [Test]
        public void JustConstruct()
        {
            Discourse d = new Discourse();
            PhoneNumberFactGenerator generator = new PhoneNumberFactGenerator();

            d.Add(generator.GetEnumerator().Current);
        }

        [Test]
        public void CanSerialize()
        {
            Discourse d = new Discourse();
            PhoneNumberFactGenerator generator = new PhoneNumberFactGenerator();

            d.Add(generator.GetEnumerator().Current);
            Assert.NotNull(d.ToJsonDcJs());
        }
    }
}
