using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class CvMatToOpInput : OpenPoseObject
    {

        #region Constructors

        public CvMatToOpInput(PoseModel poseModel = PoseModel.Body25)
        {
            this.NativePtr = Native.op_core_CvMatToOpInput_new(poseModel);
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
                var ret = Native.op_core_CvMatToOpInput_createArray(this.NativePtr, cvInputData.NativePtr, scaleVector.NativePtr, netInputSizesVector.NativePtr);
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

            Native.op_core_CvMatToOpInput_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_core_CvMatToOpInput_new(PoseModel poseModel);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_core_CvMatToOpInput_delete(IntPtr extractor);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_core_CvMatToOpInput_createArray(IntPtr output,
                                                                           IntPtr cvInputData,
                                                                           IntPtr scaleInputToNetInputs,
                                                                           IntPtr netInputSizes);

        }

    }

}
