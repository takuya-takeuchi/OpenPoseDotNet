using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal static partial class NativeMethods
    {

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_PoseExtractorCaffe_new(PoseModel poseModel,
            byte[] modelFolder,
            int gpuId,
            IntPtr heatMapTypes,
            ScaleMode heatMapScale,
            bool addPartCandidates,
            bool maximizePositives,
            bool enableGoogleLogging);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_PoseExtractorCaffe_delete(IntPtr caffe);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_PoseExtractorCaffe_forwardPass(IntPtr caffe,
            IntPtr inputNetData,
            IntPtr inputDataSize,
            IntPtr scaleRatios);

    }

}
