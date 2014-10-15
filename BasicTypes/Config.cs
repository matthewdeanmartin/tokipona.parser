using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
    public class Config
    {
        public int UpToVersion { get; set; } //oldest | mani, pan... | kipisi ...| ... pu |
        public bool IncludeApocrypha { get; set; } //apeja, maljuno
        public bool TemporalLon { get; set; } // lon tenpo suno ni vs tenpo suno ni la
        public bool AllowUnpunctuated { get; set; } // # numbers, ", " prep, "X" foreign, etc.
        public bool EmbeddedPrepositionalPhrasesRequirePi { get; set; } //e.g. kule pi lon luka palisa li ...
        public string CalendarType { get; set; }
        public string NumberType { get; set; }
    }
}
