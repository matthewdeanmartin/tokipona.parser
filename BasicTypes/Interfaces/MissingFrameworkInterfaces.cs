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
    public interface IToString
    {
        string[] SupportedFormats { get; }
        string ToString(string format);
    }

    //[DebuggerDisplay("{DebuggerDisplay,nq}")]
    public interface IDebuggerDisplay
    {
        string DebuggerDisplay { get; }
    }

    public interface ICopySelf<out T> //: ICloneable
        where T : class
    {
        T ShallowCopy(); //Utility for avoiding copying large trees.
        T DeepCopy(); //Make an equality by value test pass.
    }

    

    public interface IParse<T>
    {
        T Parse(string value);//throws on errors.
        bool TryParse(string value, out T result);//default config
        bool TryParse(string value, IFormatProvider provider, out T result);//specific config
    }


    //Hmm, extension methods work better unless it simplifies working wiht proxy classes
   // public interface ICanSerialize<TProxy>
   // {
   //     string ToXml(TProxy value);
   //     string FromXml(TProxy value);
   // }

}
