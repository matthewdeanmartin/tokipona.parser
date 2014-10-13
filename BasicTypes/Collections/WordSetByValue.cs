using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
    public class WordSetByValue : EqualityComparer<WordSet>
    {
        private static readonly WordSetByValue instance = new WordSetByValue();
        public static WordSetByValue Instance { get { return instance; } }

        static WordSetByValue() { }
        private WordSetByValue() { }

        public override bool Equals(WordSet x, WordSet y)
        {
            return x.Count == y.Count && x.All(y.Contains);
        }

        public override int GetHashCode(WordSet obj)
        {
            throw new NotImplementedException();
        }
    }
}
