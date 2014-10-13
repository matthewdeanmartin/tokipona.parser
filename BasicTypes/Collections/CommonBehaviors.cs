using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
    public interface IContainsWord
    {
        bool Contains(Word word);
    }

    //Not sure this is a good idea
    //public interface IParse<T>
    //{
    //    T Parse(string value);
    //    void TryParse(string value, out T result);
    //}
}
