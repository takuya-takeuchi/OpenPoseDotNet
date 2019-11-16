using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class OpOutputToCvMat : OpenPoseObject
    {

        #region Constructors

        public OpOutputToCvMat()
        {
            this.NativePtr = NativeMethods.op_core_OpOutputToCvMat_new();
        }

        #endregion

        #region Methods

        public Matrix FormatToCvMat(Array<float> outputData)
        {
            if (outputData == null)
                throw new ArgumentNullException(nameof(outputData));

            outputData.ThrowIfDisposed();

            var ret = NativeMethods.op_core_OpOutputToCvMat_formatToCvMat(this.NativePtr, outputData.NativePtr);
            return new Matrix(ret);
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

            NativeMethods.op_core_OpOutputToCvMat_delete(this.NativePtr);
        }

        #endregion

        #endregion
        
    }

}
