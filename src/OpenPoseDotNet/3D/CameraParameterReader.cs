using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class CameraParameterReader : OpenPoseObject
    {

        #region Constructors

        public CameraParameterReader()
        {
            this.NativePtr = NativeMethods.op_CameraParameterReader_new();
        }

        #endregion

        #region Properties

        public UInt64 NumberCameras
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_CameraParameterReader_getNumberCameras(this.NativePtr);
            }
        }

        public bool UndistortImage
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_CameraParameterReader_getUndistortImage(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.op_CameraParameterReader_setUndistortImage(this.NativePtr, value);
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

            NativeMethods.op_CameraParameterReader_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}