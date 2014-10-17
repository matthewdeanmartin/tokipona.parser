using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BasicTypes
{
    //public sealed class Singleton
    //{
    //    private static readonly Singleton instance = new Singleton();
    //    public static Singleton Instance { get { return instance; } }
    //
    //    static Singleton() { }
    //    private Singleton() { }
    //}

    //Every decision that has never by completely made
    public sealed class Config
    {
        private static readonly Config instance = new Config();

        public static Config Instance { get { return instance; } }

        private Config()
        {
        }
        static Config()
        {
            instance = Default;
            Regex.CacheSize = 50;
        }
        public int UpToVersion { get; set; } //oldest (1)| mani, pan, esun... (2)| kipisi,monsuta ...(3)| ... pu (4)|
        public bool StrictPos { get; set; } //e.g. vt must have e phrase, adj must follow head word, etc.
        public bool ObligatoryPlural { get; set; } //e.g. jan tu li jan mute.
        public bool ObligatoryGender { get; set; } //e.g. meli li lukin e sama meli. (ona meli, etc.)
        public bool IncludeApocrypha { get; set; } //apeja, maljuno
        public bool PreferAle { get; set; } // (otherwise ali)
        public bool TemporalLon { get; set; } // lon tenpo suno ni vs tenpo suno ni la
        public bool AllowUnpunctuated { get; set; } // # numbers, ", " prep, "X" foreign, etc. Destroys one's ability to parse.
        public bool EmbeddedPrepositionalPhrasesRequirePi { get; set; } //e.g. kule pi lon luka palisa li ...
        public bool ColorsAreOnlyAdjectives { get; set; } //ni li laso vs ni li kule laso (black and white are explicitly nouns)
        public bool LiPiIsValid { get; set; } //jan li pi ma Tosi
        public string CalendarType { get; set; }
        public string NumberType { get; set; } //poman, stupid, half-stupid, body
        public bool ThrowOnSyntaxError { get; set; }
        public string WritingSystem { get; set; }

        public static Config Default
        {
            get
            {
                return new Config()
                {
                    UpToVersion = 999,
                    StrictPos = false,
                    ObligatoryPlural = false,
                    ObligatoryGender = false,
                    IncludeApocrypha = false,
                    PreferAle = true,
                    TemporalLon = false,
                    AllowUnpunctuated = true,
                    EmbeddedPrepositionalPhrasesRequirePi = false,
                    ColorsAreOnlyAdjectives = false,
                    LiPiIsValid = false,
                    CalendarType = "Compact",
                    NumberType = "Body",
                    WritingSystem = "Roman",
                    ThrowOnSyntaxError = true
                };
            }
        }

//set to tp/en/eo/etc, e.g. ma tomo "New York" vs ma tomo Nujoku
    }
}
