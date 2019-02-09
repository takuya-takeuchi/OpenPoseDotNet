using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_wrapperStructFace_new(bool enable,
                                                             Detector detector,
                                                             IntPtr netInputSize,
                                                             RenderMode renderMode,
                                                             float alphaKeyPoint,
                                                             float alphaHeatMap,
                                                             float renderThreshold);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapperStructFace_delete(IntPtr face);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_wrapperStructFace_get_enable(IntPtr face);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapperStructFace_set_enable(IntPtr face, bool enable);

    }

}