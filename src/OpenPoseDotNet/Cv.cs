using System;
using System.IO;
using System.Text;

namespace OpenPoseDotNet
{

    public static class Cv
    {

        #region Methods

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

        public static void ImShow(string winName, Mat mat)
        {
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));

            mat.ThrowIfDisposed();

            var winnameBytes = Encoding.UTF8.GetBytes(winName ?? "");
            NativeMethods.op_3rdparty_cv_imshow(winnameBytes, mat.NativePtr);
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
