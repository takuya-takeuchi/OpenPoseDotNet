using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_3rdparty_cv_mat_delete(IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_3rdparty_cv_mat_empty(IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_3rdparty_cv_mat_type(IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_3rdparty_cv_mat_data(IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_3rdparty_cv_mat_rows(IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_3rdparty_cv_mat_cols(IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_3rdparty_cv_mat_channels(IntPtr mat);

    }

}