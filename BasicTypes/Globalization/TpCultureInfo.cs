using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Globalization
{
    public class TpCultureInfo:CultureInfo
    {
        public TpCultureInfo(string name) : base(name)
        {
        }

        public TpCultureInfo(string name, bool useUserOverride) : base(name, useUserOverride)
        {
        }

        public TpCultureInfo(int culture) : base(culture)
        {
        }

        public TpCultureInfo(int culture, bool useUserOverride) : base(culture, useUserOverride)
        {
        }
    }
}
