using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
    //I really want to constrain the static methods!
    public interface IParse<T>
    {
        T Parse(string value);//throws on errors.
        bool TryParse(string value, out T result);//default config
        bool TryParse(string value, IFormatProvider provider, out T result);//specific config
    }
}
