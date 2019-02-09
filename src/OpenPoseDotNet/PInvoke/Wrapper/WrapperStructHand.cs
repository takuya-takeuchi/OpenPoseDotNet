using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_wrapperStructHand_new(bool enable,
                                                             Detector detector,
                                                             IntPtr netInputSize,
                                                             int scalesNumber,
                                                             float scaleRange,
                                                             RenderMode renderMode,
                                                             float alphaKeyPoint,
                                                             float alphaHeatMap,
                                                             float renderThreshold);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapperStructHand_delete(IntPtr hand);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_wrapperStructHand_get_enable(IntPtr hand);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapperStructHand_set_enable(IntPtr hand, bool enable);

    }

}