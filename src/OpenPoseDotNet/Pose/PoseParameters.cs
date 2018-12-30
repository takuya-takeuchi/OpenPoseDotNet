using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        #region Methods

        public static string GetPoseProtoTxt(PoseModel poseModel)
        {
            string str = null;

            var ret = Native.op_getPoseProtoTxt(poseModel);
            if (ret != IntPtr.Zero)
                str = StringHelper.FromStdString(ret, true);

            return str;
        }
        
        public static string GetPoseTrainedModel(PoseModel poseModel)
        {
            string str = null;

            var ret = Native.op_getPoseTrainedModel(poseModel);
            if (ret != IntPtr.Zero)
                str = StringHelper.FromStdString(ret, true);

            return str;
        }

        public static uint GetPoseNumberBodyParts(PoseModel poseModel)
        {
            return Native.op_getPoseNumberBodyParts(poseModel);
        }

        public static uint[] GetPosePartPairs(PoseModel poseModel)
        {
            var ret = Native.op_getPosePartPairs(poseModel);
            using (var vector = new StdVector<uint>(ret))
                return vector.ToArray();
        }

        public static uint[] GetPoseMapIndex(PoseModel poseModel)
        {
            var ret = Native.op_getPoseMapIndex(poseModel);
            using (var vector = new StdVector<uint>(ret))
                return vector.ToArray();
        }

        public static uint GetPoseMaxPeaks()
        {
            return Native.op_getPoseMaxPeaks();
        }

        public static float GetPoseNetDecreaseFactor(PoseModel poseModel)
        {
            return Native.op_getPoseNetDecreaseFactor(poseModel);
        }

        public static float GetPoseDefaultConnectInterMinAboveThreshold(bool maximizePositives)
        {
            return Native.op_getPoseDefaultConnectInterMinAboveThreshold(maximizePositives);
        }

        public static float GetPoseDefaultConnectInterThreshold(PoseModel poseModel, bool maximizePositives)
        {
            return Native.op_getPoseDefaultConnectInterThreshold(poseModel, maximizePositives);
        }

        public static uint GetPoseDefaultMinSubsetCount(bool maximizePositives)
        {
            return Native.op_getPoseDefaultMinSubsetCnt(maximizePositives);
        }

        public static float GetPoseDefaultConnectMinSubsetScore(bool maximizePositives)
        {
            return Native.op_getPoseDefaultConnectMinSubsetScore(maximizePositives);
        }

        public static bool AddBackgroundChannel(PoseModel poseModel)
        {
            return Native.op_addBkgChannel(poseModel);
        }

        #endregion

        internal sealed partial class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_getPoseProtoTxt(PoseModel poseModel);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_getPoseTrainedModel(PoseModel poseModel);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern uint op_getPoseNumberBodyParts(PoseModel poseModel);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_getPosePartPairs(PoseModel poseModel);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_getPoseMapIndex(PoseModel poseModel);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern uint op_getPoseMaxPeaks();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern float op_getPoseNetDecreaseFactor(PoseModel poseModel);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern float op_getPoseDefaultConnectInterMinAboveThreshold(bool maximizePositives);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern float op_getPoseDefaultConnectInterThreshold(PoseModel poseModel, bool maximizePositives);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern uint op_getPoseDefaultMinSubsetCnt(bool maximizePositives);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern float op_getPoseDefaultConnectMinSubsetScore(bool maximizePositives);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_addBkgChannel(PoseModel poseModel);

        }

    }

}