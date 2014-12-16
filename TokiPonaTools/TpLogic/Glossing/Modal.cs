using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TpLogic
{
    public class ModalProcessor
    {
        private Lexicon dictionary;
        public ModalProcessor(Lexicon newDictionary)
        {
            dictionary = newDictionary;
        }

        public string Tail;

        //post li, exists M(*). Definitely over at first " e "
        public Collection<Modal> SplitIntoModals(string verbPhrase)
        {
            //e's are optional
            if (verbPhrase.Contains(" e "))
            {
                verbPhrase = verbPhrase.Substring(0, verbPhrase.IndexOf(" e "));
            }

           string[] words=  verbPhrase.Split(new char[]{' '});

    

            Collection<Modal>  modals = new Collection<Modal>();

            //wile	strong force driving toward: must, need, ought
            //ken	no strong force against: can, may
            //kama	come to (become, happen, not arrive at)
            //*open	begin, open
            //*pini	end, finish
            //*awen	keep on, continue

            if(!(words.Contains("ken") 
                ||words.Contains("wile")
                || words.Contains("kama")
                || words.Contains("open")
                || words.Contains("pini")
                || words.Contains("awen")))
            {
                return modals;
            }

            int lastModal=0;
            for (int i = 0; i < verbPhrase.Length;i++ )
            {
                if(verbPhrase.Substring(i).StartsWith("ken"))
                {
                    modals.Add(new Modal(dictionary,"ken"));
                    i=i+3;
                    lastModal = i;
                }
                else if (verbPhrase.Substring(i).StartsWith("kama"))
                {
                    modals.Add(new Modal(dictionary, "kama"));
                    i = i + 4;
                    lastModal = i;
                }
                else if (verbPhrase.Substring(i).StartsWith("open"))
                {
                    modals.Add(new Modal(dictionary, "open"));
                    i = i + 4;
                    lastModal = i;
                }
                else if (verbPhrase.Substring(i).StartsWith("awen"))
                {
                    modals.Add(new Modal(dictionary, "awen"));
                    i = i + 4;
                    lastModal = i;
                }
                else if (verbPhrase.Substring(i).StartsWith("pini"))
                {
                    modals.Add(new Modal(dictionary, "pini"));
                    i = i + 4;
                    lastModal = i;
                }
                else if (verbPhrase.Substring(i).StartsWith("wile"))
                {
                    modals.Add(new Modal(dictionary, "wile"));
                    i = i + 4;
                    lastModal = i;
                }

                string[] tailWords = verbPhrase.Substring(i+1).Split(new char[] {' '});
                if (!IsAModal(tailWords[0]))
                {
                    break;
                }
            }

            Tail = verbPhrase.Substring(lastModal).Trim();

            return modals;
        }
    
        private bool IsAModal(string word)
        {
            if(word=="ken") return true;
            if(word=="kama") return true;
            if(word=="open") return true;
            if(word=="pini") return true;
            if(word=="awen") return true;
            return false;
        }
    }

    public class Modal
    {
        private Lexicon lexicon;
        private string _text;
        public string Text
        {
            get { return _text; }
        }

        public Modal(Lexicon dictionary, string baseText)
        {
            _text = baseText;
           lexicon = dictionary;
        }
    
        public string Translate()
        {
            if (lexicon.nouns.ContainsKey(Text))
                return lexicon.nouns[Text];
            else if (lexicon.unknownPos.ContainsKey(Text))
                return lexicon.unknownPos[Text];
            else
            {
                //Must be a proper modifier, it isn't tp
                return Modifier.Capitalize(Text);
            }
        }
    }
}
