using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class Matrix : OpenPoseObject
    {

        #region Constructors

        internal Matrix(IntPtr ptr, bool isEnabledDispose = true) :
            base(isEnabledDispose)
        {
            this.NativePtr = ptr;
        }

        #endregion

        #region Properties

        public bool Empty
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_core_Matrix_empty(this.NativePtr);
            }
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

            NativeMethods.op_core_Matrix_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}