using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Services
{
    //Stateful processor
    public class Wopatu
    {
        public Wopatu(Sentence[] linguisticKnowedge, Sentence[] goalKnowledge)
        {


            //Parse & turn into temporary tables
        }

        //User makes a request. Begine procesing response.
        public Sentence[] Request(Sentence[] requestInfo)
        {
            //Is it a command or question?
            //  Comply with action or result of query.
            //  - Repeat
            //  - Restate
            //  - Tell me what you know.
            //  Add to theory of mind as things that person is interested in knowing/having done.

            //Is it a statement?
            //   Add to knowledge.
            //   Restate

            //Compare theory-of-mind to goalKnowledge
            //   If there is a gap, tell them a did-you-know sort of statement.
            //   Infer a likely command, question.

            //If nothing else, ask use for additional facts of the same sort that we already know.

            return Response();
        }

        public Sentence[] Response()
        {
            //Add to what we think the interlocutor knows (theory of mind)
            return new Sentence[] { };
        }
    }
}
