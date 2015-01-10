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
    //     suffixes can act as roots.
    //     last root is special & is the basic meaning (i.e. other roots act as modifiers)
    //    
    //Validity rules--
    //- If compound is same as existing root, it needs enpethetic o
    //- If "small" e.g. di/o it keeps the o
    //- If adjacent different in voice (e.g. z & k are different), then keep o
    //
    [DataContract]
    [Serializable]
    public class EoWord
    {
        [DataMember]
        private string text;
        
        [DataMember]
        private IEnumerable<EoAffix> prefixes;

        [DataMember]
        private IEnumerable<EoRoot> roots;

        [DataMember]
        private IEnumerable<EoWord> words;

        
        [DataMember]
        private IEnumerable<EoAffix> suffixes;
        [DataMember]
        private char partOfSpeech;

        public IEnumerable<EoAffix> Prefixes { get { return prefixes; } }

        public EoRoot BasicMeangRoot { get { return roots.Last(); } }

        public IEnumerable<EoRoot> Roots { get { return roots; } }

        public IEnumerable<EoAffix> Suffixes { get { return suffixes; } }

        public char PartOfSpeech { get { return partOfSpeech; } }

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
            text = String.Join("", prefixes)
                + String.Join("", words)
                + String.Join("", suffixes) + partOfSpeech;
        }

        public override string ToString()
        {
            return text;
        }
    }

}
