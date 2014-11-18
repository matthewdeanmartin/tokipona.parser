using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Caching;
using System.Web.Http;
using TokiPonaApi.Filters;
using TokiPonaApi.Controllers;

namespace TokiPonaApi.Controllers
{
    public class ValuesQueueController : BaseApiController
    {
        private static readonly Dictionary<Guid, int> queue = new Dictionary<Guid, int>();

        //Doesn't work. Needs persistent message queue to make this work.
        [BasicAuthentication]
        public HttpResponseMessage Get(Guid id)
        {
            if (queue.ContainsKey(id))
            {
                if (queue[id] == 0)
                {
                    //Done!
                    HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
                    message.Content.Headers.Expires = DateTimeOffset.Now.AddSeconds(15);
                    return message;
                }
                else
                {
                    //Done!
                    HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.SeeOther);
                    message.Headers.Location = new Uri("Values/" + queue[id]);
                    return message;
                }
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

    }
}
