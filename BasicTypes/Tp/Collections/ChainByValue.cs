using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KellermanSoftware.CompareNetObjects;

namespace BasicTypes
{

    public class ChainByValue : EqualityComparer<Chain>
    {
        private static readonly ChainByValue instance = new ChainByValue();
        public static ChainByValue Instance { get { return instance; } }

        static ChainByValue() { }
        private ChainByValue() { }

        public override bool Equals(Chain x, Chain y)
        {
            if (x.Particle.Text != y.Particle.Text)
            {
                return false;
            }
            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult result = compareLogic.Compare(x.HeadedPhrases, y.HeadedPhrases);
            return result.AreEqual;
        }

        public override int GetHashCode(Chain obj)
        {
            throw new NotImplementedException();
        }
    }
}
