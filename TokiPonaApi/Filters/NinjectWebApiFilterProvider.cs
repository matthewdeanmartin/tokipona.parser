using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using Ninject;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace TokiPonaApi.Filters
{
    public class NinjectWebApiFilterProvider : IFilterProvider
    {
        private readonly IKernel _kernel;
        public NinjectWebApiFilterProvider(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
#if RELEASE
            try
            {
#endif
            var controllerFilters = actionDescriptor.ControllerDescriptor.GetFilters().Select(instance => new FilterInfo(instance, FilterScope.Controller));
            var actionFilters = actionDescriptor.GetFilters().Select(instance => new FilterInfo(instance, FilterScope.Action));

            var filters = controllerFilters.Concat(actionFilters);

            var filterInfos = filters as FilterInfo[] ?? filters.ToArray();
            foreach (var f in filterInfos)
            {
                // Injection
                _kernel.Inject(f.Instance);
            }

            return filterInfos;
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