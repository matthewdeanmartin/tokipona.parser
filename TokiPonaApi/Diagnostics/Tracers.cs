using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TokiPonaApi
{
    public static class Tracing
    {
        public static TraceSource Err = new TraceSource("err");
        public static TraceSource Sql = new TraceSource("sql");
        public static TraceSource Data = new TraceSource("data");
        public static TraceSource App = new TraceSource("app");
    }
}