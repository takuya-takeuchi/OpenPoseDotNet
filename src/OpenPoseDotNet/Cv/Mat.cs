using System;
using System.Drawing;
using System.Drawing.Imaging;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class Mat : OpenPoseObject
    {

        #region Constructors

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
                    var ps = (byte*) scan0;
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