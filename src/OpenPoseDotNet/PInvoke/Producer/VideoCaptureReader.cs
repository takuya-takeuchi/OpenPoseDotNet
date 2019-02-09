using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{
    
    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_VideoCaptureReader_get(IntPtr reader, int capProperty);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_VideoCaptureReader_isOpened(IntPtr reader);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_VideoCaptureReader_release(IntPtr reader);

    }

}