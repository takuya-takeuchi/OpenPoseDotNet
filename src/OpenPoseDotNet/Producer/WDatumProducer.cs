using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class WDatumProducer<T> : WorkerProducer<T>
        where T : Datum
    {

        #region Fields

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors

        public WDatumProducer(StdSharedPtr<DatumProducer<T>> datumProducer)
        {
            if (datumProducer == null)
                throw new ArgumentNullException(nameof(datumProducer));

            datumProducer.ThrowIfDisposed();

            this._DataType = GenericHelpers.CheckDatumSupportTypes<T>();
            this.NativePtr = NativeMethods.op_WDatumProducer_new(this._DataType,
                                                                   datumProducer.NativePtr);
        }
        
        internal WDatumProducer(IntPtr ptr, bool isEnabledDispose = true) :
            base(ptr, isEnabledDispose)
        {
            this._DataType = GenericHelpers.CheckDatumSupportTypes<T>();
            this.NativePtr = ptr;
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

            NativeMethods.op_WDatumProducer_delete(this._DataType, this.NativePtr);
        }

        #endregion

        #endregion

    }

}