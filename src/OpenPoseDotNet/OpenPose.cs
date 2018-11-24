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

                Float

            }

            #region op::Arrray

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_core_array_delete(IntPtr datum);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_core_Array_toString(IntPtr array, ArrayElementType elementType);

            #endregion

            #region std::shared_ptr

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_shared_ptr_TDatums_delete(IntPtr ptr);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_shared_ptr_TDatums_getter(IntPtr ptr);

            #endregion

        }

    }

}
