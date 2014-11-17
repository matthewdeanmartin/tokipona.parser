using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Collections
{
    //A special sort of headed phrase, can act as a modifier.
    public class PrepositionalPhrase
    {
        //preposition
        private Word preposition;

        //noun phrase (pi & en)
        private ComplexChain complexChain;

        //Different preps strung together  //~sama x ~sama x2 ~kepeken y
        public PrepositionalPhrase(Word preposition, ComplexChain complexChain)
        {
            this.preposition = preposition;
            this.complexChain = complexChain;
        }


    }
}
