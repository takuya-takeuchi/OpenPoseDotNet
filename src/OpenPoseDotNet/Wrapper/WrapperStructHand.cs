using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class WrapperStructHand : OpenPoseObject
    {

        #region Fields

        public static readonly Point<int> DefaultNetInputSize = new Point<int>(656, 368);

        #endregion

        #region Constructors

        public WrapperStructHand() :
            this(false)
        {
        }

        public WrapperStructHand(bool enable) :
            this(enable,
                Detector.Body)
        {
        }

        public WrapperStructHand(bool enable,
                                 Detector detector) :
            this(enable,
                detector,
                new Point<int>(368, 368))
        {
        }

        public WrapperStructHand(bool enable,
                                 Detector detector,
                                 Point<int> netInputSize) :
            this(enable,
                detector,
                netInputSize,
                1)
        {
        }

        public WrapperStructHand(bool enable,
                                 Detector detector,
                                 Point<int> netInputSize,
                                 int scalesNumber) :
            this(enable,
                detector,
                netInputSize,
                scalesNumber,
                0.4f)
        {
        }

        public WrapperStructHand(bool enable,
                                 Detector detector,
                                 Point<int> netInputSize,
                                 int scalesNumber,
                                 float scaleRange) :
            this(enable,
                detector,
                netInputSize,
                scalesNumber,
                scaleRange,
                RenderMode.Gpu)
        {
        }

        public WrapperStructHand(bool enable,
                                 Detector detector,
                                 Point<int> netInputSize,
                                 int scalesNumber,
                                 float scaleRange,
                                 RenderMode renderMode) :
            this(enable,
                detector,
                netInputSize,
                scalesNumber,
                scaleRange,
                renderMode,
                OpenPose.HandDefaultAlphaKeyPoint)
        {
        }

        public WrapperStructHand(bool enable,
                                 Detector detector,
                                 Point<int> netInputSize,
                                 int scalesNumber,
                                 float scaleRange,
                                 RenderMode renderMode,
                                 float alphaKeyPoint) :
            this(enable,
                detector,
                netInputSize,
                scalesNumber,
                scaleRange,
                renderMode,
                alphaKeyPoint,
                OpenPose.HandDefaultAlphaHeatMap)
        {
        }

        public WrapperStructHand(bool enable,
                                 Detector detector,
                                 Point<int> netInputSize,
                                 int scalesNumber,
                                 float scaleRange,
                                 RenderMode renderMode,
                                 float alphaKeyPoint,
                                 float alphaHeatMap) :
            this(enable,
                detector,
                netInputSize,
                scalesNumber,
                scaleRange,
                renderMode,
                alphaKeyPoint,
                alphaHeatMap,
                0.2f)
        {
        }

        public WrapperStructHand(bool enable,
                                 Detector detector,
                                 Point<int> netInputSize,
                                 int scalesNumber,
                                 float scaleRange,
                                 RenderMode renderMode,
                                 float alphaKeyPoint,
                                 float alphaHeatMap,
                                 float renderThreshold)
        {
            using (var native = netInputSize.ToNative())
                this.NativePtr = NativeMethods.op_wrapperStructHand_new(enable,
                                                                        detector,
                                                                        native.NativePtr,
                                                                        scalesNumber,
                                                                        scaleRange,
                                                                        renderMode,
                                                                        alphaKeyPoint,
                                                                        alphaHeatMap,
                                                                        renderThreshold);
        }

        #endregion

        #region Properties

        public bool Enable
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_wrapperStructHand_get_enable(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.op_wrapperStructHand_set_enable(this.NativePtr, value);
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

            NativeMethods.op_wrapperStructHand_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}