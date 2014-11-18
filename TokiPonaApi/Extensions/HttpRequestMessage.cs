using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace TokiPonaApi
{
    public static class HttpRequestMessageExtensions
    {
       public static bool IsLocal(this HttpRequestMessage request)
       {
          var localFlag = request.Properties["MS_IsLocal"] as Lazy<bool>;
          return localFlag != null && localFlag.Value;
       }
    }
}