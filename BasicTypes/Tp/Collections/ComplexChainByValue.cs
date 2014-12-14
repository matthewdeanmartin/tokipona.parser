using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using KellermanSoftware.CompareNetObjects;

namespace BasicTypes
{
    public class ComplexChainByValue : EqualityComparer<ComplexChain>
    {
        private static readonly BasicTypes.ComplexChainByValue instance = new BasicTypes.ComplexChainByValue();
        public static BasicTypes.ComplexChainByValue Instance { get { return instance; } }

        static ComplexChainByValue() { }
        private ComplexChainByValue() { }

        public override bool Equals(ComplexChain x, ComplexChain y)
        {
            throw new NotImplementedException();
            //if (x.Particle.Text != y.Particle.Text)
            //{
            //    return false;
            //}
            //
            //CompareLogic compareLogic = new CompareLogic();
            //ComparisonResult result = compareLogic.Compare(x.HeadedPhrases, y.HeadedPhrases);
            //return result.AreEqual;
        }

        public override int GetHashCode(ComplexChain obj)
        {
            throw new NotImplementedException();
        }
    }

}
