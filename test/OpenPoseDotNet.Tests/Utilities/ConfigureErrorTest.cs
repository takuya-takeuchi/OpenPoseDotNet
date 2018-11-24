using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet.Tests
{

    [TestClass]
    public class ConfigureErrorTest
    {

        [TestMethod]
        public void ErrorModes()
        {
            var tmp = new [] { ErrorMode.All };
            ConfigureError.ErrorModes = tmp;
            var ret = ConfigureError.ErrorModes;
            Assert.IsTrue(tmp.Length == ret.Length && tmp[0] == ret[0]);

            tmp = new[] { ErrorMode.FileLogging };
            ConfigureError.ErrorModes = tmp;
            ret = ConfigureError.ErrorModes;
            Assert.IsTrue(tmp.Length == ret.Length && tmp[0] == ret[0]);

            tmp = new[] { ErrorMode.StdCerr };
            ConfigureError.ErrorModes = tmp;
            ret = ConfigureError.ErrorModes;
            Assert.IsTrue(tmp.Length == ret.Length && tmp[0] == ret[0]);

            tmp = new[] { ErrorMode.StdRuntimeError };
            ConfigureError.ErrorModes = tmp;
            ret = ConfigureError.ErrorModes;
            Assert.IsTrue(tmp.Length == ret.Length && tmp[0] == ret[0]);
        }

    }

}
