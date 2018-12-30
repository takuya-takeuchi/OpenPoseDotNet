using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class CustomDatum : Datum
    {

        #region Constructors

        internal CustomDatum(IntPtr ptr, bool isEnabledDispose = true) :
            base(ptr, isEnabledDispose)
        {
        }

        #endregion

        #region Properties

        public IntPtr Data
        {
            get
            {
                this.ThrowIfDisposed();
                return CustomDatumNative.op_CustomDatum_get_data(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                CustomDatumNative.op_CustomDatum_set_data(this.NativePtr, value);
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

            CustomDatumNative.op_CustomDatum_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class CustomDatumNative
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_CustomDatum_new();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_CustomDatum_delete(IntPtr datum);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_CustomDatum_get_data(IntPtr datum);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_CustomDatum_set_data(IntPtr datum, IntPtr data);

        }

    }

}
