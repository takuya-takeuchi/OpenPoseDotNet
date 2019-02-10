using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class WrapperStructFace : OpenPoseObject
    {
        #region Fields

        public static readonly Point<int> DefaultNetInputSize = new Point<int>(368, 368);

        #endregion

        #region Constructors

        public WrapperStructFace() :
            this(false)
        {
        }

        public WrapperStructFace(bool enable) :
            this(enable,
                 Detector.Body)
        {
        }

        public WrapperStructFace(bool enable,
                                 Detector detector) :
            this(enable,
                 detector,
                 new Point<int>(368, 368))
        {
        }

        public WrapperStructFace(bool enable,
                                 Detector detector,
                                 Point<int> netInputSize) :
            this(enable,
                 detector,
                 netInputSize,
                 RenderMode.Gpu)
        {
        }

        public WrapperStructFace(bool enable,
                                 Detector detector,
                                 Point<int> netInputSize,
                                 RenderMode renderMode) :
            this(enable,
                 detector,
                 netInputSize,
                 renderMode,
                 OpenPose.FaceDefaultAlphaKeyPoint)
        {
        }

        public WrapperStructFace(bool enable,
                                 Detector detector,
                                 Point<int> netInputSize,
                                 RenderMode renderMode,
                                 float alphaKeyPoint) :
            this(enable,
                 detector,
                 netInputSize,
                 renderMode,
                 alphaKeyPoint,
                 OpenPose.FaceDefaultAlphaHeatMap)
        {
        }

        public WrapperStructFace(bool enable,
                                 Detector detector,
                                 Point<int> netInputSize,
                                 RenderMode renderMode,
                                 float alphaKeyPoint,
                                 float alphaHeatMap) :
            this(enable, 
                 detector,
                 netInputSize,
                 renderMode, 
                 alphaKeyPoint,
                 alphaHeatMap, 0.4f)
        {
        }

        public WrapperStructFace(bool enable,
                                 Detector detector,
                                 Point<int> netInputSize,
                                 RenderMode renderMode,
                                 float alphaKeyPoint,
                                 float alphaHeatMap,
                                 float renderThreshold)
        {
            using (var native = netInputSize.ToNative())
                this.NativePtr = NativeMethods.op_wrapperStructFace_new(enable,
                                                                        detector,
                                                                        native.NativePtr,
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
                return NativeMethods.op_wrapperStructFace_get_enable(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.op_wrapperStructFace_set_enable(this.NativePtr, value);
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

            NativeMethods.op_wrapperStructFace_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}