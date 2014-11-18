using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokiPonaApi.Filters;
using TokiPonaApi.Controllers;

namespace TokiPonaApi.Controllers
{
    public class HelpRelationsController : BaseApiController
    {
        /// <summary>
        /// This is a HAL thing-- the API documents itself via so called rel-links.
        /// </summary>
        [BasicAuthentication]
        public HttpResponseMessage Get(string rel)
        {
            //Essentially not implemented.
            return Request.CreateResponse(HttpStatusCode.OK, rel);
        }
    }
}
