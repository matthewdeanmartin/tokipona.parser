using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
    public class HeadPhraseByValue : EqualityComparer<HeadedPhrase>
    {
        private static readonly HeadPhraseByValue instance = new HeadPhraseByValue();
        public static HeadPhraseByValue Instance { get { return instance; } }

        static HeadPhraseByValue() { }
        private HeadPhraseByValue() { }

        public override bool Equals(HeadedPhrase x, HeadedPhrase y)
        {
            bool sameHead = WordByValue.Instance.Equals(x.Head, y.Head);

            if (!sameHead) return false;

            return WordSetByValue.Instance.Equals(x.Modifiers, y.Modifiers);
        }

        public override int GetHashCode(HeadedPhrase obj)
        {
            throw new NotImplementedException();
        }
    }
}
