using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Globalization
{
    [TestFixture]
    public class TpCultureTest
    {
        [Test]
        public void Test()
        {
            
            try
            {
                // Create a CultureAndRegionInfoBuilder object named "x-en-US-sample".
                Console.WriteLine("Create and explore the CultureAndRegionInfoBuilder...\n");
                
                // Populate the new CultureAndRegionInfoBuilder object with culture information.
                CultureAndRegionInfoBuilder cib = TpCultureFactory.CreateTpCulture();

                // Display some of the properties of the CultureAndRegionInfoBuilder object.
                Console.WriteLine("CultureName:. . . . . . . . . . {0}", cib.CultureName);
                Console.WriteLine("CultureEnglishName: . . . . . . {0}", cib.CultureEnglishName);
                Console.WriteLine("CultureNativeName:. . . . . . . {0}", cib.CultureNativeName);
                Console.WriteLine("GeoId:. . . . . . . . . . . . . {0}", cib.GeoId);
                Console.WriteLine("IsMetric: . . . . . . . . . . . {0}", cib.IsMetric);
                Console.WriteLine("ISOCurrencySymbol:. . . . . . . {0}", cib.ISOCurrencySymbol);
                Console.WriteLine("RegionEnglishName:. . . . . . . {0}", cib.RegionEnglishName);
                Console.WriteLine("RegionName: . . . . . . . . . . {0}", cib.RegionName);
                Console.WriteLine("RegionNativeName: . . . . . . . {0}", cib.RegionNativeName);
                Console.WriteLine("ThreeLetterISOLanguageName: . . {0}", cib.ThreeLetterISOLanguageName);
                Console.WriteLine("ThreeLetterISORegionName: . . . {0}", cib.ThreeLetterISORegionName);
                Console.WriteLine("ThreeLetterWindowsLanguageName: {0}", cib.ThreeLetterWindowsLanguageName);
                Console.WriteLine("ThreeLetterWindowsRegionName: . {0}", cib.ThreeLetterWindowsRegionName);
                Console.WriteLine("TwoLetterISOLanguageName: . . . {0}", cib.TwoLetterISOLanguageName);
                Console.WriteLine("TwoLetterISORegionName: . . . . {0}", cib.TwoLetterISORegionName);
                Console.WriteLine();

                // Register the custom culture.
                Console.WriteLine("Register the custom culture...");
                TpCultureFactory.Register(cib);

                // Display some of the properties of the custom culture.
                Console.WriteLine("Create and explore the custom culture...\n");
                CultureInfo ci = new CultureInfo("x-tp");

                Console.WriteLine("Name: . . . . . . . . . . . . . {0}", ci.Name);
                Console.WriteLine("EnglishName:. . . . . . . . . . {0}", ci.EnglishName);
                Console.WriteLine("NativeName: . . . . . . . . . . {0}", ci.NativeName);
                Console.WriteLine("TwoLetterISOLanguageName: . . . {0}", ci.TwoLetterISOLanguageName);
                Console.WriteLine("ThreeLetterISOLanguageName: . . {0}", ci.ThreeLetterISOLanguageName);
                Console.WriteLine("ThreeLetterWindowsLanguageName: {0}", ci.ThreeLetterWindowsLanguageName);

                Console.WriteLine("\nNote:\n" +
                    "Use the example in the Unregister method topic to remove the custom culture.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
}
