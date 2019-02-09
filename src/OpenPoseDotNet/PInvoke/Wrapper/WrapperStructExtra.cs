using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_wrapperStructExtra_new(bool reconstruct3d,
                                                              int minViews3d,
                                                              bool identification,
                                                              int tracking,
                                                              int ikThreads);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapperStructExtra_delete(IntPtr face);

    }

}