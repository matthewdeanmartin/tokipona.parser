using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Exceptions
{
    [Serializable]
    public class TpDomException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public TpDomException()
        {
        }

        public TpDomException(string message) : base(message)
        {
        }

        public TpDomException(string message, Exception inner) : base(message, inner)
        {
        }

        protected TpDomException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
