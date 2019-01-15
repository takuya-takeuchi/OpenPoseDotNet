using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class ThreadManager<T> : OpenPoseObject
        where T : Datum
    {

        #region Fields

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors

        public ThreadManager(ThreadManagerMode threadManagerMode = ThreadManagerMode.Synchronous)
        {
            this._DataType = GenericHelpers.CheckDatumSupportTypes<T>();
            this.NativePtr = NativeMethods.op_ThreadManager_new(this._DataType, threadManagerMode);
        }

        #endregion

        #region Methods

        public void Add<W>(ulong threadId, StdSharedPtr<W> tWorker, ulong queueInId, ulong queueOutId)
            where W : Worker<T>
        {
            this.ThrowIfDisposed();
            NativeMethods.op_ThreadManager_add(this._DataType, this.NativePtr, threadId, tWorker.NativePtr, queueInId, queueOutId);
        }

        public void Exec()
        {
            this.ThrowIfDisposed();
            NativeMethods.op_ThreadManager_exec(this._DataType, this.NativePtr);
        }

        public IntPtr GetIsRunningSharedPtr()
        {
            this.ThrowIfDisposed();
            return NativeMethods.op_ThreadManager_getIsRunningSharedPtr(this._DataType, this.NativePtr);
        }

        public void Reset()
        {
            this.ThrowIfDisposed();
            NativeMethods.op_ThreadManager_reset(this._DataType, this.NativePtr);
        }

        public void Start()
        {
            this.ThrowIfDisposed();
            NativeMethods.op_ThreadManager_start(this._DataType, this.NativePtr);
        }

        public void Stop()
        {
            this.ThrowIfDisposed();
            NativeMethods.op_ThreadManager_stop(this._DataType, this.NativePtr);
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

            NativeMethods.op_ThreadManager_delete(this._DataType, this.NativePtr);
        }

        #endregion

        #endregion

    }

}
