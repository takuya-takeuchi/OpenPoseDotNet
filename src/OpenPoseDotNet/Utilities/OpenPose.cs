using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        #region Methods

        public static void DebugLog(string message, Priority priority = Priority.Max, int line = -1, string function = "", string file = "")
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            var messageBytes = Encoding.UTF8.GetBytes(message);
            var functionBytes = Encoding.UTF8.GetBytes(function ?? "");
            var fileBytes = Encoding.UTF8.GetBytes(file ?? "");

            Native.op_dLog(messageBytes, priority, line, functionBytes, fileBytes);
        }

        public static void Error(string message, int line = -1, string function = "", string file = "")
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            var messageBytes = Encoding.UTF8.GetBytes(message);
            var functionBytes = Encoding.UTF8.GetBytes(function ?? "");
            var fileBytes = Encoding.UTF8.GetBytes(file ?? "");

            Native.op_error(messageBytes, line, functionBytes, fileBytes);
        }

        public static void Log(string message, Priority priority = Priority.Max, int line = -1, string function = "", string file = "")
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            var messageBytes = Encoding.UTF8.GetBytes(message);
            var functionBytes = Encoding.UTF8.GetBytes(function ?? "");
            var fileBytes = Encoding.UTF8.GetBytes(file ?? "");

            Native.op_log(messageBytes, priority, line, functionBytes, fileBytes);
        }

        #endregion

        internal sealed partial class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_dLog(byte[] message,
                                              Priority priority,
                                              int line,
                                              byte[] function,
                                              byte[] file);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_error(byte[] message,
                                               int line,
                                               byte[] function,
                                               byte[] file);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_log(byte[] message,
                                             Priority priority,
                                             int line,
                                             byte[] function,
                                             byte[] file);

        }

    }

}
