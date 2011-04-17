using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoggingAmender.UnitTest.Target;

namespace LoggingAmender.UnitTest
{
    [TestClass]
    public class LoggerTest
    {
        /// <summary>
        /// Test whether the log written for the ctor
        /// </summary>
        [TestMethod]
        public void TestLoggingOnCtor()
        {
            Logger.Reset();
            //make sure the logger is at count == 0
            Assert.AreEqual(Logger.Log.Count, 0);
            //Create a new beer. yay
            var b = new Beer();

            //make sure the beer is alright
            Assert.IsTrue(b.Full);
            Assert.IsFalse(b.Dropped);
            Assert.IsFalse(b.Empty);

            //The number of log messages must be ok
            Assert.AreEqual(Logger.Log.Count, 2);
            //the log must contain correct info
            Assert.AreEqual("Before LoggingAmender.Logger..ctor()", Logger.Log[0]);
            Assert.AreEqual("After LoggingAmender.Logger..ctor()", Logger.Log[1]);
        }

        /// <summary>
        /// Test whether log works on methods
        /// </summary>
        [TestMethod]
        public void TestLoggingOnMethod()
        {
            var b = new Beer();

            //reset logger
            Logger.Reset();
            //make sure the logger is at count == 0
            Assert.AreEqual(Logger.Log.Count, 0);

            //drink beer :)
            b.Drink();

            //make sure the beer is alright
            Assert.IsTrue(b.Empty);
            Assert.IsFalse(b.Full);
            Assert.IsFalse(b.Dropped);

            //The number of log messages must be ok
            Assert.AreEqual(Logger.Log.Count, 2);
            //the log must contain correct info
            Assert.AreEqual("Before LoggingAmender.Logger.Drink()", Logger.Log[0]);
            Assert.AreEqual("After LoggingAmender.Logger.Drink()", Logger.Log[1]);
        }

        /// <summary>
        /// Test whether log works on methods with arguments
        /// </summary>
        [TestMethod]
        public void TestLoggingOnMethodWithArguments()
        {
            var b = new Beer();

            //reset logger
            Logger.Reset();
            //make sure the logger is at count == 0
            Assert.AreEqual(Logger.Log.Count, 0);

            //drink beer :)
            b.Drop(false);

            //make sure the beer is alright
            Assert.IsTrue(b.Empty);
            Assert.IsFalse(b.Full);
            Assert.IsTrue(b.Dropped);

            //The number of log messages must be ok
            Assert.AreEqual(Logger.Log.Count, 2);
            //the log must contain correct info
            Assert.AreEqual("Before LoggingAmender.Logger.Drop(false)", Logger.Log[0]);
            Assert.AreEqual("After LoggingAmender.Logger.Drop(false)", Logger.Log[1]);
        }
    }
}
