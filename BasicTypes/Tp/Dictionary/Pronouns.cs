using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Dictionary
{
    public class Pronouns
    {
        static Pronouns()
        {
            Dictionary = new Word[]
        {
            Words.ona,
            Words.mi,
            Words.sina,
            Words.ni,
            Words.jan,
            Words.ijo

        };
        }

        public static readonly Word[] Dictionary;
    }
}
