using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Extensions
{
    public class BinaryFormatterCopier<T>
        where T:class
    {
        public T Copy(T value)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, value);
                ms.Position = 0;
                return formatter.Deserialize(ms) as T;
            }
        }
    }
}
