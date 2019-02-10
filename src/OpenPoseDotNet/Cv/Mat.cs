using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class Mat : OpenPoseObject
    {

        #region Constructors

        public Mat()
        {
            this.NativePtr = NativeMethods.op_3rdparty_cv_mat_new();
        }

        public Mat(int rows, int cols, int type, IntPtr data)
        {
            this.NativePtr = NativeMethods.op_3rdparty_cv_mat_new2(rows, cols, type, data);
        }

        internal Mat(IntPtr ptr, bool isEnabledDispose = true) :
            base(isEnabledDispose)
        {
            this.NativePtr = ptr;
        }

        #endregion

        #region Properties

        public int Channels
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_3rdparty_cv_mat_channels(this.NativePtr);
            }
        }

        public int Cols
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_3rdparty_cv_mat_cols(this.NativePtr);
            }
        }

        public bool Empty
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_3rdparty_cv_mat_empty(this.NativePtr);
            }
        }

        public int Rows
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_3rdparty_cv_mat_rows(this.NativePtr);
            }
        }

        public MatType Type
        {
            get
            {
                this.ThrowIfDisposed();
                var value = NativeMethods.op_3rdparty_cv_mat_type(this.NativePtr);
                return new MatType(value);
            }
        }

        #endregion

        #region Methods

        public void ConvertTo(Mat m, int rtype, double alpha = 1, double beta = 0)
        {
            this.ThrowIfDisposed();

            if (m == null)
                throw new ArgumentNullException(nameof(m));

            m.ThrowIfDisposed();

            NativeMethods.op_3rdparty_cv_mat_convertTo(this.NativePtr, m.NativePtr, rtype, alpha, beta);
        }

        public Bitmap ToBitmap()
        {
            this.ThrowIfDisposed();

            Bitmap bitmap = null;
            BitmapData data = null;

            try
            {
                var type = this.Type;
                var width = this.Cols;
                var height = this.Rows;
                var size = new Size(width, height);
                var channels = MatType.Channels(type);

                PixelFormat format;
                if (MatType.CV_8UC1 == type)
                    format = PixelFormat.Format8bppIndexed;
                else if (MatType.CV_8UC3 == type)
                    format = PixelFormat.Format24bppRgb;
                else if (MatType.CV_8UC4 == type)
                    format = PixelFormat.Format32bppArgb;
                else
                    throw new NotSupportedException($"{type}");

                bitmap = new Bitmap(width, height, format);
                data = bitmap.LockBits(new Rectangle(Point.Empty, size), ImageLockMode.WriteOnly, format);

                var stride = data.Stride;
                var scan0 = data.Scan0;

                var line = channels * width;
                var src = NativeMethods.op_3rdparty_cv_mat_data(this.NativePtr);

                unsafe
                {
                    var ps = (byte*)scan0;
                    for (var h = 0; h < height; h++)
                        NativeMethods.cstd_memcpy(ps + stride * h, src + h * line, line);
                }
            }
            catch (Exception)
            {
                bitmap?.Dispose();
                throw;
            }
            finally
            {
                if (data != null)
                    bitmap.UnlockBits(data);
            }

            return bitmap;
        }

        #region Overrides

        #region Operators

        public static MatExpr operator +(Mat lhs, double rhs)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));

            lhs.ThrowIfDisposed();

            var ret = NativeMethods.op_3rdparty_cv_mat_operator_add(lhs.NativePtr, rhs);
            return new MatExpr(ret);
        }

        public static MatExpr operator *(Mat lhs, int rhs)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));

            lhs.ThrowIfDisposed();

            var ret = NativeMethods.op_3rdparty_cv_mat_operator_multiply_int32_t(lhs.NativePtr, rhs);
            return new MatExpr(ret);
        }

        public static MatExpr operator *(Mat lhs, double rhs)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));

            lhs.ThrowIfDisposed();

            var ret = NativeMethods.op_3rdparty_cv_mat_operator_multiply_double(lhs.NativePtr, rhs);
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

            NativeMethods.op_3rdparty_cv_mat_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}