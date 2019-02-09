using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern Priority op_ConfigureLog_getPriorityThreshold();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_ConfigureLog_getLogModes();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_ConfigureLog_setPriorityThreshold(Priority priorityThreshold);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_ConfigureLog_setLogModes(IntPtr loggingModes);

    }

}
