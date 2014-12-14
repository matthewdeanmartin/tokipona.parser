using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
    //Not sure if this is a good idea.
    public abstract class StringableObject: IFormattable, IToString
    {
        public abstract string ToString(string format, IFormatProvider formatProvider);

        public virtual string[] SupportedsStringFormats
        {
            get
            {
                return new string[] { "g" };
            }
        }

        public virtual string ToString(string format)
        {
            return this.ToString(format, Config.CurrentDialect);
        }

        public override string ToString()
        {
            return this.ToString("g", Config.CurrentDialect);
        }
    }
}
