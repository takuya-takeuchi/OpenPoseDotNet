using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{
    
    internal static partial class NativeMethods
    {

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_core_CvMatToOpInput_new(PoseModel poseModel);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_core_CvMatToOpInput_delete(IntPtr extractor);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_core_CvMatToOpInput_createArray(IntPtr output,
                                                                       IntPtr cvInputData,
                                                                       IntPtr scaleInputToNetInputs,
                                                                       IntPtr netInputSizes);

    }

}
