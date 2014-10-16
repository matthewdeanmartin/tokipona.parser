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

        public static Particle ante = new Particle("+ante");//Else can't tell what sort.
        public static Particle Blank = new Particle(" ");
    }
}
