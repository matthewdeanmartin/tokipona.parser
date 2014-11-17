using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Exceptions
{
    [Serializable]
    public class TpSyntaxException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public TpSyntaxException()
        {
        }

        public TpSyntaxException(string message) : base(message)
        {
        }

        public TpSyntaxException(string message, Exception inner) : base(message, inner)
        {
        }

        protected TpSyntaxException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class DoubleParticleException : TpSyntaxException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public DoubleParticleException()
        {
        }

        public DoubleParticleException(string message) : base(message)
        {
        }

        public DoubleParticleException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DoubleParticleException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public override string Message
        {
            get
            {
                if (string.IsNullOrEmpty(base.Message))
                {
                    return "Particles can't meaningfully reduplicate.";
                }
                return base.Message;
            }
        }
    }

    [Serializable]
    public class TpParseException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public TpParseException()
        {
        }

        public TpParseException(string message)
            : base(message)
        {
        }

        public TpParseException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected TpParseException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
