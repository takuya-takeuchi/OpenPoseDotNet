using System;

namespace OpenPoseDotNet
{

    public sealed class SharedHandle<T> : OpenPoseObject
        where T : IOpenPoseObject
    {

        #region Fields

        private readonly Func<IntPtr, T> _Creator;

        private readonly Action<IntPtr> _Deleter;

        private readonly Func<IntPtr, IntPtr> _Getter;

        #endregion

        #region Constructors

        internal SharedHandle(IntPtr ptr, Func<IntPtr, T> creater, Func<IntPtr, IntPtr> getter, Action<IntPtr> deleter)
        {
            if (creater == null)
                throw new ArgumentNullException(nameof(creater));
            if (getter == null)
                throw new ArgumentNullException(nameof(getter));
            if (deleter == null)
                throw new ArgumentNullException(nameof(deleter));

            this.NativePtr = ptr;
            this._Creator = creater;
            this._Getter = getter;
            this._Deleter = deleter;
        }

        #endregion

        #region Properties

        public T Data
        {
            get
            {
                this.ThrowIfDisposed();

                var ret = this._Getter(this.NativePtr);
                return this._Creator.Invoke(ret);
            }
        }

        #endregion

        #region Methods

        public bool GetData(out T data)
        {
            data = default(T);

            try
            {
                this.ThrowIfDisposed();
            }
            catch (ObjectDisposedException)
            {
                return false;
            }

            var ret = this._Getter(this.NativePtr);
            data = this._Creator.Invoke(ret);
            return true;
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

            this._Deleter.Invoke(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
