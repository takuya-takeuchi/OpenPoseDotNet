using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class PoseExtractorCaffe : PoseExtractorNet
    {

        #region Constructors

        public PoseExtractorCaffe(PoseModel poseModel,
                                  string modelFolder,
                                  int gpuId,
                                  HeatMapType[] heatMapTypes = null,
                                  ScaleMode heatMapScale = ScaleMode.ZeroToOne,
                                  bool addPartCandidates = false,
                                  bool maximizePositives = false,
                                  bool enableGoogleLogging = true)
        {
            if (!Directory.Exists(modelFolder))
                throw new DirectoryNotFoundException($"{modelFolder} is not found.");

            var modelFolderBytes = Encoding.UTF8.GetBytes(modelFolder);
            using (var types = new StdVector<HeatMapType>(heatMapTypes ?? new HeatMapType[0]))
                this.NativePtr = NativeMethods.op_PoseExtractorCaffe_new(poseModel,
                                                                         modelFolderBytes,
                                                                         gpuId,
                                                                         types.NativePtr,
                                                                         heatMapScale,
                                                                         addPartCandidates,
                                                                         maximizePositives,
                                                                         enableGoogleLogging);
        }

        internal PoseExtractorCaffe(IntPtr ptr, bool isEnabledDispose = true) :
            base(ptr, isEnabledDispose)
        {
        }

        #endregion

        #region Methods

        public override void ForwardPass(IEnumerable<Array<float>> inputNetData, Point<int> inputDataSize, double[] scaleRatios = null)
        {
            if (inputNetData == null)
                throw new ArgumentNullException(nameof(inputNetData));

            this.ThrowIfDisposed();

            using (var inputNetVector = new StdVector<Array<float>>(inputNetData))
            using (var inputDataSizeNative = inputDataSize.ToNative())
            using (var scaleVector = new StdVector<double>(scaleRatios ?? new[] { 1.0d }))
                NativeMethods.op_PoseExtractorCaffe_forwardPass(this.NativePtr,
                                                                inputNetVector.NativePtr, 
                                                                inputDataSizeNative.NativePtr,
                                                                scaleVector.NativePtr);
        }

        //public override void InitializationOnThread()
        //{
        //    this.ThrowIfDisposed();
        //    PoseExtractorCaffeNative.op_PoseExtractorCaffe_initializationOnThread(this.NativePtr);
        //}

        #region Overrides

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            NativeMethods.op_PoseExtractorCaffe_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
