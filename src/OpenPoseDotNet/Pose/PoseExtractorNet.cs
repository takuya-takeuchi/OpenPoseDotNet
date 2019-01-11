using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public abstract class PoseExtractorNet : OpenPoseObject
    {

        #region Constructors

        protected PoseExtractorNet()
        {
        }

        protected PoseExtractorNet(IntPtr ptr, bool isEnabledDispose = true):
            base(isEnabledDispose)
        {
            this.NativePtr = ptr;
        }

        #endregion

        #region Methods

        public abstract void ForwardPass(IEnumerable<Array<float>> inputNetData, Point<int> inputDataSize, double[] scaleRatios = null);

        public Array<float> GetPoseKeyPoints()
        {
            this.ThrowIfDisposed();

            var ret = NativeMethods.op_PoseExtractorNet_getPoseKeypoints(this.NativePtr);
            return new Array<float>(ret);
        }

        public float GetScaleNetToOutput()
        {
            this.ThrowIfDisposed();
            return NativeMethods.op_PoseExtractorNet_getScaleNetToOutput(this.NativePtr);
        }

        public void InitializationOnThread()
        {
            this.ThrowIfDisposed();
            NativeMethods.op_PoseExtractorNet_initializationOnThread(this.NativePtr);
        }

        #endregion

    }

}