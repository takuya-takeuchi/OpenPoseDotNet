using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class Mat : OpenPoseObject
    {

        #region Constructors

        internal Mat(IntPtr ptr, bool isEnabledDispose = true) :
            base(isEnabledDispose)
        {
            this.NativePtr = ptr;
        }

        #endregion

        #region Properties

        public int Channels
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_3rdparty_cv_mat_channels(this.NativePtr);
            }
        }

        public int Cols
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_3rdparty_cv_mat_cols(this.NativePtr);
            }
        }

        public bool Empty
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_3rdparty_cv_mat_empty(this.NativePtr);
            }
        }

        public int Rows
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_3rdparty_cv_mat_rows(this.NativePtr);
            }
        }

        public MatType Type
        {
            get
            {
                this.ThrowIfDisposed();
                var value = NativeMethods.op_3rdparty_cv_mat_type(this.NativePtr);
                return new MatType(value);
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

            NativeMethods.op_3rdparty_cv_mat_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
