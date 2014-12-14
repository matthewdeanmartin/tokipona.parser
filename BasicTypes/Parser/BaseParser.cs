using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;

namespace BasicTypes.Parser
{
    //Diagnostics, memoization support.
    public class BaseParser
    {
        protected bool memoize = false;
        protected Dictionary<string, HeadedPhrase> headedPhraseParserMemo = new Dictionary<string, HeadedPhrase>();
        protected Dictionary<string, Chain> piChainMemo = new Dictionary<string, Chain>();
        protected SentenceDiagnostics diagnostics;

        public BaseParser()
        {
            
        }

        public T CheckMemoizeThis<T>(string value, Func<string, T> generator, Dictionary<string, T> store)
        {
            if (!memoize) 
                return generator(value);

            if (store.ContainsKey(value))
            {
                return store[value];
            }
            T result=  generator.Invoke(value);
            if (!store.ContainsKey(value))
            {
                store.Add(value, result);
            }
            else
            {
                //That's odd.
            }
            return result;
        }
    }
}
