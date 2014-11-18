using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Handlers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Text;
using System.Net;

namespace TokiPonaApi.Filters
{
    public class ForceHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
#if RELEASE
            try
            {
#endif   
            var request = actionContext.Request;

            if (request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                const string html = "<p>Https is required</p>";

                if (request.Method.Method == "GET")
                {
                    actionContext.Response = request.CreateResponse(HttpStatusCode.Found);
                    actionContext.Response.Content = new StringContent(html, Encoding.UTF8, "text/html");

                    UriBuilder httpsNewUri = new UriBuilder(request.RequestUri);
                    httpsNewUri.Scheme = Uri.UriSchemeHttps;
                    httpsNewUri.Port = 443;

                    actionContext.Response.Headers.Location = httpsNewUri.Uri;
                }
                else
                {
                    actionContext.Response = request.CreateResponse(HttpStatusCode.NotFound);
                    actionContext.Response.Content = new StringContent(html, Encoding.UTF8, "text/html");
                }
            }
#if RELEASE
            }
            catch (Exception ex)
            {
                Tracing.Err.TraceEvent(TraceEventType.Error, 0, ex.ToString());
                if (ConfigUtil.DiagnosticsMode)
                {
                    //For use on Test Server
                    throw;
                }
                throw;
            }
#endif 
        }
    }
}