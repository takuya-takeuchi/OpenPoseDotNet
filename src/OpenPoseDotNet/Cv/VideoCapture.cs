using System;
using System.IO;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class VideoCapture : OpenPoseObject
    {

        #region Constructors

        public VideoCapture(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path))
                throw new FileNotFoundException($"'{path}' is not found.");

            var pathBytes = Encoding.UTF8.GetBytes(path);
            this.NativePtr = NativeMethods.op_3rdparty_cv_VideoCapture_new(pathBytes, pathBytes.Length);
        }

        internal VideoCapture(IntPtr ptr, bool isEnabledDispose = true) :
            base(isEnabledDispose)
        {
            this.NativePtr = ptr;
        }

        #endregion

        #region Methods
        
        public bool Grab()
        {
            this.ThrowIfDisposed();
            return NativeMethods.op_3rdparty_cv_VideoCapture_grab(this.NativePtr);
        }

        public bool IsOpened()
        {
            this.ThrowIfDisposed();
            return NativeMethods.op_3rdparty_cv_VideoCapture_isOpened(this.NativePtr);
        }

        public bool Retrieve(Mat mat, int channel = 0)
        {
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));

            mat.ThrowIfDisposed();

            this.ThrowIfDisposed();
            return NativeMethods.op_3rdparty_cv_VideoCapture_retrieve(this.NativePtr, mat.NativePtr, channel);
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

            NativeMethods.op_3rdparty_cv_VideoCapture_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}