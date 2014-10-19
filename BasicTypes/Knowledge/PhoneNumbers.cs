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
            this.Add("jan Mato","555-1523");
            this.Add("jan Seko", "123-4568");
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
            string[] nameParts = pair.Key.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            
            Word jan = Words.jan;
            Word name = new Word(nameParts[1]);
            
            Particle li = Particles.li;
            Word jo = Words.jo;
            Word nanpa = Words.nanpa;
            Word fiveEtc = new Word(pair.Value);

            Particle en = Particles.en;
            Particle e = Particles.e;

            Chain subject = new Chain(ChainType.Subjects, en, 
                new[] { new HeadedPhrase(jan, new WordSet(){ name}) });
            //Chain verbs = new Chain(ChainType.Predicates, li, new[] { new HeadedPhrase(jo, null) });
            HeadedPhrase verb = new HeadedPhrase(Words.jo,null);
            Chain directs = new Chain(ChainType.Directs, e, new[] { new HeadedPhrase(nanpa, new WordSet() { fiveEtc }) });

            TpPredicate predicate = new TpPredicate(Particles.li, verb, directs, null);
            Sentence fact = new Sentence(subject, new PredicateList { predicate });
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
