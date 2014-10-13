using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
    public class SentenceSemeEqual : EqualityComparer<Sentence>
    {
        public override bool Equals(Sentence x, Sentence y)
        {
            //Same except for seme words.
            throw new NotImplementedException();
        }

        public override int GetHashCode(Sentence obj)
        {
            throw new NotImplementedException();
        }
    }
}
