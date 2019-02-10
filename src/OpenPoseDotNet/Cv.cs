using System;
using System.IO;
using System.Text;

namespace OpenPoseDotNet
{

    public static class Cv
    {

        #region Methods

        public static void AddWeighted(Mat src1, double alpha, Mat src2, double beta, double gamma, Mat dst)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.op_3rdparty_addWeighted(src1.NativePtr, alpha, src2.NativePtr, beta, gamma, dst.NativePtr);
        }

        public static void ApplyColorMap(Mat src, Mat dst, ColormapType colormap)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.op_3rdparty_applyColorMap(src.NativePtr, dst.NativePtr, colormap);
        }

        public static void BitwiseNot(Mat src, Mat dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.op_3rdparty_cv_bitwise_not(src.NativePtr, dst.NativePtr);
        }

        public static Mat ImRead(string path, int flags = 1)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path))
                throw new FileNotFoundException($"{nameof(path)} is not found.", path);

            var passBytes = Encoding.UTF8.GetBytes(path);
            var ret = NativeMethods.op_3rdparty_cv_imread(passBytes, flags);
            return new Mat(ret);
        }

        public static void ImWrite(string path, Mat mat)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException();
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));

            mat.ThrowIfDisposed();

            var passBytes = Encoding.UTF8.GetBytes(path);
            NativeMethods.op_3rdparty_cv_imwrite(passBytes, mat.NativePtr);
        }

        public static void ImShow(string winName, Mat mat)
        {
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));

            mat.ThrowIfDisposed();

            var winnameBytes = Encoding.UTF8.GetBytes(winName ?? "");
            NativeMethods.op_3rdparty_cv_imshow(winnameBytes, mat.NativePtr);
        }

        public static void Merge(StdVector<Mat> mv, Mat dst)
        {
            if (mv == null)
                throw new ArgumentNullException(nameof(mv));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            mv.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.op_3rdparty_cv_merge(mv.NativePtr, dst.NativePtr);
        }

        public static int WaitKey(int delay = 0)
        {
            return NativeMethods.op_3rdparty_cv_waitKey(delay);
        }

        #region Overrides
        #endregion

        #region Event Handlers
        #endregion

        #region Helpers
        #endregion

        #endregion

    }

}
