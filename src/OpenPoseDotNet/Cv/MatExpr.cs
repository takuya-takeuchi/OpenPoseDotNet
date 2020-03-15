using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class MatExpr : OpenPoseObject
    {

        #region Constructors

        internal MatExpr(IntPtr ptr, bool isEnabledDispose = true) :
            base(isEnabledDispose)
        {
            this.NativePtr = ptr;
        }

        #endregion

        #region Methods

        #region Overrides

        #region Operators

        public static implicit operator Mat(MatExpr self)
        {
            IntPtr retPtr = NativeMethods.op_3rdparty_cv_MatExpr_toMat(self.NativePtr);
            return new Mat(retPtr);
        }

        public static MatExpr operator +(MatExpr lhs, double rhs)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));

            lhs.ThrowIfDisposed();

            var ret = NativeMethods.op_3rdparty_cv_MatExpr_operator_add(lhs.NativePtr, rhs);
            return new MatExpr(ret);
        }

        public static MatExpr operator *(MatExpr lhs, int rhs)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));

            lhs.ThrowIfDisposed();

            var ret = NativeMethods.op_3rdparty_cv_MatExpr_operator_multiply_int32_t(lhs.NativePtr, rhs);
            return new MatExpr(ret);
        }

        public static MatExpr operator *(MatExpr lhs, double rhs)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));

            lhs.ThrowIfDisposed();

            var ret = NativeMethods.op_3rdparty_cv_MatExpr_operator_multiply_double(lhs.NativePtr, rhs);
            return new MatExpr(ret);
        }

        #endregion

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            NativeMethods.op_3rdparty_cv_MatExpr_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}