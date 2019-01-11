using System;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class FrameDisplayer : OpenPoseObject
    {

        #region Constructors

        public FrameDisplayer(string windowName, Point<int> initialWindowedSize, bool fullScreen = false)
        {
            var windowNameBytes = Encoding.UTF8.GetBytes(windowName);
            using (var size = initialWindowedSize.ToNative())
                this.NativePtr = NativeMethods.op_FrameDisplayer_new(windowNameBytes, size.NativePtr, fullScreen);
        }

        #endregion

        #region Methods

        public void DisplayFrame(Mat frame, int waitKeyValue = -1)
        {
            if (frame == null)
                throw new ArgumentNullException(nameof(frame));

            this.ThrowIfDisposed();
            frame.ThrowIfDisposed();

            NativeMethods.op_FrameDisplayer_displayFrame(this.NativePtr, frame.NativePtr, waitKeyValue);
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

            NativeMethods.op_FrameDisplayer_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
