using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class CvMatToOpInput : OpenPoseObject
    {

        #region Constructors

        public CvMatToOpInput(PoseModel poseModel = PoseModel.Body25)
        {
            this.NativePtr = NativeMethods.op_core_CvMatToOpInput_new(poseModel);
        }

        #endregion

        #region Methods

        public Array<float>[] CreateArray(Mat cvInputData, double[] scaleInputToNetInputs, Point<int>[] netInputSizes)
        {
            if (cvInputData == null)
                throw new ArgumentNullException(nameof(cvInputData));

            this.ThrowIfDisposed();

            using (var scaleVector = new StdVector<double>(scaleInputToNetInputs))
            using (var netInputSizesVector = new StdVector<Point<int>>(netInputSizes))
            {
                var ret = NativeMethods.op_core_CvMatToOpInput_createArray(this.NativePtr, cvInputData.NativePtr, scaleVector.NativePtr, netInputSizesVector.NativePtr);
                using (var vector = new StdVector<Array<float>>(ret))
                    return vector.ToArray();
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

            NativeMethods.op_core_CvMatToOpInput_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
