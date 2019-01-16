using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_core_ScaleAndSizeExtractor_new(IntPtr netInputResolution,
                                                                      IntPtr outputResolution,
                                                                      int scaleNumber,
                                                                      double scaleGap);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_core_ScaleAndSizeExtractor_delete(IntPtr extractor);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_core_ScaleAndSizeExtractor_extract(IntPtr extractor,
                                                                        IntPtr inputResolution,
                                                                        out IntPtr vector,
                                                                        out IntPtr points,
                                                                        out double value,
                                                                        out int x,
                                                                        out int y);

    }

}
