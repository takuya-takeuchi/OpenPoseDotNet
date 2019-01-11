using System;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static class Profiler
    {

        #region Properties

        public static ulong DefaultX
        {
            get => NativeMethods.op_Profiler_get_DEFAULT_X();
            set => NativeMethods.op_Profiler_set_DEFAULT_X(value);
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

            NativeMethods.op_Profiler_printAveragedTimeMsEveryXIterations(keyBytes, line, functionBytes, fileBytes, x);
        }
        
        public static void PrintAveragedTimeMsOnIterationX(string key, int line, string function, string file)
        {
            PrintAveragedTimeMsOnIterationX(key, line, function, file, DefaultX);
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

            NativeMethods.op_Profiler_printAveragedTimeMsOnIterationX(keyBytes, line, functionBytes, fileBytes, x);
        }

        public static void ProfileGpuMemory(int line, string function, string file)
        {
            if (function == null)
                throw new ArgumentNullException(nameof(function));
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            var functionBytes = Encoding.UTF8.GetBytes(function);
            var fileBytes = Encoding.UTF8.GetBytes(file);

            NativeMethods.op_Profiler_profileGpuMemory(line, functionBytes, fileBytes);
        }

        public static void TimerEnd(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var keyBytes = Encoding.UTF8.GetBytes(key);
            NativeMethods.op_Profiler_timerEnd(keyBytes);
        }

        public static string TimerInit(int line, string function, string file)
        {
            if (function == null)
                throw new ArgumentNullException(nameof(function));
            if (file == null)
                throw new ArgumentNullException(nameof(file));
        
            var functionBytes = Encoding.UTF8.GetBytes(function);
            var fileBytes = Encoding.UTF8.GetBytes(file);

            var stdstr = NativeMethods.op_Profiler_timerInit(line, functionBytes, fileBytes);
            var ret =  StringHelper.FromStdString(stdstr, true);
            return ret;
        }

        public static void SetDefaultX(ulong defaultX)
        {
            NativeMethods.op_Profiler_setDefaultX(defaultX);
        }

        #endregion

    }

}
