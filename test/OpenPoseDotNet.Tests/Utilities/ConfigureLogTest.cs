using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet.Tests
{

    [TestClass]
    public class ConfigureLogTest
    {

        [TestMethod]
        public void LogModes()
        {
            var tmp = new [] { LogMode.All };
            ConfigureLog.LogModes = tmp;
            var ret = ConfigureLog.LogModes;
            Assert.IsTrue(tmp.Length == ret.Length && tmp[0] == ret[0]);

            tmp = new[] { LogMode.FileLogging };
            ConfigureLog.LogModes = tmp;
            ret = ConfigureLog.LogModes;
            Assert.IsTrue(tmp.Length == ret.Length && tmp[0] == ret[0]);

            tmp = new[] { LogMode.StdCout };
            ConfigureLog.LogModes = tmp;
            ret = ConfigureLog.LogModes;
            Assert.IsTrue(tmp.Length == ret.Length && tmp[0] == ret[0]);
        }

        [TestMethod]
        public void Priority()
        {
            foreach (var priority in Enum.GetValues(typeof(Priority)).Cast<Priority>())
            {
                ConfigureLog.PriorityThreshold = priority;
                Assert.IsTrue(priority == ConfigureLog.PriorityThreshold);
            }
        }

    }

}
