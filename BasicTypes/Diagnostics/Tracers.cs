using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BasicTypes.Collections;

namespace BasicTypes.Diagnostics
{
    
    public static class Tracers
    {
        
        static Tracers()
        {
            SourceLevels singleSwitch = SourceLevels.Off;
            ConsoleTraceListener console = new ConsoleTraceListener();

            SourceSwitch stringifySwitch = new SourceSwitch("stringify", "Verbose");
            stringifySwitch.Level = singleSwitch;
            SourceSwitch parseSwitch = new SourceSwitch("parse", "Verbose");
            parseSwitch.Level = singleSwitch;
            SourceSwitch normalizeSwitch = new SourceSwitch("normalize", "Verbose");
            normalizeSwitch.Level = singleSwitch;

            Stringify = new TraceSource("stringify");
            Stringify.Switch = stringifySwitch;

            Parse = new TraceSource("parse");
            Parse.Switch = parseSwitch;

            Normalize = new TraceSource("normalize");
            Normalize.Switch = normalizeSwitch;

            Parse.Listeners.Add(console);
            Normalize.Listeners.Add(console);
            Stringify.Listeners.Add(console);
        }

        public static TraceSource Stringify;
        public static TraceSource Parse;
        public static TraceSource Normalize;
    }
}
