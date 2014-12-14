using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicTypes.Globalization
{
    public class UseCulture:IDisposable
    {
        readonly CultureInfo revert;
        readonly CultureInfo uiRevert;
        public UseCulture()
        {
            revert = Thread.CurrentThread.CurrentCulture;
            uiRevert = Thread.CurrentThread.CurrentUICulture;

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
        }

        public UseCulture(CultureInfo culture)
        {
            revert = Thread.CurrentThread.CurrentCulture;
            uiRevert = Thread.CurrentThread.CurrentUICulture;

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = revert;
            Thread.CurrentThread.CurrentUICulture = uiRevert;
        }
    }
}
