using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class DatumProducer<T> : OpenPoseObject
    {

        #region Fields

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors

        public DatumProducer(StdSharedPtr<Producer> producerSharedPtr,
                             ulong frameFirst = 0,
                             ulong frameStep = 1,
                             ulong frameLast = ulong.MaxValue)
        {
            if (producerSharedPtr == null)
                throw new ArgumentNullException(nameof(producerSharedPtr));

            producerSharedPtr.ThrowIfDisposed();

            this._DataType = GenericHelpers.CheckDatumSupportTypes<T>();
            this.NativePtr = NativeMethods.op_DatumProducer_new(this._DataType,
                                                                producerSharedPtr.NativePtr,
                                                                frameFirst,
                                                                frameStep,
                                                                frameLast,
                                                                IntPtr.Zero);
        }
        
        internal DatumProducer(IntPtr ptr, bool isEnabledDispose = true) :
            base(isEnabledDispose)
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

            NativeMethods.op_DatumProducer_delete(this._DataType, this.NativePtr);
        }

        #endregion

        #endregion

    }

}