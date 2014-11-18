using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hangfire;
using TokiPonaApi.Filters;

namespace TokiPonaApi.Controllers
{
    public class ValuesAsyncController : ApiController
    {
        private static Dictionary<int, string> db = new Dictionary<int, string>()
        {
            {1,"a" },
            {2,"b" },
        };



        public ValuesAsyncController()
        {

        }

        // GET api/values
        [BasicAuthentication]
        public IEnumerable<string> Get()
        {
            return db.Values;
        }

        [BasicAuthentication]
        public string Get(int id)
        {
            return db[id];
        }

        // POST api/values
        [BasicAuthentication]
        public HttpResponseMessage Post([FromBody]string value)
        {
            Guid g = Guid.NewGuid();
            string jobId = BackgroundJob.Enqueue(() => InsertRecord(value, g, CreateLocation(-999999)));

            QueueController.QueueMap.Add(g, jobId);
            return DefaultQueueMessage(g);
        }

        [BasicAuthentication]
        private HttpResponseMessage DefaultQueueMessage(Guid g)
        {
            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.Accepted);
            message.Headers.Location = CreateQueueLocation(g);
            return message;
        }

        private Uri CreateQueueLocation(Guid g)
        {
            return new Uri("http://localhost" + Url.Route("DefaultApi", new { controller = "Queue", id = g.ToString() }));
        }

        private Uri CreateLocation(int g)
        {
            return new Uri("http://localhost" + Url.Route("DefaultApi", new { controller = "Values", id = g.ToString() }));
        }


        // PUT api/values/5
        [BasicAuthentication]
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            Guid g = Guid.NewGuid();
            string result = BackgroundJob.Enqueue(() => UpdateRecord(id, value, g, CreateLocation(id)));
            QueueController.QueueMap.Add(g, result);
            return DefaultQueueMessage(g);
        }

        // DELETE api/values/5
        [BasicAuthentication]
        public HttpResponseMessage Delete(int id)
        {
            Guid g = Guid.NewGuid();
            string result = BackgroundJob.Enqueue(() => DeleteRecord(id, g, CreateLocation(id)));
            QueueController.QueueMap.Add(g, result);
            return DefaultQueueMessage(g);
        }

        //The execution of this is tracked by HangFire, but results of the code are not!
        [BasicAuthentication]
        public static void InsertRecord(string value, Guid g, Uri request)
        {
            QueueController.QueueResults.Add(g, new QueueController.QueueState()
            {
                Url = ""
            });
            int id = db.Keys.Max() + 1;
            db.Add(id, value);
            QueueController.QueueResults[g].Url = request.ToString().Replace("-999999", id.ToString());
        }

        //The execution of this is tracked by HangFire, but results of the code are not!
        [BasicAuthentication]
        public static void UpdateRecord(int id, string value, Guid g, Uri request)
        {
            QueueController.QueueResults.Add(g, new QueueController.QueueState()
            {
                Url = ""
            });
            db[id] = value;
            QueueController.QueueResults[g].Url = request.ToString();
        }


        //The execution of this is tracked by HangFire, but results of the code are not!
        [BasicAuthentication]
        public static void DeleteRecord(int id, Guid g, Uri request)
        {
            QueueController.QueueResults.Add(g, new QueueController.QueueState()
            {
                Url = ""
            });
            db.Remove(id);
            QueueController.QueueResults[g].Url = request.ToString();
        }
    }
}
