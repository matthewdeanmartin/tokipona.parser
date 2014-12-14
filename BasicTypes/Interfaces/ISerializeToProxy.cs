using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
     public interface ICanSerialize<in TProxy, in TJsonProxy>
     {
         string ToXml(TProxy value);
         string FromXml(TProxy value);

         string ToJson(TJsonProxy value);
         string FromJson(TJsonProxy value);
     }
}
