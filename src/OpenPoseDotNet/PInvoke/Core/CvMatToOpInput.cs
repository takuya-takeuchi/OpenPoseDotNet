using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{
    
    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_CvMatToOpInput_new(PoseModel poseModel);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_core_CvMatToOpInput_delete(IntPtr extractor);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_CvMatToOpInput_createArray(IntPtr output,
                                                                       IntPtr cvInputData,
                                                                       IntPtr scaleInputToNetInputs,
                                                                       IntPtr netInputSizes);

    }

}
