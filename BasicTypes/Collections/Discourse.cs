using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Collections
{
    /// <summary>
    /// Sentences that have to be considered as a whole to be meaningful.
    /// </summary>
    /// <remarks>For example, a sentences with a pronoun that refers to something in a preceding sentence.</remarks>
    [Serializable]
    public class Discourse : List<Sentence>
    {
    }
}
