using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal static partial class NativeMethods
    {

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_wrapperStructExtra_new(bool reconstruct3d,
                                                              int minViews3d,
                                                              bool identification,
                                                              int tracking,
                                                              int ikThreads);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_wrapperStructExtra_delete(IntPtr face);

    }

}