using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_PoseExtractorCaffe_new(PoseModel poseModel,
                                                              byte[] modelFolder,
                                                              int gpuId,
                                                              IntPtr heatMapTypes,
                                                              ScaleMode heatMapScale,
                                                              bool addPartCandidates,
                                                              bool maximizePositives,
                                                              byte[] protoTxtPath,
                                                              byte[] caffeModelPath,
                                                              bool enableGoogleLogging);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_PoseExtractorCaffe_delete(IntPtr caffe);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_PoseExtractorCaffe_forwardPass(IntPtr caffe,
                                                                    IntPtr inputNetData,
                                                                    IntPtr inputDataSize,
                                                                    IntPtr scaleRatios);

    }

}
