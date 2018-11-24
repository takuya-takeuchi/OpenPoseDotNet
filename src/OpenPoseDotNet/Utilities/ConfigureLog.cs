using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static class ConfigureLog
    {

        #region Properties

        public static LogMode[] LogModes
        {
            get
            {
                var ret = Native.op_ConfigureLog_getLogModes();
                using (var vector = new StdVector<LogMode>(ret))
                    return vector.ToArray();
            }
            set
            {
                using (var vector = new StdVector<LogMode>(value ?? new LogMode[0]))
                    Native.op_ConfigureLog_setLogModes(vector.NativePtr);
            }
        }

        public static Priority Priority
        {
            get => Native.op_ConfigureLog_getPriorityThreshold();
            set => Native.op_ConfigureLog_setPriorityThreshold(value);
        }

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Priority op_ConfigureLog_getPriorityThreshold();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_ConfigureLog_getLogModes();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_ConfigureLog_setPriorityThreshold(Priority priorityThreshold);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_ConfigureLog_setLogModes(IntPtr loggingModes);

        }

    }

}
