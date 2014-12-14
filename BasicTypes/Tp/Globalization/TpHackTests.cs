using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Globalization
{
    [TestFixture]
    public class TpHackTests
    {

        [Test]
        public void CurrentThread()
        {
            CultureInfo revert = Thread.CurrentThread.CurrentCulture;
            CultureInfo uiRevert = Thread.CurrentThread.CurrentUICulture;
            foreach (CultureInfo ci in new []{revert,uiRevert})
            {
                Console.Write("{0,-7}", ci.Name);
                Console.Write(" {0,-3}", ci.TwoLetterISOLanguageName);
                Console.Write(" {0,-3}", ci.ThreeLetterISOLanguageName);
                Console.Write(" {0,-3}", ci.ThreeLetterWindowsLanguageName);
                Console.Write(" {0,-40}", ci.DisplayName);
                Console.WriteLine(" {0,-40}", ci.EnglishName);
            }
        }

        [Test]
        public void AllCultures()
        {
            Console.WriteLine("CULTURE ISO ISO WIN DISPLAYNAME                              ENGLISHNAME");
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures).Where(x => x.ThreeLetterISOLanguageName.Contains("t")))
            {
                Console.Write("{0,-7}", ci.Name);
                Console.Write(" {0,-3}", ci.TwoLetterISOLanguageName);
                Console.Write(" {0,-3}", ci.ThreeLetterISOLanguageName);
                Console.Write(" {0,-3}", ci.ThreeLetterWindowsLanguageName);
                Console.Write(" {0,-40}", ci.DisplayName);
                Console.WriteLine(" {0,-40}", ci.EnglishName);
            }
        }

        [Test]
        public void TpHack()
        {
           

            CultureInfo revert= Thread.CurrentThread.CurrentCulture;
            CultureInfo uiRevert= Thread.CurrentThread.CurrentUICulture;

            try
            {
                CultureInfo c = CultureInfo.InvariantCulture;// new CultureInfo("tp");
                Thread.CurrentThread.CurrentCulture = c;
                Thread.CurrentThread.CurrentUICulture = c;
                Word s = new Word("seme");
                Console.WriteLine(s.ToString("g", CultureInfo.CurrentCulture));
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = revert;
                Thread.CurrentThread.CurrentUICulture = uiRevert;
            }
        }
    }
}
