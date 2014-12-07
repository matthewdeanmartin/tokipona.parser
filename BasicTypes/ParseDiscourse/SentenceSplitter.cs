using System;
using System.Collections.Generic;
using System.Linq;
using BasicTypes.CollectionsDiscourse;
using BasicTypes.NormalizerCode;
using NUnit.Framework;

namespace BasicTypes.ParseDiscourse
{
    //TODO: keep single line comments togeher
    //ID paragraphs (starts with tab or new line)
    //Treats double punctuation as a single thing (?!, !!, ??)
    //Treats quotes, parens, etc as its own concept. (maybe 1 level above sentence)
    //Auto close quotes on para breaks.
    public class SentenceSplitter
    {
    }

}
