using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Services
{
    //Stateless processor of a single set of sentences.
    public class Exchange
    {
        private Sentence[] facts = new Sentence[] { };
        private Sentence[] response = new Sentence[] { };
        private Sentence[] questions;
        public Exchange(Sentence[] facts, Sentence[] questions)
        {
            //Parse & turn into temporary tables
            this.facts = facts;
            this.questions = questions;

            foreach (Sentence question in questions)
            {
                foreach (Sentence fact in facts)
                {
                    if (question.Contains(Words.seme))
                    {
                        throw new NotImplementedException();
                        //if (SentenceSemeEqual.Instance.Equals(question, fact))
                        //{
                        //    response = new Sentence[] { SemeCondense(question, fact) };
                        //}
                    }
                }
            }

            //Sad fall back.
            if(response.Length==0)
            {
                //Command or new facts.
                response = facts;
            }

        }

        public Sentence SemeCondense(Sentence question, Sentence fact)
        {
            throw new NotImplementedException();
            ////Chain aSubject;
            ////Chain aPrediate;
            ////Chain aDirects;
            ////Chain aPrepositionals;

            ////Find seme segment.
            
            ////Borked now! Have to search the entire tree..
            //Chain semeSegment=
            //    (new List<Chain> { question.Subjects }).First(x => x.Contains(Words.seme));
            ////.AddRange(question.Predicates)
            ////  .First(x => x.Contains(Words.seme));

            ////Replace the seme segmenet in the question with the corresponding one from fact
            //List<Chain> segments = (new List<Chain> { question.Subjects }).ToList();
            
            //for(int i = 0;i<segments.Count;i++)
            //{
            //    Chain segment = segments[i];
            //    if (segment.ChainType != semeSegment.ChainType) continue;
            //    segments[i] = (new List<Chain> { fact.Subjects }).First(x => x.ChainType == segment.ChainType);
            //    break;
            //}

            ////What & when is something extra?
            ////seme li moku e kili?
            ////jan li moku.
            ////jan
            
            ////jan li moku e seme?
            ////kili.

            ////tenpo ni la jan li moku e seme?
            ////jan li moku e kili

            //Sentence result = new Sentence(segments[0], question.Predicates);
            //return result;
        }

        public Sentence[] Response()
        {
            return response;
        }

        public Sentence[] What()
        {
            List<Sentence> alt = new List<Sentence>();
            foreach (Sentence sentence in response)
            {
                alt.Add(sentence.EquivallencyGenerator());
            }
            return alt.ToArray();
        }
    }
}

