using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Extensions
{
    public static class StringBuilderExtensions
    {
        public static void TrimEnd(this StringBuilder builder)
        {
            while (builder[builder.Length - 1] == ' ')
            {
                builder.Remove(builder.Length - 1, 1);
            }
        }

        public static void RemoveInnerWhiteSpace(this StringBuilder builder)
        {
            builder.Replace("  ", " ");
            builder.TrimEnd();
        }
    }

    [TestFixture]
    public class StringBuilderExtensionsTests
    {
        [Test]
        public void TrimStringBuidler()
        {
            StringBuilder sb = new StringBuilder("blah   ");
            sb.TrimEnd();
            Assert.AreEqual("blah",sb.ToString());
        }

        [Test]
        public void RemoveInnerWhiteSpace()
        {
            StringBuilder sb = new StringBuilder("yada  yada  blah   ");
            sb.RemoveInnerWhiteSpace();
            Assert.AreEqual("yada yada blah", sb.ToString());
        }
    }
}
