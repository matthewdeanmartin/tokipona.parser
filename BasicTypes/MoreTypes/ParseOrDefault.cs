using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.MoreTypes
{
    public class ParseOrDefault
    {
        //http://stackoverflow.com/questions/2961656/generic-tryparse

        //Turns the common bool TryParse(string,out T) into a function that returns nullable types.
        public static T? TryParse<T>(string value, TryParseHandler<T> handler) where T : struct
        {
            if (String.IsNullOrEmpty(value))
                return null;
            T result;
            if (handler(value, out result))
                return result;
            //Trace.TraceWarning("Invalid value '{0}'", value);
            return null;
        }

        public delegate bool TryParseHandler<T>(string value, out T result);


    }
}
