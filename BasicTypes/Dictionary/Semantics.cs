using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Dictionary
{
    public class Semantics
    {
        
        public Semantics(bool animate, string gender, bool isAgent)
        {
            IsAnimate = animate; //soweli, jan
            IsFeminine = gender == "f"; //meli
            IsFeminine = gender != "f"; //mije
            IsAgent = isAgent; //all animates + some things
        }
        public bool IsAgent { get; private set; }
        public bool IsAnimate { get; private set; }
        public bool IsFeminine { get; private set; }
        public bool IsMasculine { get; private set; }
    }
}
