using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
    public class ArrayExtensions
    {
        public static string[] Tail(string[] value)
        {
            string[] target = new string[value.Length-1];
            Array.Copy(value, 1, target, 0, value.Length - 1);
            return target;
        }
    }
}
