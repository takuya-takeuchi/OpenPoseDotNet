using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public class UserWorkerConsumer<T> : WorkerConsumer<T>
        where T : Datum
    {

        #region Fields

        private readonly OpenPose.DataType _DataType;

        private readonly UserWorkerConsumerDelegateMediator _Mediator;

        #endregion

        #region Constructors

        protected UserWorkerConsumer() :
            base(IntPtr.Zero)
        {
            this._DataType = GenericHelpers.CheckDatumSupportTypes<T>();
            this._Mediator = new UserWorkerConsumerDelegateMediator(this._DataType)
            {
                InitializationOnThread = this.OnInitializationOnThread,
                Work = this.OnWork
            };
            this._Mediator.Setup();

            this.NativePtr = this._Mediator.NativePtr;
        }

        internal UserWorkerConsumer(IntPtr ptr, bool isEnabledDispose = true) :
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
                return NativeMethods.op_UserWorkerConsumer_isRunning(this._DataType, this.NativePtr);
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
            NativeMethods.op_UserWorkerConsumer_stop(this._DataType, this.NativePtr);
        }

        protected virtual void WorkConsumer(T[] datums)
        {
            this.ThrowIfDisposed();
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

            NativeMethods.op_UserWorkerConsumer_delete(this._DataType, this.NativePtr);

            this._Mediator?.Dispose();
        }

        #endregion

        #region Helpers

        private void OnInitializationOnThread()
        {
            this.InitializationOnThread();
        }

        private void OnWork(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                this.WorkConsumer(null);
                return;
            }

            // ptr is shared_ptr<std::vector<DATUM>>
            var content = NativeMethods.std_shared_ptr_TDatum_get(this._DataType, ptr);
            if (content == IntPtr.Zero)
            {
                this.WorkConsumer(null);
                return;
            }

            using (var vector = new StdVector<T>(content, false))
                this.WorkConsumer(vector.ToArray());
        }

        #endregion

        #endregion

    }

}