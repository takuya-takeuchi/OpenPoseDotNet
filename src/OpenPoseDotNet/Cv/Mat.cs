using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class Mat : OpenPoseObject
    {

        #region Events
        #endregion

        #region Fields
        #endregion

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
                return Native.op_3rdparty_cv_mat_channels(this.NativePtr);
            }
        }

        public int Cols
        {
            get
            {
                this.ThrowIfDisposed();
                return Native.op_3rdparty_cv_mat_cols(this.NativePtr);
            }
        }

        public bool Empty
        {
            get
            {
                this.ThrowIfDisposed();
                return Native.op_3rdparty_cv_mat_empty(this.NativePtr);
            }
        }

        public int Rows
        {
            get
            {
                this.ThrowIfDisposed();
                return Native.op_3rdparty_cv_mat_rows(this.NativePtr);
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

            Native.op_3rdparty_cv_mat_delete(this.NativePtr);
        }

        #endregion

        #region Event Handlers
        #endregion

        #region Helpers
        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_3rdparty_cv_mat_delete(IntPtr mat);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_3rdparty_cv_mat_empty(IntPtr mat);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_3rdparty_cv_mat_rows(IntPtr mat);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_3rdparty_cv_mat_cols(IntPtr mat);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_3rdparty_cv_mat_channels(IntPtr mat);

        }

    }

}
