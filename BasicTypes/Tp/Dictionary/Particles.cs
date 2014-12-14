using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes
{
    public static class Particles
    {
        public static Particle o = new Particle("o");
        public static Particle la = new Particle("la");
        public static Particle li = new Particle("li");
        public static Particle e = new Particle("e");
        public static Particle en = new Particle("en");
        public static Particle pi = new Particle("pi");

        public static Particle anu = new Particle("anu");
        public static Particle taso = new Particle("taso");

        public static Particle ante = new Particle("ante");//Else can't tell what sort. This might *not* be a conjunction.

        public static Particle Blank = new Particle(" ", true);//Joins prepositional phrases. Otherwise, this is weird.
        public static string[] Prepositions {
            get { return new String[] {"kepeken", "tawa", "poka", "sama", "tan", "lon"}; }
        }

        public static string[] Conjunctions
        {
            get { return new String[] {"en", "anu", "taso" }; } //ante?
        }
    }
}
