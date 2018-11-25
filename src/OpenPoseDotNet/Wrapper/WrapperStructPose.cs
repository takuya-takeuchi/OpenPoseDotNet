using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
                                 bool enableGoogleLogging = true)
        {
            var modelFolderBytes = Encoding.UTF8.GetBytes(modelFolder ?? "");

            using (var nativeNetInputSize = netInputSize.ToNative())
            using (var nativeOutputSize = outputSize.ToNative())
            using (var vector = new StdVector<HeatMapType>(heatMapTypes ?? new HeatMapType[0]))
                this.NativePtr = Native.op_wrapperStructPose_new(enable,
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
                                                                 enableGoogleLogging);
        }

    #endregion

    #region Properties

    public bool Enable
    {
        get
        {
            this.ThrowIfDisposed();
            return Native.op_wrapperStructPose_get_enable(this.NativePtr);
        }
        set
        {
            this.ThrowIfDisposed();
            Native.op_wrapperStructPose_set_enable(this.NativePtr, value);
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

        Native.op_wrapperStructPose_delete(this.NativePtr);
    }

    #endregion

    #endregion

    internal sealed class Native
    {

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_wrapperStructPose_new(bool enable,
                                                             IntPtr netInputSize,
                                                             IntPtr outputSize,
                                                             ScaleMode keypointScale,
                                                             int gpuNumber,
                                                             int gpuNumberStart,
                                                             int scalesNumber,
                                                             float scaleGap,
                                                             RenderMode renderMode,
                                                             PoseModel poseModel,
                                                             bool blendOriginalFrame,
                                                             float alphaKeypoint,
                                                             float alphaHeatMap,
                                                             int defaultPartToRender,
                                                             byte[] modelFolder,
                                                             IntPtr heatMapTypes,
                                                             ScaleMode heatMapScale,
                                                             bool addPartCandidates,
                                                             float renderThreshold,
                                                             int numberPeopleMax,
                                                             bool maximizePositives,
                                                             double fpsMax,
                                                             bool enableGoogleLogging);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_wrapperStructPose_delete(IntPtr face);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_wrapperStructPose_get_enable(IntPtr face);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_wrapperStructPose_set_enable(IntPtr face, bool enable);

    }

}

}
