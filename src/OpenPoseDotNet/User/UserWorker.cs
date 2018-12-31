using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public class UserWorker<T> : Worker<T>
    {

        #region Fields

        private readonly OpenPose.DataType _DataType;

        private readonly UserWorkerDelegateMediator _Mediator;

        #endregion

        #region Constructors

        protected UserWorker() :
            base(IntPtr.Zero)
        {
            this._DataType = GenericHelpers.CheckDatumSupportTypes<T>();
            this._Mediator = new UserWorkerDelegateMediator(this._DataType)
            {
                InitializationOnThread = this.OnInitializationOnThread,
                Work = this.OnWork
            };

            this.NativePtr = this._Mediator.NativePtr;
        }

        internal UserWorker(IntPtr ptr, bool isEnabledDispose = true) :
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
                return OpenPose.Native.op_UserWorker_isRunning(this._DataType, this.NativePtr);
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
            OpenPose.Native.op_UserWorker_stop(this._DataType, this.NativePtr);
        }

        protected virtual void Work(T[] datums)
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

            OpenPose.Native.op_UserWorker_delete(this._DataType, this.NativePtr);

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
                this.Work(null);
                return;
            }

            // ptr is shared_ptr<std::vector<DATUM>>
            var content = OpenPose.Native.std_shared_ptr_TDatum_get(this._DataType, ptr);
            if (content == IntPtr.Zero)
            {
                this.Work(null);
                return;
            }

            using (var vector = new StdVector<T>(content, false))
                this.Work(vector.ToArray());
        }

        #endregion

        #endregion

    }

}