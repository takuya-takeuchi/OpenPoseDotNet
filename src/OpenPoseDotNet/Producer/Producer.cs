using System;
using System.Runtime.InteropServices;

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
                return Native.op_Producer_isOpened(this.NativePtr);
            }
        }

        #endregion

        #region Methods

        public virtual double Get(int capProperty)
        {
            this.ThrowIfDisposed();
            return Native.op_Producer_get(this.NativePtr, capProperty);
        }

        public virtual void Release()
        {
            this.ThrowIfDisposed();
            Native.op_Producer_release(this.NativePtr);
        }

        public void SetProducerFpsMode(ProducerFpsMode fpsMode)
        {
            this.ThrowIfDisposed();
            Native.op_Producer_setProducerFpsMode(this.NativePtr, fpsMode);
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

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_Producer_get(IntPtr producer, int capProperty);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_Producer_setProducerFpsMode(IntPtr producer, ProducerFpsMode fpsMode);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_Producer_isOpened(IntPtr producer);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_Producer_release(IntPtr producer);

        }

    }

}