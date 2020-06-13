using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

        public void ReadParameters(string cameraParameterPath, IEnumerable<string> serialNumbers = null)
        {
            if (cameraParameterPath == null)
                throw new ArgumentNullException(nameof(cameraParameterPath));
            if (!Directory.Exists(cameraParameterPath))
                throw new FileNotFoundException($"'{cameraParameterPath}' is not found.");

            this.ThrowIfDisposed();

            var pathBytes = Encoding.UTF8.GetBytes(cameraParameterPath);
            // ToDo: support serialNumbers parameter
            NativeMethods.op_CameraParameterReader_readParameters(this.NativePtr, pathBytes, pathBytes.Length, IntPtr.Zero);
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

            NativeMethods.op_CameraParameterReader_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}