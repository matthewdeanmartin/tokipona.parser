using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hangfire;
using Hangfire.Storage;
using Hangfire.Storage.Monitoring;
using TokiPonaApi.Filters;

namespace TokiPonaApi.Controllers
{
    public class QueueController : ApiController
    {
        public class QueueState
        {
            public string JobId { get; set; }
            public string Url { get; set; }
        }

        internal static Dictionary<Guid, QueueState> QueueResults = new Dictionary<Guid, QueueState>();
        internal static Dictionary<Guid, string> QueueMap = new Dictionary<Guid, string>();

        // GET api/<controller>
        [BasicAuthentication]
        public Dictionary<Guid, QueueState> Get()
        {
            return QueueResults;
        }

        // GET api/<controller>/5
        [BasicAuthentication]
        public HttpResponseMessage Get(Guid id)
        {
            //2 design options-- query the queue or query the side effect of the action.

            IMonitoringApi monitor = JobStorage.Current.GetMonitoringApi();

            JobDetailsDto dto = monitor.JobDetails(QueueMap[id]);

            //if (QueueResults.ContainsKey(id) && QueueResults[id]!=null && QueueResults[id].Url!="")
            if (dto.History.Any(x => x.StateName == "Succeeded"))
            {
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.SeeOther);
                message.Headers.Location = new Uri(QueueResults[id].Url);
                return message;
            }
            else
            {
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
                message.Content = new StringContent("Not ready yet, try again in a few seconds.");
                return message;
            }
        }

        // POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}
        //
        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //    //??
        //}

        // DELETE api/<controller>/5
        [BasicAuthentication]
        public void Delete(Guid id)
        {
            BackgroundJob.Delete(QueueMap[id]);
        }
    }

}
