using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class WrapperStructHand : OpenPoseObject
    {

        #region Constructors

        public WrapperStructHand(bool enable = false)
        {
            this.NativePtr = Native.op_wrapper_wrapperStructHand_new(enable);
        }

        #endregion

        #region Properties

        public bool Enable
        {
            get
            {
                this.ThrowIfDisposed();
                return Native.op_wrapper_wrapperStructHand_get_enable(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                Native.op_wrapper_wrapperStructHand_set_enable(this.NativePtr, value);
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

            Native.op_wrapper_wrapperStructHand_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_wrapper_wrapperStructHand_new(bool enable);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_wrapperStructHand_delete(IntPtr hand);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_wrapper_wrapperStructHand_get_enable(IntPtr hand);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_wrapperStructHand_set_enable(IntPtr hand, bool enable);

        }

    }

}
