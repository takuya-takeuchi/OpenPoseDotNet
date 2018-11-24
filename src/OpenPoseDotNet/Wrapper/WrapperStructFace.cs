using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class WrapperStructFace : OpenPoseObject
    {

        #region Constructors

        public WrapperStructFace(bool enable = false)
        {
            this.NativePtr = Native.op_wrapper_wrapperStructFace_new(enable);
        }

        #endregion

        #region Properties

        public bool Enable
        {
            get
            {
                this.ThrowIfDisposed();
                return Native.op_wrapper_wrapperStructFace_get_enable(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                Native.op_wrapper_wrapperStructFace_set_enable(this.NativePtr, value);
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

            Native.op_wrapper_wrapperStructFace_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_wrapper_wrapperStructFace_new(bool enable);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_wrapperStructFace_delete(IntPtr face);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_wrapper_wrapperStructFace_get_enable(IntPtr face);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_wrapperStructFace_set_enable(IntPtr face, bool enable);

        }

    }

}
