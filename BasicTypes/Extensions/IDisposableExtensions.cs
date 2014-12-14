using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Extensions
{
    public static class IDisposableExtensions
    {
        public static void SafeDispose(this IDisposable value)
        {
            if(value!=null)
                value.Dispose();
        }
    }
}
