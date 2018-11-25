using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static class Profiler
    {

        #region Properties

        public static ulong DefaultX
        {
            get => Native.op_Profiler_get_DEFAULT_X();
            set => Native.op_Profiler_set_DEFAULT_X(value);
        }

        #endregion

        #region Methods

        public static void PrintAveragedTimeMsEveryXIterations(string key, int line, string function, string file, ulong x)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (function == null)
                throw new ArgumentNullException(nameof(function));
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            var keyBytes = Encoding.UTF8.GetBytes(key);
            var functionBytes = Encoding.UTF8.GetBytes(function);
            var fileBytes = Encoding.UTF8.GetBytes(file);

            Native.op_Profiler_printAveragedTimeMsEveryXIterations(keyBytes, line, functionBytes, fileBytes, x);
        }

        public static void PrintAveragedTimeMsOnIterationX(string key, int line, string function, string file, ulong x)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (function == null)
                throw new ArgumentNullException(nameof(function));
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            var keyBytes = Encoding.UTF8.GetBytes(key);
            var functionBytes = Encoding.UTF8.GetBytes(function);
            var fileBytes = Encoding.UTF8.GetBytes(file);

            Native.op_Profiler_printAveragedTimeMsOnIterationX(keyBytes, line, functionBytes, fileBytes, x);
        }

        public static void ProfileGpuMemory(int line, string function, string file)
        {
            if (function == null)
                throw new ArgumentNullException(nameof(function));
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            var functionBytes = Encoding.UTF8.GetBytes(function);
            var fileBytes = Encoding.UTF8.GetBytes(file);

            Native.op_Profiler_profileGpuMemory(line, functionBytes, fileBytes);
        }

        public static void TimerEnd(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var keyBytes = Encoding.UTF8.GetBytes(key);
            Native.op_Profiler_timerEnd(keyBytes);
        }

        public static string TimerInit(int line, string function, string file)
        {
            if (function == null)
                throw new ArgumentNullException(nameof(function));
            if (file == null)
                throw new ArgumentNullException(nameof(file));
        
            var functionBytes = Encoding.UTF8.GetBytes(function);
            var fileBytes = Encoding.UTF8.GetBytes(file);

            var stdstr = Native.op_Profiler_timerInit(line, functionBytes, fileBytes);
            var ret =  StringHelper.FromStdString(stdstr);
            if (stdstr != IntPtr.Zero)
                OpenPose.Native.std_string_delete(stdstr);
            return ret;
        }

        public static void SetDefaultX(ulong defaultX)
        {
            Native.op_Profiler_setDefaultX(defaultX);
        }

        #endregion

        internal sealed class Native
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

}
