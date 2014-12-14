using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Collections
{
    //simple prep
    //prep + ala, e.g.  ni li lon ala ma mi. ==> does not parse to "ni li ~lon ala (ma mi)."  Even pi doesn't help.
    //prep + prep, .e.g. ni li lon poka ma mi. ==> maybe parses to "ni li ~lon poka (ma mi)." But they intended ~lon-poka
    //prep + nounish prep, ni li lon supa pi tomo mi ==> This is okay.
    public class ComplexPreposition
    {
        public Word[] Prepositions;
        public Word Negation;
    }
    public class ComplexPrepositionList
    {
        public ComplexPreposition[] Prepositions;
        public Word Conjunction;
    }
}
