using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_CvMatToOpOutput_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_core_CvMatToOpOutput_delete(IntPtr extractor);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_CvMatToOpOutput_createArray(IntPtr output,
                                                                        IntPtr cvInputData,
                                                                        double scaleInputToOutput,
                                                                        IntPtr outputResolution);
    }

}
