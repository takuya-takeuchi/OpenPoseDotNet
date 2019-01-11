using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public class WebcamReader : VideoCaptureReader
    {

        #region Constructors

        internal WebcamReader(IntPtr ptr, bool isEnabledDispose = true)
            : base(ptr, isEnabledDispose)
        {
        }

        #endregion

        #region Properties

        public override bool IsOpened
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_WebcamReader_isOpened(this.NativePtr);
            }
        }

        #endregion

        #region Methods

        public override double Get(int capProperty)
        {
            this.ThrowIfDisposed();
            return NativeMethods.op_WebcamReader_get(this.NativePtr, capProperty);
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

            // This class should be used in std::shared_ptr.
            // So we need not to consider dispose object
        }

        #endregion

        #endregion

    }

}