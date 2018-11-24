using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenPoseDotNet
{

    public static class Cv
    {

        #region Events
        #endregion

        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Methods

        public static Mat ImRead(string path, int flags = 1)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path))
                throw new FileNotFoundException($"{nameof(path)} is not found.", path);

            var passBytes = Encoding.UTF8.GetBytes(path);
            var ret = Native.op_3rdparty_cv_imread(passBytes, flags);
            return new Mat(ret);
        }

        public static void ImShow(string winName, Mat mat)
        {
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));

            mat.ThrowIfDisposed();

            var winnameBytes = Encoding.UTF8.GetBytes(winName ?? "");
            Native.op_3rdparty_cv_imshow(winnameBytes, mat.NativePtr);
        }

        public static int WaitKey(int delay = 0)
        {
            return Native.op_3rdparty_cv_waitKey(delay);
        }

        #region Overrids
        #endregion

        #region Event Handlers
        #endregion

        #region Helpers
        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_3rdparty_cv_imread(byte[] path, int flags);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_3rdparty_cv_imshow(byte[] winname, IntPtr mat);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_3rdparty_cv_waitKey(int delay);

        }

    }

}
