using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Collections
{
    //mi mute li suli.
    //seme li suli? mi mute.
    //Anything that binds to something else.
    //mi mute, sina mute, ni, seme, 

    /// <summary>
    /// Distinct concept because they are different as constants and variables in a programming language
    /// They can be bound to another phrase in the discourse, they can have identity.
    /// </summary>
    public class ComplexPronoun: HeadedPhrase
    {
        public ComplexPronoun(Word head, WordSet modifiers) : base(head, modifiers)
        {
        }

        
    }
}
