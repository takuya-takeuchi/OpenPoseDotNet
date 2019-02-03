using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class WrapperStructPose : OpenPoseObject
    {

        #region Fields

        public static readonly Point<int> DefaultNetInputSize = new Point<int>(656, 368);

        public static readonly Point<int> DefaultOutputSize = new Point<int>(-1, -1);

        #endregion

        #region Constructors

        public WrapperStructPose(bool enable = false,
                                 Point<int> netInputSize = default(Point<int>),
                                 Point<int> outputSize = default(Point<int>),
                                 ScaleMode keyPointScale = ScaleMode.InputResolution,
                                 int gpuNumber = -1,
                                 int gpuNumberStart = 0,
                                 int scalesNumber = 1,
                                 float scaleGap = 0.15f,
                                 RenderMode renderMode = RenderMode.Gpu,
                                 PoseModel poseModel = PoseModel.Body25,
                                 bool blendOriginalFrame = true,
                                 float alphaKeyPoint = OpenPose.PoseDefaultAlphaKeyPoint,
                                 float alphaHeatMap = OpenPose.PoseDefaultAlphaKeyPoint,
                                 int defaultPartToRender = 0,
                                 string modelFolder = "models/",
                                 IEnumerable<HeatMapType> heatMapTypes = null,
                                 ScaleMode heatMapScale = ScaleMode.ZeroToOne,
                                 bool addPartCandidates = false,
                                 float renderThreshold = 0.05f,
                                 int numberPeopleMax = -1,
                                 bool maximizePositives = false,
                                 double fpsMax = -1d,
                                 string prototxtPath = "",
                                 string caffeModelPath = "",
                                 bool enableGoogleLogging = true)
        {
            var modelFolderBytes = Encoding.UTF8.GetBytes(modelFolder ?? "");
            var prototxtPathBytes = Encoding.UTF8.GetBytes(prototxtPath ?? "");
            var caffeModelPathBytes = Encoding.UTF8.GetBytes(caffeModelPath ?? "");

            using (var nativeNetInputSize = netInputSize.ToNative())
            using (var nativeOutputSize = outputSize.ToNative())
            using (var vector = new StdVector<HeatMapType>(heatMapTypes ?? new HeatMapType[0]))
                this.NativePtr = NativeMethods.op_wrapperStructPose_new(enable,
                                                                        nativeNetInputSize.NativePtr,
                                                                        nativeOutputSize.NativePtr,
                                                                        keyPointScale,
                                                                        gpuNumber,
                                                                        gpuNumberStart,
                                                                        scalesNumber,
                                                                        scaleGap,
                                                                        renderMode,
                                                                        poseModel,
                                                                        blendOriginalFrame,
                                                                        alphaKeyPoint,
                                                                        alphaHeatMap,
                                                                        defaultPartToRender,
                                                                        modelFolderBytes,
                                                                        vector.NativePtr,
                                                                        heatMapScale,
                                                                        addPartCandidates,
                                                                        renderThreshold,
                                                                        numberPeopleMax,
                                                                        maximizePositives,
                                                                        fpsMax,
                                                                        prototxtPathBytes,
                                                                        caffeModelPathBytes,
                                                                        enableGoogleLogging);
        }

        #endregion

        #region Properties

        public bool Enable
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_wrapperStructPose_get_enable(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.op_wrapperStructPose_set_enable(this.NativePtr, value);
            }
        }

        #endregion

        #region Methods

        #region Overrides

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            NativeMethods.op_wrapperStructPose_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
