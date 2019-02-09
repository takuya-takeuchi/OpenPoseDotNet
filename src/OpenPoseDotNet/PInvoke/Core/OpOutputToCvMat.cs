using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_OpOutputToCvMat_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_core_OpOutputToCvMat_delete(IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_OpOutputToCvMat_formatToCvMat(IntPtr mat, IntPtr outputData);

    }

}
