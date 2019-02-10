using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_wrapperStructPose_new(PoseMode poseMode,
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
                                                             byte[] protoTxtPath,
                                                             byte[] caffeModelPath,
                                                             float upsamplingRatio,
                                                             bool enableGoogleLogging);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapperStructPose_delete(IntPtr face);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern PoseMode op_wrapperStructPose_get_poseMode(IntPtr face);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapperStructPose_set_poseMode(IntPtr face, PoseMode poseMode);

    }

}
