using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class PoseCpuRenderer : OpenPoseObject, IPoseRenderer, IRenderer
    {

        #region Constructors

        public PoseCpuRenderer(PoseModel poseModel,
                               float renderThreshold,
                               bool blendOriginalFrame = true,
                               float alphaKeyPoint = OpenPose.PoseDefaultAlphaKeyPoint,
                               float alphaHeatMap = OpenPose.PoseDefaultAlphaHeatMap,
                               uint elementToRender = 0u)
        {
            this.NativePtr = Native.op_PoseCpuRenderer_new(poseModel,
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
            Native.op_PoseCpuRenderer_initializationOnThread(this.NativePtr);
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

            Native.op_PoseCpuRenderer_renderPose(this.NativePtr, 
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
            Native.op_PoseCpuRenderer_setElementToRender(this.NativePtr, elementToRender);
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

            PoseCpuRenderer.Native.op_PoseCpuRenderer_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_PoseCpuRenderer_new(PoseModel poseModel,
                                                               float renderThreshold,
                                                               bool blendOriginalFrame,
                                                               float alphaKeyPoint,
                                                               float alphaHeatMap,
                                                               uint elementToRender);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_PoseCpuRenderer_delete(IntPtr renderer);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_PoseCpuRenderer_initializationOnThread(IntPtr renderer);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_PoseCpuRenderer_renderPose(IntPtr renderer,
                                                                    IntPtr outputData,
                                                                    IntPtr poseKeypoints,
                                                                    float scaleInputToOutput,
                                                                    float scaleNetToOutput,
                                                                    out int item1,
                                                                    out IntPtr item2);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_PoseCpuRenderer_setElementToRender(IntPtr renderer, int elementToRender);

        }

    }

}
