using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Esperanto.Tokens
{
    //Content words, can be any number of the simple compound words (1 core of stems)
    //     (prefix*)? stems* (suffixes*)? 
    //     [singleCoreWord]* + (pos) (j/n)
    [DataContract]
    [Serializable]
    public class EoWord
    {
        [DataMember]
        private string text;

        public string Text{get { return text; }}


        public EoWord(IEnumerable<EoAffix> prefixes, IEnumerable<EoRoot> roots, IEnumerable<EoAffix> suffixes, char partOfSpeech)
        {
            text = String.Join("", prefixes) + String.Join("", roots) + String.Join("", suffixes) + partOfSpeech;
        }
        public EoWord(IEnumerable<EoAffix> prefixes, IEnumerable<EoRoot> roots, char partOfSpeech)
        {
            text = String.Join("", prefixes) + String.Join("", roots) + partOfSpeech;
        }
        public EoWord(IEnumerable<EoRoot> roots, IEnumerable<EoAffix> suffixes, char partOfSpeech)
        {
            text = String.Join("", roots) + String.Join("", suffixes) + partOfSpeech;
        }
        public EoWord(EoRoot root, char partOfSpeech)
        {
            text = String.Join("", root) + partOfSpeech;
        }
        public EoWord(IEnumerable<EoRoot> roots, char partOfSpeech)
        {
            text = String.Join("", roots) + partOfSpeech;
        }


        //Maximal word
        public EoWord(IEnumerable<EoAffix> prefixes, IEnumerable<EoWord> words, IEnumerable<EoAffix> suffixes, char partOfSpeech)
        {
            text = String.Join("",  prefixes)
                + String.Join("", words)
                + String.Join("", suffixes) + partOfSpeech;
        }

        public override string ToString()
        {
            return text;
        }
    }

}
