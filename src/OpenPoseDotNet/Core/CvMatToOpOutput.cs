using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class CvMatToOpOutput : OpenPoseObject
    {

        #region Constructors

        public CvMatToOpOutput()
        {
            this.NativePtr = NativeMethods.op_core_CvMatToOpOutput_new();
        }

        #endregion

        #region Methods

        public Array<float> CreateArray(Matrix cvInputData, double scaleInputToOutput, Point<int> outputResolution)
        {
            if (cvInputData == null)
                throw new ArgumentNullException(nameof(cvInputData));

            this.ThrowIfDisposed();

            using (var resolution = outputResolution.ToNative())
            {
                var ret = NativeMethods.op_core_CvMatToOpOutput_createArray(this.NativePtr, cvInputData.NativePtr, scaleInputToOutput, resolution.NativePtr);
                return new Array<float>(ret);
            }
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

            NativeMethods.op_core_CvMatToOpOutput_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
