using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public abstract class Producer : OpenPoseObject
    {

        #region Constructors

        internal Producer(IntPtr ptr, bool isEnabledDispose = true) :
            base(isEnabledDispose)
        {
            this.NativePtr = ptr;
        }

        #endregion

        #region Properties

        public virtual bool IsOpened
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_Producer_isOpened(this.NativePtr);
            }
        }

        #endregion

        #region Methods

        public virtual double Get(int capProperty)
        {
            this.ThrowIfDisposed();
            return NativeMethods.op_Producer_get(this.NativePtr, capProperty);
        }

        public virtual void Release()
        {
            this.ThrowIfDisposed();
            NativeMethods.op_Producer_release(this.NativePtr);
        }

        public void SetProducerFpsMode(ProducerFpsMode fpsMode)
        {
            this.ThrowIfDisposed();
            NativeMethods.op_Producer_setProducerFpsMode(this.NativePtr, fpsMode);
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

            // This class should be used in std::shared_ptr.
            // So we need not to consider dispose object
        }

        #endregion

        #endregion

    }

}