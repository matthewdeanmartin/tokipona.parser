using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;

namespace BasicTypes
{
    //Iterate through valid values (
    public interface IRange: IEnumerator, IEnumerable
    {
        //IEnumerable Range();
    }

    //public class Enumerate : IEnumerator, IEnumerable
    //{
    //    public bool MoveNext()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Reset()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public object Current { get; private set; }

    //    public IEnumerator GetEnumerator()
    //    {
    //        return this;
    //    }
    //}

    //Forgotten interfaces
    

    //[DebuggerDisplay("{DebuggerDisplay,nq}")]
    public interface IDebuggerDisplay
    {
        string DebuggerDisplay { get; }
    }

    
   


    //Hmm, extension methods work better unless it simplifies working wiht proxy classes
   // public interface ICanSerialize<TProxy>
   // {
   //     string ToXml(TProxy value);
   //     string FromXml(TProxy value);
   // }

}
