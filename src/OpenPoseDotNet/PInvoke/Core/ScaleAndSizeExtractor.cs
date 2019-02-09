using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_ScaleAndSizeExtractor_new(IntPtr netInputResolution,
                                                                      IntPtr outputResolution,
                                                                      int scaleNumber,
                                                                      double scaleGap);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_core_ScaleAndSizeExtractor_delete(IntPtr extractor);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_core_ScaleAndSizeExtractor_extract(IntPtr extractor,
                                                                        IntPtr inputResolution,
                                                                        out IntPtr vector,
                                                                        out IntPtr points,
                                                                        out double value,
                                                                        out int x,
                                                                        out int y);

    }

}
