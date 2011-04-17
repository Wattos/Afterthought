using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logging
{
    /// <summary>
    /// Simple logger class. 
    /// </summary>
    public class Logger
    {
        public static List<String> Log { get; private set;}

        /// <summary>
        /// static constructor
        /// </summary>
        static Logger() {
            Log = new List<string>();
        }

        /// <summary>
        /// Simple logging
        /// </summary>
        public static object[] WriteLine<T>(T instance, string name, object[] ps)
        {
            InternalWriteLine(instance, name, ps);

            //returning null tells Afterthought not to modify the input parameters
            return null;
        }

        /// <summary>
        /// Simple logging
        /// </summary>
        public static void WriteLineVoid<T>(T instance, string name, object[] ps)
        {
            InternalWriteLine(instance, name, ps);
        }

        /// <summary>
        /// The implementation of writeline
        /// </summary>
        private static void InternalWriteLine<T>(T instance, string name, object[] ps)
        {
            var stringBuilder = new StringBuilder();

            //get function name and class name
            stringBuilder.Append(String.Format("{0}.{1}(", instance != null ? instance.GetType().FullName : "static", name));
            bool first = true;
            //add parameters
            foreach (var p in ps)
            {
                if (!first)
                {
                    stringBuilder.Append(",");
                    first = false;
                }
                stringBuilder.Append(p != null ? p.ToString() : "NULL");
            }
            stringBuilder.Append(")");
            Log.Add(stringBuilder.ToString());

        }
    }
}
