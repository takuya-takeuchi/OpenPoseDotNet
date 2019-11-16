using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet.Tests
{

    [TestClass]
    public class OpenPoseTest
    {

        [TestMethod]
        public void DebugLog()
        {
            const string message = nameof(this.DebugLog);
            const string function = nameof(this.DebugLog);
            const string file = "OpenPoseTest.cs";

            foreach (var priority in Enum.GetValues(typeof(Priority)).Cast<Priority>())
                OpenPose.LogIfDebug($"{message}", priority, -1, function, file);
        }

        [TestMethod]
        public void Error()
        {
            const string message = nameof(this.Error);
            const string function = nameof(this.Error);
            const string file = "OpenPoseTest.cs";

            OpenPose.Error($"{message}", -1, function, file);
        }

        [TestMethod]
        public void Log()
        {
            const string message = nameof(this.Log);
            const string function = nameof(this.Log);
            const string file = "OpenPoseTest.cs";

            foreach (var priority in Enum.GetValues(typeof(Priority)).Cast<Priority>())
                OpenPose.Log($"{message}", priority, -1, function, file);
        }

    }

}
