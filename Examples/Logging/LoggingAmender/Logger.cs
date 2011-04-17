using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggingAmender
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
            Reset();
        }

        /// <summary>
        /// Reset the logger
        /// </summary>
        public static void Reset()
        {
            Log = new List<string>();
        }

        /// <summary>
        /// Simple logging
        /// </summary>
        public static object[] LogMethodBefore<T>(T instance, string name, object[] ps)
        {
            InternalWriteLine(instance, name, ps, "Before");

            //returning null tells Afterthought not to modify the input parameters
            return null;
        }

        /// <summary>
        /// Simple logging
        /// </summary>
        public static void LogMethodAfter<T>(T instance, string name, object[] ps)
        {
            InternalWriteLine(instance, name, ps, "After");
        }

        public static K LogGetPropertyAfter<T, K>(T instance, string propertyName, K returnValue)
        {
            InternalWriteLine(instance, propertyName, new object[] { }, "After");
            return returnValue;
        }

        public static void LogGetPropertyBefore<T>(T instance, string propertyName)
        {
            InternalWriteLine(instance, propertyName, new object[] { }, "Before");
        }

        public static K LogSetPropertyBefore<T,K>(T instance, string propertyName, K oldValue, K value)
        {
            InternalWriteLine(instance, propertyName, new object[] { value }, "Before");
            return value;
        }

        public static void LogSetPropertyAfter<T,K>(T instance, string propertyName, K oldValue, K value, K newValue)
        {
            InternalWriteLine(instance, propertyName, new object[] { value }, "After");
        }

        /// <summary>
        /// The implementation of writeline
        /// </summary>
        private static void InternalWriteLine<T>(T instance, string name, object[] ps, string prefix)
        {
            var stringBuilder = new StringBuilder();

            //get function name and class name
            stringBuilder.Append(String.Format("{0} {1}.{2}(", prefix, instance != null ? instance.GetType().FullName : "static", name));
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
