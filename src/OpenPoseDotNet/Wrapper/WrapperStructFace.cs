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

        public WrapperStructFace(bool enable = false,
                                 Point<int> netInputSize = default(Point<int>),
                                 RenderMode renderMode = RenderMode.Gpu,
                                 float alphaKeyPoint = OpenPose.FaceDefaultAlphaKeyPoint,
                                 float alphaHeatMap = OpenPose.FaceDefaultAlphaHeatMap,
                                 float renderThreshold = 0.4f)
        {
            using(var native = netInputSize.ToNative())
                this.NativePtr = NativeMethods.op_wrapperStructFace_new(enable,
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