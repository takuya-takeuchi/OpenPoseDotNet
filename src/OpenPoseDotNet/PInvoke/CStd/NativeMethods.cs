using System;
using System.Runtime.InteropServices;
using System.Security;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [SuppressUnmanagedCodeSecurity]
        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr cstd_memcpy(IntPtr dest, IntPtr src, int count);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern unsafe IntPtr cstd_memcpy(byte* dest, IntPtr src, int count);

    }

}