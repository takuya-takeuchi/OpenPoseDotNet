using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_CameraParameterReader_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_CameraParameterReader_delete(IntPtr parameter);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern UInt64 op_CameraParameterReader_getNumberCameras(IntPtr parameter);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_CameraParameterReader_getUndistortImage(IntPtr parameter);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_CameraParameterReader_setUndistortImage(IntPtr parameter, bool undistortImage);

    }

}