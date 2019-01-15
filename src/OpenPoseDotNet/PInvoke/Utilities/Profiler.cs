using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal static partial class NativeMethods
    {

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern ulong op_Profiler_get_DEFAULT_X();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_Profiler_set_DEFAULT_X(ulong value);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_Profiler_setDefaultX(ulong defaultX);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_Profiler_timerInit(int line, byte[] function, byte[] file);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_Profiler_timerEnd(byte[] key);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_Profiler_printAveragedTimeMsOnIterationX(byte[] key,
                                                                              int line,
                                                                              byte[] function,
                                                                              byte[] file,
                                                                              ulong x);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_Profiler_printAveragedTimeMsEveryXIterations(byte[] key,
                                                                                  int line,
                                                                                  byte[] function,
                                                                                  byte[] file,
                                                                                  ulong x);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_Profiler_profileGpuMemory(int line,
                                                               byte[] function,
                                                               byte[] file);

    }

}
