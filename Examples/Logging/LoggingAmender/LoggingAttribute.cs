using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afterthought;

namespace LoggingAmender
{
    /// <summary>
    /// Attribute used on a class to specify that a given class should be logged 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false,  Inherited = true)]
    public class LoggingAttribute : AmendmentAttribute
    {
        /// <summary>
        /// Logging Attribute. 
        /// </summary>
        public LoggingAttribute() : base(typeof(LoggingAmender<>))
        {
        }
    }
}
