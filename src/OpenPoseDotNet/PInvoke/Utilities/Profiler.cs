using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ulong op_Profiler_get_DEFAULT_X();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_Profiler_set_DEFAULT_X(ulong value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_Profiler_setDefaultX(ulong defaultX);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_Profiler_timerInit(int line, byte[] function, byte[] file);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_Profiler_timerEnd(byte[] key);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_Profiler_printAveragedTimeMsOnIterationX(byte[] key,
                                                                              int line,
                                                                              byte[] function,
                                                                              byte[] file,
                                                                              ulong x);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_Profiler_printAveragedTimeMsEveryXIterations(byte[] key,
                                                                                  int line,
                                                                                  byte[] function,
                                                                                  byte[] file,
                                                                                  ulong x);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_Profiler_profileGpuMemory(int line,
                                                               byte[] function,
                                                               byte[] file);

    }

}
