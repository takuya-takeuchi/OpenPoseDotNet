using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_CustomDatum_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_CustomDatum_delete(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_CustomDatum_get_data(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_CustomDatum_set_data(IntPtr datum, IntPtr data);

    }

}