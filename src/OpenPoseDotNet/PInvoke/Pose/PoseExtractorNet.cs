using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_PoseExtractorNet_initializationOnThread(IntPtr net);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_PoseExtractorNet_getPoseKeypoints(IntPtr net);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern float op_PoseExtractorNet_getScaleNetToOutput(IntPtr net);

    }

}