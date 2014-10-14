using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace BasicTypes.Globalization
{
    public class TpCultureFactory
    {
        public static CultureAndRegionInfoBuilder CreateTpCulture()
        {
            CultureAndRegionInfoBuilder cib = new CultureAndRegionInfoBuilder("x-tp", CultureAndRegionModifiers.None);

            CultureInfo ci = new CultureInfo("en-US");

            cib.LoadDataFromCultureInfo(ci);

            // Populate the new CultureAndRegionInfoBuilder object with region information.
            RegionInfo ri = new RegionInfo("US");
            cib.LoadDataFromRegionInfo(ri);

            //cib.CultureName = "toki pona";
            cib.CultureEnglishName = "toki pona";
            cib.CultureNativeName = "toki pona";
            cib.CurrencyEnglishName = "mani";
            cib.CurrencyNativeName = "mani";
            cib.ISOCurrencySymbol = "mani";
            cib.RegionEnglishName = "Land of toki pona";
            //cib.RegionName = "ma pi toki pona";
            cib.RegionNativeName = "ma pi toki pona";
            cib.ThreeLetterISOLanguageName = "xtp";
            cib.ThreeLetterISORegionName = "XTP";
            cib.ThreeLetterISORegionName = "XTP";
            cib.ThreeLetterWindowsLanguageName = "XTP";
            cib.ThreeLetterWindowsRegionName = "XTP";
            cib.TwoLetterISOLanguageName = "tp";
            cib.TwoLetterISORegionName = "tp";
            return cib;
        }

        public static void Register(CultureAndRegionInfoBuilder cib)
        {
            cib.Register();
        }
    }
}
