using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenPoseDotNet
{

    internal static partial class NativeMethods
    {

        #region P/Invoke

        [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        private static extern IntPtr LoadLibrary(string dllPath);

        #endregion

        #region Fields

        internal const string NativeLibrary = "OpenPoseDotNetNative";

        internal const CallingConvention CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl;

        private static readonly IDictionary<string, IntPtr> LoadedLibraries = new Dictionary<string, IntPtr>();

        #endregion

        #region Constructors

        static NativeMethods()
        {
            if (!IsWindows())
                return;

            var fileName = $"{NativeLibrary}.dll";
            if (LoadedLibraries.ContainsKey(fileName))
                return;

            var ret = LoadLibrary(fileName);
            if (ret != IntPtr.Zero)
            {
                LoadedLibraries.Add(fileName, ret);
            }
        }

        #endregion

        #region Properties

        public static bool IsWindows()
        {
            return Environment.OSVersion.Platform == PlatformID.Win32NT ||
                   Environment.OSVersion.Platform == PlatformID.Win32S ||
                   Environment.OSVersion.Platform == PlatformID.Win32Windows ||
                   Environment.OSVersion.Platform == PlatformID.WinCE;
        }

        #endregion

    }

}