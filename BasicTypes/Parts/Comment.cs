using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;

namespace BasicTypes.Parts
{
    // A line of text starting with /// and ending with a new line.
    [DataContract]
    [Serializable]
    public class Comment: IFormattable
    {
        [DataMember(IsRequired = true)]
        protected string comment;

        public string Text { get { return comment; } }

        public Comment(string value)
        {
            string checkValue = value.Trim();
            if (!checkValue.StartCheck("///"))
            {
                throw new InvalidOperationException("This isn't a valid comment, valid comments are started with /// and ended by a newline (must start with ///)");
            }
            if (checkValue.ContainsCheck("\n"))
            {
                throw new InvalidOperationException("This isn't a valid comment, valid comments are started with /// and ended by a newline (must not contain a newline)");
            }
            comment = value;
        }

        
        public override string ToString()
        {

            return ToString("g", Dialect.DialectFactory);
        }

        public string[] SupportedsStringFormats
        {
            get
            {
                return new[] { "g" };
            }
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                format = "g";
            }
            return comment;
        }
    }
}
