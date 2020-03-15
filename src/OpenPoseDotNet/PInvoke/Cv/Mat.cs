using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_3rdparty_cv_Mat_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_3rdparty_cv_Mat_new2(int rows, int cols, int type, IntPtr data);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_3rdparty_cv_Mat_delete(IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_3rdparty_cv_Mat_empty(IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_3rdparty_cv_Mat_type(IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_3rdparty_cv_Mat_data(IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_3rdparty_cv_Mat_rows(IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_3rdparty_cv_Mat_cols(IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_3rdparty_cv_Mat_channels(IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_3rdparty_cv_Mat_convertTo(IntPtr mat, IntPtr dst, int rtype, double alpha, double beta);

        #region Operators

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_3rdparty_cv_Mat_operator_add(IntPtr lhs, double rhs);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_3rdparty_cv_Mat_operator_multiply_int32_t(IntPtr lhs, int rhs);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_3rdparty_cv_Mat_operator_multiply_double(IntPtr lhs, double rhs);

        #endregion

    }

}