using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        #region Methods

        public static string GetPoseProtoTxt(PoseModel poseModel)
        {
            string str = null;

            var ret = NativeMethods.op_getPoseProtoTxt(poseModel);
            if (ret != IntPtr.Zero)
                str = StringHelper.FromStdString(ret, true);

            return str;
        }
        
        public static string GetPoseTrainedModel(PoseModel poseModel)
        {
            string str = null;

            var ret = NativeMethods.op_getPoseTrainedModel(poseModel);
            if (ret != IntPtr.Zero)
                str = StringHelper.FromStdString(ret, true);

            return str;
        }

        public static uint GetPoseNumberBodyParts(PoseModel poseModel)
        {
            return NativeMethods.op_getPoseNumberBodyParts(poseModel);
        }

        public static uint[] GetPosePartPairs(PoseModel poseModel)
        {
            var ret = NativeMethods.op_getPosePartPairs(poseModel);
            using (var vector = new StdVector<uint>(ret))
                return vector.ToArray();
        }

        public static uint[] GetPoseMapIndex(PoseModel poseModel)
        {
            var ret = NativeMethods.op_getPoseMapIndex(poseModel);
            using (var vector = new StdVector<uint>(ret))
                return vector.ToArray();
        }

        public static uint GetPoseMaxPeaks()
        {
            return NativeMethods.op_getPoseMaxPeaks();
        }

        public static float GetPoseNetDecreaseFactor(PoseModel poseModel)
        {
            return NativeMethods.op_getPoseNetDecreaseFactor(poseModel);
        }

        public static float GetPoseDefaultConnectInterMinAboveThreshold(bool maximizePositives)
        {
            return NativeMethods.op_getPoseDefaultConnectInterMinAboveThreshold(maximizePositives);
        }

        public static float GetPoseDefaultConnectInterThreshold(PoseModel poseModel, bool maximizePositives)
        {
            return NativeMethods.op_getPoseDefaultConnectInterThreshold(poseModel, maximizePositives);
        }

        public static uint GetPoseDefaultMinSubsetCount(bool maximizePositives)
        {
            return NativeMethods.op_getPoseDefaultMinSubsetCnt(maximizePositives);
        }

        public static float GetPoseDefaultConnectMinSubsetScore(bool maximizePositives)
        {
            return NativeMethods.op_getPoseDefaultConnectMinSubsetScore(maximizePositives);
        }

        public static bool AddBackgroundChannel(PoseModel poseModel)
        {
            return NativeMethods.op_addBkgChannel(poseModel);
        }

        #endregion

    }

}