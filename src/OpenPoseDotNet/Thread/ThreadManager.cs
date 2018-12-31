using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class ThreadManager<T> : OpenPoseObject
    {

        #region Fields

        private static readonly Dictionary<Type, DatumType> SupportTypes = new Dictionary<Type, DatumType>();

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors

        static ThreadManager()
        {
            var types = new[]
            {
                new { Type = typeof(Datum),       ElementType = DatumType.Datum },
                new { Type = typeof(CustomDatum), ElementType = DatumType.CustomDatum }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        public ThreadManager(ThreadManagerMode threadManagerMode = ThreadManagerMode.Synchronous)
        {
            if (!SupportTypes.TryGetValue(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            switch (type)
            {
                case DatumType.Datum:
                    this._DataType = OpenPose.DataType.Default;
                    break;
                case DatumType.CustomDatum:
                    this._DataType = OpenPose.DataType.Custom;
                    break;
            }

            this.NativePtr = OpenPose.Native.op_ThreadManager_new(this._DataType, threadManagerMode);
        }

        #endregion

        #region Methods

        public void Add<W>(ulong threadId, StdSharedPtr<W> tWorker, ulong queueInId, ulong queueOutId)
            where W : Worker<T>
        {
            this.ThrowIfDisposed();
            OpenPose.Native.op_ThreadManager_add(this._DataType, this.NativePtr, threadId, tWorker.NativePtr, queueInId, queueOutId);
        }

        public void Exec()
        {
            this.ThrowIfDisposed();
            OpenPose.Native.op_ThreadManager_exec(this._DataType, this.NativePtr);
        }

        public IntPtr GetIsRunningSharedPtr()
        {
            this.ThrowIfDisposed();
            return OpenPose.Native.op_ThreadManager_getIsRunningSharedPtr(this._DataType, this.NativePtr);
        }

        public void Reset()
        {
            this.ThrowIfDisposed();
            OpenPose.Native.op_ThreadManager_reset(this._DataType, this.NativePtr);
        }

        public void Start()
        {
            this.ThrowIfDisposed();
            OpenPose.Native.op_ThreadManager_start(this._DataType, this.NativePtr);
        }

        public void Stop()
        {
            this.ThrowIfDisposed();
            OpenPose.Native.op_ThreadManager_stop(this._DataType, this.NativePtr);
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

            OpenPose.Native.op_ThreadManager_delete(this._DataType, this.NativePtr);
        }

        #endregion

        #endregion

    }

}
