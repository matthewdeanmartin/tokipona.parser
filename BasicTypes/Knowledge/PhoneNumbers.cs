using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;

namespace BasicTypes.Knowledge
{
    //Abstract Knowlege. 
    public class PhoneNumbers:Dictionary<string,string>
    {
        public PhoneNumbers()
        {
            Add("jan Mato","555-1523");
            Add("jan Seko", "123-4568");
        }
    }

    //Converts abstract knowledge into queryiable facts
    public class PhoneNumberFactGenerator:IGenerator
    {
        readonly PhoneNumbers facts = new PhoneNumbers();

        public IEnumerator<Sentence> GetEnumerator()
        {
            return facts.Select(kvp => EstablishAFact(kvp)).GetEnumerator();
        }

        private static Sentence EstablishAFact(KeyValuePair<string, string> pair)
        {
            string[] nameParts = pair.Key.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            
            Word jan = Words.jan;
            Word name = new Word(nameParts[1]);

            Word nanpa = Words.nanpa;
            Word fiveEtc = new Word(pair.Value);

            ComplexChain subject = ComplexChain.SinglePiEnChainFactory( new HeadedPhrase(jan, new WordSet { name}) );
            VerbPhrase verb = new VerbPhrase(Words.jo);
            ComplexChain directs = ComplexChain.SingleEPiChainFactory(new HeadedPhrase(nanpa, new WordSet { fiveEtc }));

            TpPredicate predicate = new TpPredicate(Particles.li, verb, directs);
            Sentence fact = new Sentence(subject, new PredicateList { predicate },
                new SentenceOptionalParts
                {
                 Punctuation = new Punctuation(".") 
                });
            return fact;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public interface IGenerator:IEnumerable<Sentence>
    {
        
    }
}
