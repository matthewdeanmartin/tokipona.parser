using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Persist
{


    public class NativeMethods
    {
        [DllImport("rpcrt4.dll", SetLastError = true)]
        public static extern int UuidCreateSequential(out Guid guid);


        public static Guid CreateGuid()
        {
            const int RPC_S_OK = 0;

            Guid guid;
            int result = Persist.NativeMethods.UuidCreateSequential(out guid);
            if (result == RPC_S_OK)
                return guid;
            else
            {
                throw new Exception("Failed to Create guid");
            }
        }
    }
}