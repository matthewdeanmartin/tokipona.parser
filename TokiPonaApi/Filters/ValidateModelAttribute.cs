using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace TokiPonaApi.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
#if RELEASE
            try
            {
#endif
            if (actionContext.ModelState.IsValid == false)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);
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