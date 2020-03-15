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

        public WrapperStructPose() :
            this(PoseMode.Enabled)
        {
        }

        public WrapperStructPose(PoseMode poseMode) :
            this(poseMode,
                 DefaultNetInputSize)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize) :
            this(poseMode,
                 netInputSize,
                 DefaultOutputSize)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize) :
            this(poseMode,
                 netInputSize,
                 outputSize,
                 ScaleMode.InputResolution)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale) :
            this(poseMode,
                 netInputSize,
                 outputSize,
                 keyPointScale,
                 -1)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber) :
            this(poseMode,
                 netInputSize,
                 outputSize,
                 keyPointScale,
                 gpuNumber,
                 0)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart) :
            this(poseMode,
                 netInputSize,
                 outputSize,
                 keyPointScale,
                 gpuNumber,
                 gpuNumberStart,
                 1)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber) :
            this(poseMode,
                 netInputSize,
                 outputSize,
                 keyPointScale,
                 gpuNumber,
                 gpuNumberStart,
                 scalesNumber,
                 0.15f)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap) :
            this(poseMode,
                 netInputSize,
                 outputSize,
                 keyPointScale,
                 gpuNumber,
                 gpuNumberStart,
                 scalesNumber,
                 scaleGap,
                 RenderMode.Gpu)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode) :
            this(poseMode,
                 netInputSize,
                 outputSize,
                 keyPointScale,
                 gpuNumber,
                 gpuNumberStart,
                 scalesNumber,
                 scaleGap,
                 renderMode,
                 PoseModel.Body25)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel) :
            this(poseMode,
                 netInputSize,
                 outputSize,
                 keyPointScale,
                 gpuNumber,
                 gpuNumberStart,
                 scalesNumber,
                 scaleGap,
                 renderMode,
                 poseModel,
                 true)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame) :
            this(poseMode,
                 netInputSize,
                 outputSize,
                 keyPointScale,
                 gpuNumber,
                 gpuNumberStart,
                 scalesNumber,
                 scaleGap,
                 renderMode,
                 poseModel,
                 blendOriginalFrame,
                 OpenPose.PoseDefaultAlphaKeyPoint)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame,
                                 float alphaKeyPoint) :
            this(poseMode,
                 netInputSize,
                 outputSize,
                 keyPointScale,
                 gpuNumber,
                 gpuNumberStart,
                 scalesNumber,
                 scaleGap,
                 renderMode,
                 poseModel,
                 blendOriginalFrame,
                 alphaKeyPoint,
                 OpenPose.PoseDefaultAlphaKeyPoint)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame,
                                 float alphaKeyPoint,
                                 float alphaHeatMap) :
            this(poseMode,
                 netInputSize,
                 outputSize,
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
                 0)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame,
                                 float alphaKeyPoint,
                                 float alphaHeatMap,
                                 int defaultPartToRender) :
            this(poseMode,
                 netInputSize,
                 outputSize,
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
                 "models/")
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame,
                                 float alphaKeyPoint,
                                 float alphaHeatMap,
                                 int defaultPartToRender,
                                 string modelFolder) :
            this(poseMode,
                 netInputSize,
                 outputSize,
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
                 modelFolder,
                 null)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame,
                                 float alphaKeyPoint,
                                 float alphaHeatMap,
                                 int defaultPartToRender,
                                 string modelFolder,
                                 IEnumerable<HeatMapType> heatMapTypes) :
            this(poseMode,
                 netInputSize,
                 outputSize,
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
                 modelFolder,
                 heatMapTypes,
                 ScaleMode.ZeroToOne)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame,
                                 float alphaKeyPoint,
                                 float alphaHeatMap,
                                 int defaultPartToRender,
                                 string modelFolder,
                                 IEnumerable<HeatMapType> heatMapTypes,
                                 ScaleMode heatMapScale) :
            this(poseMode,
                 netInputSize,
                 outputSize,
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
                 modelFolder,
                 heatMapTypes,
                 heatMapScale,
                 false)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame,
                                 float alphaKeyPoint,
                                 float alphaHeatMap,
                                 int defaultPartToRender,
                                 string modelFolder,
                                 IEnumerable<HeatMapType> heatMapTypes,
                                 ScaleMode heatMapScale,
                                 bool addPartCandidates) :
            this(poseMode,
                 netInputSize,
                 outputSize,
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
                 modelFolder,
                 heatMapTypes,
                 heatMapScale,
                 addPartCandidates,
                 0.05f)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame,
                                 float alphaKeyPoint,
                                 float alphaHeatMap,
                                 int defaultPartToRender,
                                 string modelFolder,
                                 IEnumerable<HeatMapType> heatMapTypes,
                                 ScaleMode heatMapScale,
                                 bool addPartCandidates,
                                 float renderThreshold) :
            this(poseMode,
                 netInputSize,
                 outputSize,
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
                 modelFolder,
                 heatMapTypes,
                 heatMapScale,
                 addPartCandidates,
                 renderThreshold,
                 -1)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame,
                                 float alphaKeyPoint,
                                 float alphaHeatMap,
                                 int defaultPartToRender,
                                 string modelFolder,
                                 IEnumerable<HeatMapType> heatMapTypes,
                                 ScaleMode heatMapScale,
                                 bool addPartCandidates,
                                 float renderThreshold,
                                 int numberPeopleMax) :
            this(poseMode,
                 netInputSize,
                 outputSize,
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
                 modelFolder,
                 heatMapTypes,
                 heatMapScale,
                 addPartCandidates,
                 renderThreshold,
                 numberPeopleMax,
                 false)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame,
                                 float alphaKeyPoint,
                                 float alphaHeatMap,
                                 int defaultPartToRender,
                                 string modelFolder,
                                 IEnumerable<HeatMapType> heatMapTypes,
                                 ScaleMode heatMapScale,
                                 bool addPartCandidates,
                                 float renderThreshold,
                                 int numberPeopleMax,
                                 bool maximizePositives) :
            this(poseMode,
                 netInputSize,
                 outputSize,
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
                 modelFolder,
                 heatMapTypes,
                 heatMapScale,
                 addPartCandidates,
                 renderThreshold,
                 numberPeopleMax,
                 maximizePositives,
                 -1d)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame,
                                 float alphaKeyPoint,
                                 float alphaHeatMap,
                                 int defaultPartToRender,
                                 string modelFolder,
                                 IEnumerable<HeatMapType> heatMapTypes,
                                 ScaleMode heatMapScale,
                                 bool addPartCandidates,
                                 float renderThreshold,
                                 int numberPeopleMax,
                                 bool maximizePositives,
                                 double fpsMax) :
            this(poseMode,
                 netInputSize,
                 outputSize,
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
                 modelFolder,
                 heatMapTypes,
                 heatMapScale,
                 addPartCandidates,
                 renderThreshold,
                 numberPeopleMax,
                 maximizePositives,
                 fpsMax,
                 "")
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame,
                                 float alphaKeyPoint,
                                 float alphaHeatMap,
                                 int defaultPartToRender,
                                 string modelFolder,
                                 IEnumerable<HeatMapType> heatMapTypes,
                                 ScaleMode heatMapScale,
                                 bool addPartCandidates,
                                 float renderThreshold,
                                 int numberPeopleMax,
                                 bool maximizePositives,
                                 double fpsMax,
                                 string prototxtPath) :
            this(poseMode,
                 netInputSize,
                 outputSize,
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
                 modelFolder,
                 heatMapTypes,
                 heatMapScale,
                 addPartCandidates,
                 renderThreshold,
                 numberPeopleMax,
                 maximizePositives,
                 fpsMax,
                 prototxtPath,
                 "")
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame,
                                 float alphaKeyPoint,
                                 float alphaHeatMap,
                                 int defaultPartToRender,
                                 string modelFolder,
                                 IEnumerable<HeatMapType> heatMapTypes,
                                 ScaleMode heatMapScale,
                                 bool addPartCandidates,
                                 float renderThreshold,
                                 int numberPeopleMax,
                                 bool maximizePositives,
                                 double fpsMax,
                                 string prototxtPath,
                                 string caffeModelPath) :
            this(poseMode,
                 netInputSize,
                 outputSize,
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
                 modelFolder,
                 heatMapTypes,
                 heatMapScale,
                 addPartCandidates,
                 renderThreshold,
                 numberPeopleMax,
                 maximizePositives,
                 fpsMax,
                 prototxtPath,
                 caffeModelPath,
                 0f)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame,
                                 float alphaKeyPoint,
                                 float alphaHeatMap,
                                 int defaultPartToRender,
                                 string modelFolder,
                                 IEnumerable<HeatMapType> heatMapTypes,
                                 ScaleMode heatMapScale,
                                 bool addPartCandidates,
                                 float renderThreshold,
                                 int numberPeopleMax,
                                 bool maximizePositives,
                                 double fpsMax,
                                 string prototxtPath,
                                 string caffeModelPath,
                                 float upsamplingRatio) :
            this(poseMode,
                 netInputSize,
                 outputSize,
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
                 modelFolder,
                 heatMapTypes,
                 heatMapScale,
                 addPartCandidates,
                 renderThreshold,
                 numberPeopleMax,
                 maximizePositives,
                 fpsMax,
                 prototxtPath,
                 caffeModelPath,
                 upsamplingRatio,
                 true)
        {
        }

        public WrapperStructPose(PoseMode poseMode,
                                 Point<int> netInputSize,
                                 Point<int> outputSize,
                                 ScaleMode keyPointScale,
                                 int gpuNumber,
                                 int gpuNumberStart,
                                 int scalesNumber,
                                 float scaleGap,
                                 RenderMode renderMode,
                                 PoseModel poseModel,
                                 bool blendOriginalFrame,
                                 float alphaKeyPoint,
                                 float alphaHeatMap,
                                 int defaultPartToRender,
                                 string modelFolder,
                                 IEnumerable<HeatMapType> heatMapTypes,
                                 ScaleMode heatMapScale,
                                 bool addPartCandidates,
                                 float renderThreshold,
                                 int numberPeopleMax,
                                 bool maximizePositives,
                                 double fpsMax,
                                 string prototxtPath,
                                 string caffeModelPath,
                                 float upsamplingRatio,
                                 bool enableGoogleLogging)
        {
            var modelFolderBytes = Encoding.UTF8.GetBytes(modelFolder ?? "");
            var prototxtPathBytes = Encoding.UTF8.GetBytes(prototxtPath ?? "");
            var caffeModelPathBytes = Encoding.UTF8.GetBytes(caffeModelPath ?? "");

            using (var nativeNetInputSize = netInputSize.ToNative())
            using (var nativeOutputSize = outputSize.ToNative())
            using (var vector = new StdVector<HeatMapType>(heatMapTypes ?? new HeatMapType[0]))
                this.NativePtr = NativeMethods.op_wrapperStructPose_new(poseMode,
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
                                                                        upsamplingRatio,
                                                                        enableGoogleLogging);
        }

        #endregion

        #region Properties

        public PoseMode PoseMode
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_wrapperStructPose_get_poseMode(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.op_wrapperStructPose_set_poseMode(this.NativePtr, value);
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
