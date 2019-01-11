using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal static partial class NativeMethods
    {

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_wrapperStructPose_new(bool enable,
                                                             IntPtr netInputSize,
                                                             IntPtr outputSize,
                                                             ScaleMode keypointScale,
                                                             int gpuNumber,
                                                             int gpuNumberStart,
                                                             int scalesNumber,
                                                             float scaleGap,
                                                             RenderMode renderMode,
                                                             PoseModel poseModel,
                                                             bool blendOriginalFrame,
                                                             float alphaKeypoint,
                                                             float alphaHeatMap,
                                                             int defaultPartToRender,
                                                             byte[] modelFolder,
                                                             IntPtr heatMapTypes,
                                                             ScaleMode heatMapScale,
                                                             bool addPartCandidates,
                                                             float renderThreshold,
                                                             int numberPeopleMax,
                                                             bool maximizePositives,
                                                             double fpsMax,
                                                             bool enableGoogleLogging);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_wrapperStructPose_delete(IntPtr face);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_wrapperStructPose_get_enable(IntPtr face);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_wrapperStructPose_set_enable(IntPtr face, bool enable);

    }

}
