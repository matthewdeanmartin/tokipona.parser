using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;

namespace BasicTypes
{
    public partial class Chain
    {
        public static Chain Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value is null or zero length string");
            }
            return ChainTypeConverter.Parse(value);
        }

        public static bool TryParse(string value, out Chain result)
        {
            try
            {
                result = ChainTypeConverter.Parse(value);
                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;

            }
        }

    }
}
