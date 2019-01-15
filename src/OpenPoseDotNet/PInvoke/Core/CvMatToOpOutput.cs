using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal static partial class NativeMethods
    {

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_core_CvMatToOpOutput_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_core_CvMatToOpOutput_delete(IntPtr extractor);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_core_CvMatToOpOutput_createArray(IntPtr output,
                                                                        IntPtr cvInputData,
                                                                        double scaleInputToOutput,
                                                                        IntPtr outputResolution);
    }

}
