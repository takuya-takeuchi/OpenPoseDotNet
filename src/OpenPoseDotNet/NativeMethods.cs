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

        /// <summary>
        /// Native library file name.
        /// If Linux, it will be converted to  libOpenPoseDotNetNative.so
        /// If MacOSX, it will be converted to  libOpenPoseDotNetNative.dylib
        /// If Windows, it will be available after call LoadLibrary.
        /// And this file name must not contain period. If it does,
        /// CLR does not add extension (.dll) and CLR fails to load library
        /// </summary>
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