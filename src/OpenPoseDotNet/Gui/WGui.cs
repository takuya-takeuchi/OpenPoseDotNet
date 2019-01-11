using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class WGui<T> : WorkerConsumer<T>
        where T : Datum
    {

        #region Fields

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors

        public WGui(StdSharedPtr<Gui> gui)
        {
            if (gui == null)
                throw new ArgumentNullException(nameof(gui));

            gui.ThrowIfDisposed();

            this._DataType = GenericHelpers.CheckDatumSupportTypes<T>();
            this.NativePtr = NativeMethods.op_WGui_new(this._DataType, gui.NativePtr);
        }

        internal WGui(IntPtr ptr, bool isEnabledDispose = true) :
            base(ptr, isEnabledDispose)
        {
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

            NativeMethods.op_WGui_delete(this._DataType, this.NativePtr);
        }

        #endregion

        #endregion

    }

}