using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Diagnostics
{
    public static class Tracers
    {
        public static TraceSource Stringify = new TraceSource("stringify");
        public static TraceSource Parse = new TraceSource("parse");

    }
}
