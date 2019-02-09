using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_3rdparty_cv_bitwise_not(IntPtr src, IntPtr dst);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_3rdparty_cv_imread(byte[] path, int flags);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_3rdparty_cv_imshow(byte[] winname, IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_3rdparty_cv_waitKey(int delay);

    }

}
