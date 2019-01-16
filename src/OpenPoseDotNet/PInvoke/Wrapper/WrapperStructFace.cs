using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_wrapperStructFace_new(bool enable,
                                                             IntPtr netInputSize,
                                                             RenderMode renderMode,
                                                             float alphaKeyPoint,
                                                             float alphaHeatMap,
                                                             float renderThreshold);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_wrapperStructFace_delete(IntPtr face);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_wrapperStructFace_get_enable(IntPtr face);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_wrapperStructFace_set_enable(IntPtr face, bool enable);

    }

}