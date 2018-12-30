using System;
using System.Runtime.InteropServices;
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
                this.NativePtr = Native.op_FrameDisplayer_new(windowNameBytes, size.NativePtr, fullScreen);
        }

        #endregion

        #region Properties
        #endregion

        #region Methods

        public void DisplayFrame(Mat frame, int waitKeyValue = -1)
        {
            if (frame == null)
                throw new ArgumentNullException(nameof(frame));

            this.ThrowIfDisposed();
            frame.ThrowIfDisposed();

            Native.op_FrameDisplayer_displayFrame(this.NativePtr, frame.NativePtr, waitKeyValue);
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

            Native.op_FrameDisplayer_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_FrameDisplayer_new(byte[] windowedName,
                                                              IntPtr initialWindowedSize,
                                                              bool fullScreen);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_FrameDisplayer_delete(IntPtr caffe);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_FrameDisplayer_displayFrame(IntPtr displayer, IntPtr frame, int waitKeyValue);

        }

    }

}
