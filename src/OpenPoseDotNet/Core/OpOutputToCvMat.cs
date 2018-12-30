using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class OpOutputToCvMat : OpenPoseObject
    {

        #region Constructors

        public OpOutputToCvMat()
        {
            this.NativePtr = Native.op_core_OpOutputToCvMat_new();
        }

        #endregion

        #region Methods

        public Mat FormatToCvMat(Array<float> outputData)
        {
            if (outputData == null)
                throw new ArgumentNullException(nameof(outputData));

            outputData.ThrowIfDisposed();

            var ret = Native.op_core_OpOutputToCvMat_formatToCvMat(this.NativePtr, outputData.NativePtr);
            return new Mat(ret);
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

            Native.op_core_OpOutputToCvMat_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_core_OpOutputToCvMat_new();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_core_OpOutputToCvMat_delete(IntPtr mat);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_core_OpOutputToCvMat_formatToCvMat(IntPtr mat, IntPtr outputData);

        }

    }

}
