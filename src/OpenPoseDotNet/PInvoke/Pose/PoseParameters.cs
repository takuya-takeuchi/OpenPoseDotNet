using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_getPoseProtoTxt(PoseModel poseModel);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_getPoseTrainedModel(PoseModel poseModel);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint op_getPoseNumberBodyParts(PoseModel poseModel);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_getPosePartPairs(PoseModel poseModel);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_getPoseMapIndex(PoseModel poseModel);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint op_getPoseMaxPeaks();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern float op_getPoseNetDecreaseFactor(PoseModel poseModel);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern float op_getPoseDefaultConnectInterMinAboveThreshold(bool maximizePositives);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern float op_getPoseDefaultConnectInterThreshold(PoseModel poseModel, bool maximizePositives);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint op_getPoseDefaultMinSubsetCnt(bool maximizePositives);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern float op_getPoseDefaultConnectMinSubsetScore(bool maximizePositives);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_addBkgChannel(PoseModel poseModel);

    }

}