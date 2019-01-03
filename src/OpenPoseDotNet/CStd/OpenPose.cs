using System;
using System.Runtime.InteropServices;
using System.Security;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        internal sealed partial class Native
        {

            [SuppressUnmanagedCodeSecurity]
            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr cstd_memcpy(IntPtr dest, IntPtr src, int count);

        }

    }

}