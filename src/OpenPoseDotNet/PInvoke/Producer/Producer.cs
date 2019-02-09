using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_Producer_get(IntPtr producer, int capProperty);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_Producer_setProducerFpsMode(IntPtr producer, ProducerFpsMode fpsMode);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_Producer_isOpened(IntPtr producer);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_Producer_release(IntPtr producer);

    }

}