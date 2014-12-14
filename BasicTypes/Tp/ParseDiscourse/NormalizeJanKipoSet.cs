using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polenter.Serialization.Advanced.Serializing;

namespace BasicTypes.ParseDiscourse
{
    public class NormalizeJanKipoSet
    {
        public static string Normalize(string text)
        {
            List<string> keepers= new List<string>();
            string[] lines= text.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if(line.StartsWith("*")) continue;
                int q;
                if(int.TryParse(line, out q)) continue;
                keepers.Add(line);
            }
            return string.Join("\n", keepers);
        }
    }
}
