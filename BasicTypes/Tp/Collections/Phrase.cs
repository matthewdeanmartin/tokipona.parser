using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Collections
{
    /// <summary>
    /// Anything that is an (maybe) ordered list of tokens.
    /// </summary>
    public abstract class Phrase
    {
        //TODO: New base class when code is token driven & not word driven.

        //A token itself can't contain a token, it can be equal to one though.
        public abstract bool Contains(Token word);
    }
}
