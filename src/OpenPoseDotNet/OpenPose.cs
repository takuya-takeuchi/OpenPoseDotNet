using System;
using System.Runtime.InteropServices;

namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        internal sealed partial class Native
        {

            public enum ArrayElementType
            {

                Float,

                Double

            }

            #region std::shared_ptr

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr std_shared_ptr_TDatum_get(DataType dataType, IntPtr p);

            #endregion

            #region op::Point

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_core_point_int_new(int x, int y);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_core_point_int_delete(IntPtr point);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_core_point_float_new(float x, float y);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_core_point_float_delete(IntPtr point);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_core_point_double_new(double x, double y);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_core_point_double_delete(IntPtr point);

            #endregion

            #region op::PoseRenderer

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_PoseRenderer_initializationOnThread(IntPtr poseRenderer);

            #endregion

            internal enum ErrorType
            {

                OK = 0x00000000,

                #region Common

                CommonError = 0x70000000,

                CommonErrorTypeNotSupport = -(CommonError | 0x00000001)

                #endregion

            }

        }

    }

}
