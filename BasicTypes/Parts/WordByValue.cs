using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
    public class WordByValue : EqualityComparer<Word>
    {
        private static readonly WordByValue instance = new WordByValue();
        public static WordByValue Instance { get { return instance; } }

        static WordByValue() { }
        private WordByValue() { }

        public override bool Equals(Word x, Word y)
        {
            return StringComparer.InvariantCulture.Equals(x.Text, y.Text);
        }

        public override int GetHashCode(Word obj)
        {
            return StringComparer.InvariantCulture.GetHashCode(obj);
        }
    }

}
