using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal static partial class NativeMethods
    {

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_wrapperStructHand_new(bool enable,
                                                             IntPtr netInputSize,
                                                             int scalesNumber,
                                                             float scaleRange,
                                                             bool tracking,
                                                             RenderMode renderMode,
                                                             float alphaKeyPoint,
                                                             float alphaHeatMap,
                                                             float renderThreshold);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_wrapperStructHand_delete(IntPtr hand);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_wrapperStructHand_get_enable(IntPtr hand);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_wrapperStructHand_set_enable(IntPtr hand, bool enable);

    }

}