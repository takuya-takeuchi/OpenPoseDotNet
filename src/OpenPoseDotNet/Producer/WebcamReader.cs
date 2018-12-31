using System;
using System.Runtime.InteropServices;

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
                return WebcamReaderNative.op_WebcamReader_isOpened(this.NativePtr);
            }
        }

        #endregion

        #region Methods

        public override double Get(int capProperty)
        {
            this.ThrowIfDisposed();
            return WebcamReaderNative.op_WebcamReader_get(this.NativePtr, capProperty);
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

        internal sealed class WebcamReaderNative
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_WebcamReader_get(IntPtr reader, int capProperty);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_WebcamReader_isOpened(IntPtr reader);

        }

    }

}
