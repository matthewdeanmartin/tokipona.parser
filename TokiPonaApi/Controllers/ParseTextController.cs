using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BasicTypes;
using BasicTypes.Collections;
using BasicTypes.NormalizerCode;

namespace TokiPonaApi.Controllers
{
    /// <summary>
    /// Returns 'bracked', json, xml and html representations of a sentence.
    /// </summary>
    /// <remarks>
    /// Can parse plain text in lenient mode or annotated (punctuated) text in strict mode. 
    /// </remarks>
    public class ParseTextController : ApiController
    {

        public string Get(string text)
        {
            Dialect d = Dialect.LooseyGoosey;
            
            string normalized = Normalizer.NormalizeText(text, d);
            ParserUtils pu = new ParserUtils(d);
            Sentence s=  pu.ParsedSentenceFactory(normalized, text);

            return s.ToString("b",d);
        }

    }
}
