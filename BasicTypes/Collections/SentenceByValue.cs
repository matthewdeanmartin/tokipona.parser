using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;

namespace BasicTypes
{
    public class SentenceByValue : EqualityComparer<Sentence>
    {
        private static readonly SentenceByValue instance = new SentenceByValue();
        public static SentenceByValue Instance { get { return instance; } }

        static SentenceByValue() { }
        private SentenceByValue() { }

        public override bool Equals(Sentence x, Sentence y)
        {
            if (!ChainByValue.Instance.Equals(x.Subjects, y.Subjects))
            {
                return false;
            }

            if (x.Predicates.Count != y.Predicates.Count)
            {
                return false;
            }
            foreach (TpPredicate xPredicate in x.Predicates)
            {
                foreach (TpPredicate yPredicate in y.Predicates)
                {
                    if (!TpPredicateByValue.Instance.Equals(xPredicate, yPredicate))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override int GetHashCode(Sentence obj)
        {
            throw new NotImplementedException();
        }
    }


    //TODO: Same, but different predicate orders.

}
