using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Exceptions
{
    [Serializable]
    public class InvalidPhonologyException : Exception
    {
        public InvalidPhonologyException()
        { }

        public InvalidPhonologyException(string message)
            : base(message)
        { }

        public InvalidPhonologyException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public InvalidPhonologyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }

    [Serializable]
    public class InvalidLetterSetException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public InvalidLetterSetException()
        {
        }

        public InvalidLetterSetException(string message) : base(message)
        {
        }

        public InvalidLetterSetException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidLetterSetException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class InvalidSyntaxException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public InvalidSyntaxException()
        {
        }

        public InvalidSyntaxException(string message) : base(message)
        {
        }

        public InvalidSyntaxException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidSyntaxException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class UnterminatedSentenceException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public UnterminatedSentenceException()
        {
        }

        public UnterminatedSentenceException(string message) : base(message)
        {
        }

        public UnterminatedSentenceException(string message, Exception inner) : base(message, inner)
        {
        }

        protected UnterminatedSentenceException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class FailedToBindPronounException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public FailedToBindPronounException()
        {
        }

        public FailedToBindPronounException(string message) : base(message)
        {
        }

        public FailedToBindPronounException(string message, Exception inner) : base(message, inner)
        {
        }

        protected FailedToBindPronounException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class ExtraneousPiException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ExtraneousPiException()
        {
        }

        public ExtraneousPiException(string message) : base(message)
        {
        }

        public ExtraneousPiException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ExtraneousPiException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class MissingSubjectException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public MissingSubjectException()
        {
        }

        public MissingSubjectException(string message) : base(message)
        {
        }

        public MissingSubjectException(string message, Exception inner) : base(message, inner)
        {
        }

        protected MissingSubjectException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }


}
