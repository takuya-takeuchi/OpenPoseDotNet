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

        public WrapperStructHand(bool enable = false,
                                 Point<int> netInputSize = default (Point<int>),
                                 int scalesNumber = 1,
                                 float scaleRange = 0.4f,
                                 bool tracking = false,
                                 RenderMode renderMode = RenderMode.Gpu,
                                 float alphaKeyPoint = OpenPose.HandDefaultAlphaKeyPoint,
                                 float alphaHeatMap = OpenPose.HandDefaultAlphaHeatMap,
                                 float renderThreshold = 0.2f)
        {
            using (var native = netInputSize.ToNative())
                this.NativePtr = NativeMethods.op_wrapperStructHand_new(enable,
                                                                        native.NativePtr,
                                                                        scalesNumber,
                                                                        scaleRange,
                                                                        tracking,
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