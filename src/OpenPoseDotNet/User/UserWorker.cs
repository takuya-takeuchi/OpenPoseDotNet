using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public class UserWorker<T> : Worker<T>
    {

        #region Delegates

        private delegate void InitializationOnThreadAction();

        private delegate void ProcessAction(IntPtr datums);

        #endregion

        #region Fields

        private readonly InitializationOnThreadAction _InitializationOnThreadAction;

        private readonly ProcessAction _ProcessAction;

        private readonly IntPtr _InitializationOnThreadActionPointer;

        private readonly IntPtr _ProcessActionPointer;

        private static readonly Dictionary<Type, DatumType> SupportTypes = new Dictionary<Type, DatumType>();

        private readonly OpenPose.DataType _DataType;

        private readonly UserWorkerDelegateMediator _Mediator;

        #endregion

        #region Constructors

        static UserWorker()
        {
            var types = new[]
            {
                new { Type = typeof(Datum),       ElementType = DatumType.Default },
                new { Type = typeof(CustomDatum), ElementType = DatumType.Custom }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        protected UserWorker() :
            base(IntPtr.Zero)
        {
            if (!SupportTypes.TryGetValue(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            switch (type)
            {
                case DatumType.Default:
                    this._DataType = OpenPose.DataType.Default;
                    break;
                case DatumType.Custom:
                    this._DataType = OpenPose.DataType.Custom;
                    break;
            }

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
            if (!SupportTypes.TryGetValue(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            switch (type)
            {
                case DatumType.Default:
                    this._DataType = OpenPose.DataType.Default;
                    break;
                case DatumType.Custom:
                    this._DataType = OpenPose.DataType.Custom;
                    break;
            }

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

            var content = OpenPose.Native.op_shared_ptr_TDatums_getter(ptr);
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