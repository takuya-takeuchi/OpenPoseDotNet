using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class PoseGpuRenderer : OpenPoseObject, IPoseRenderer, IGpuRenderer
    {

        #region Constructors

        public PoseGpuRenderer(PoseModel poseModel,
                               StdSharedPtr<PoseExtractorCaffe> poseExtractorNet,
                               float renderThreshold,
                               bool blendOriginalFrame = true,
                               float alphaKeyPoint = OpenPose.PoseDefaultAlphaKeyPoint,
                               float alphaHeatMap = OpenPose.PoseDefaultAlphaHeatMap,
                               uint elementToRender = 0u)
        {
            this.NativePtr = NativeMethods.op_PoseGpuRenderer_new(poseModel,
                                                                  poseExtractorNet.NativePtr,
                                                                  renderThreshold,
                                                                  blendOriginalFrame,
                                                                  alphaKeyPoint,
                                                                  alphaHeatMap,
                                                                  elementToRender);
        }                                     

        #endregion

        #region Methods

        public void InitializationOnThread()
        {
            this.ThrowIfDisposed();
            NativeMethods.op_PoseGpuRenderer_initializationOnThread(this.NativePtr);
        }

        public Tuple<int, string> RenderPose(Array<float> outputData,
                                             Array<float> poseKeyPoints,
                                             float scaleInputToOutput,
                                             float scaleNetToOutput = -1.0f)
        {
            if (outputData == null)
                throw new ArgumentNullException(nameof(outputData));
            if (poseKeyPoints == null)
                throw new ArgumentNullException(nameof(poseKeyPoints));

            this.ThrowIfDisposed();

            outputData.ThrowIfDisposed();
            poseKeyPoints.ThrowIfDisposed();

            NativeMethods.op_PoseGpuRenderer_renderPose(this.NativePtr, 
                                                        outputData.NativePtr, 
                                                        poseKeyPoints.NativePtr,
                                                        scaleInputToOutput,
                                                        scaleNetToOutput,
                                                        out var item1,
                                                        out var item2);

            var str = StringHelper.FromStdString(item2, true);
            return new Tuple<int, string>(item1, str);
        }

        public void SetElementToRender(int elementToRender)
        {
            this.ThrowIfDisposed();
            NativeMethods.op_PoseGpuRenderer_setElementToRender(this.NativePtr, elementToRender);
        }

        #region Overrides

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            NativeMethods.op_PoseGpuRenderer_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
