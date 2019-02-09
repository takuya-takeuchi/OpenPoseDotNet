using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class CustomDatum : Datum
    {

        #region Constructors

        public CustomDatum()
        {
            if(this.NativePtr != IntPtr.Zero)
                NativeMethods.op_core_datum_delete(this.NativePtr);

            this.NativePtr = NativeMethods.op_CustomDatum_new();
        }

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
                return NativeMethods.op_CustomDatum_get_data(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.op_CustomDatum_set_data(this.NativePtr, value);
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

            NativeMethods.op_CustomDatum_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
