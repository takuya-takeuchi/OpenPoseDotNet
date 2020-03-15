using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        #region Methods

        #region Matrix

        public static Mat OP_OP2CVCONSTMAT(Matrix cvMat)
        {
            if (cvMat == null)
                throw new ArgumentNullException(nameof(cvMat));
            var ret = NativeMethods.op_core_Matrix_OP_OP2CVCONSTMAT(cvMat.NativePtr);
            return new Mat(ret);
        }

        public static Mat OP_OP2CVMAT(Matrix cvMat)
        {
            if (cvMat == null)
                throw new ArgumentNullException(nameof(cvMat));
            var ret = NativeMethods.op_core_Matrix_OP_OP2CVMAT(cvMat.NativePtr);
            return new Mat(ret);
        }

        public static Matrix OP_CV2OPCONSTMAT(Mat cvMat)
        {
            if (cvMat == null)
                throw new ArgumentNullException(nameof(cvMat));
            var ret = NativeMethods.op_core_Matrix_OP_CV2OPCONSTMAT(cvMat.NativePtr);
            return new Matrix(ret);
        }

        #endregion

        #endregion

    }

}
