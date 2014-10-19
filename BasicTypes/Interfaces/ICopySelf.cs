using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
    public interface ICopySelf<out T> //: ICloneable
        where T : class
    {
        T ShallowCopy(); //Utility for avoiding copying large trees.
        T DeepCopy(); //Make an equality by value test pass.
    }

}
