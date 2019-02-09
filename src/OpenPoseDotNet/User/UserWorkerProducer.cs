using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public class UserWorkerProducer<T> : WorkerProducer<T>
        where T : Datum
    {

        #region Fields

        private readonly OpenPose.DataType _DataType;

        private readonly UserWorkerProducerDelegateMediator _Mediator;

        #endregion

        #region Constructors

        protected UserWorkerProducer() :
            base(IntPtr.Zero)
        {
            this._DataType = GenericHelpers.CheckDatumSupportTypes<T>();
            this._Mediator = new UserWorkerProducerDelegateMediator(this._DataType)
            {
                InitializationOnThread = this.OnInitializationOnThread,
                Work2 = this.OnWork
            };
            this._Mediator.Setup();

            this.NativePtr = this._Mediator.NativePtr;
        }

        internal UserWorkerProducer(IntPtr ptr, bool isEnabledDispose = true) :
            base(ptr, isEnabledDispose)
        {
            this._DataType = GenericHelpers.CheckDatumSupportTypes<T>();
            this.NativePtr = ptr;
        }

        #endregion

        #region Properties

        public bool IsRunning
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_UserWorkerProducer_isRunning(this._DataType, this.NativePtr);
            }
        }

        #endregion

        #region Methods

        protected virtual void InitializationOnThread()
        {
            this.ThrowIfDisposed();
        }

        public void Stop()
        {
            this.ThrowIfDisposed();
            NativeMethods.op_UserWorkerProducer_stop(this._DataType, this.NativePtr);
        }
        
        protected virtual StdSharedPtr<StdVector<StdSharedPtr<T>>> WorkProducer()
        {
            this.ThrowIfDisposed();
            return null;
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

            NativeMethods.op_UserWorkerProducer_delete(this._DataType, this.NativePtr);

            this._Mediator?.Dispose();
        }

        #endregion

        #region Helpers

        private void OnInitializationOnThread()
        {
            this.InitializationOnThread();
        }

        private IntPtr OnWork()
        {
            var ret = this.WorkProducer();
            return ret?.NativePtr ?? IntPtr.Zero;
        }

        #endregion

        #endregion

    }

}