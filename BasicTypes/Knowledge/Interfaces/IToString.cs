using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
    public interface IToString
    {
        string[] SupportedsStringFormats { get; }
        string ToString(string format);
    }
}
