using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal static partial class NativeMethods
    {

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_PoseGpuRenderer_new(PoseModel poseModel,
                                                           IntPtr poseExtractorNet,
                                                           float renderThreshold,
                                                           bool blendOriginalFrame,
                                                           float alphaKeyPoint,
                                                           float alphaHeatMap,
                                                           uint elementToRender);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_PoseGpuRenderer_delete(IntPtr renderer);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_PoseGpuRenderer_initializationOnThread(IntPtr renderer);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_PoseGpuRenderer_renderPose(IntPtr renderer,
                                                                IntPtr outputData,
                                                                IntPtr poseKeypoints,
                                                                float scaleInputToOutput,
                                                                float scaleNetToOutput,
                                                                out int item1,
                                                                out IntPtr item2);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_PoseGpuRenderer_setElementToRender(IntPtr renderer, int elementToRender);

    }

}
