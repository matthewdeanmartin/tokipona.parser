using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Filters;

namespace TokiPonaApi.Filters
{
    public class GenericExceptionFilterAttribute : ExceptionFilterAttribute
    {
            public override void OnException(HttpActionExecutedContext context)
            {
                //if (context.Exception is NotImplementedException)
                //{
                //    context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
                //}
                Tracing.Err.TraceEvent(TraceEventType.Error, 0, "GenericExceptionFilterAttribute captured this error : " + context.Exception);

                base.OnException(context);
            }

        
    }
}