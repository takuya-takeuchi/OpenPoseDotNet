using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        #region stdlib

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void stdlib_free(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr stdlib_malloc(IntPtr size);

        #endregion

        #region string

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_string_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_string_append(IntPtr str, StringBuilder c_str, int len);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_string_c_str(IntPtr str);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_string_delete(IntPtr str);

        #endregion

        #region ostringstream

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr ostringstream_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr ostringstream_str(IntPtr str);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void ostringstream_delete(IntPtr str);

        #endregion

        #region array

        #region op::Array<float>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_array_op_Array_float_new1(int templateSize);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_array_op_Array_float_getSize(IntPtr array, int templateSize);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_array_op_Array_float_getPointer(IntPtr array, int templateSize);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool std_array_op_Array_float_empty(IntPtr array, int templateSize);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_array_op_Array_float_delete(IntPtr array, int templateSize);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_array_op_Array_float_copy(IntPtr array, IntPtr[] dst, int templateSize);

        #endregion

        #endregion

        #region vector

        #region int32_t

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_int32_t_new1();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_int32_t_new2(IntPtr size);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_int32_t_new3([In] int[] data, IntPtr dataLength);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_int32_t_getSize(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_int32_t_getPointer(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern int std_vector_int32_t_at(IntPtr vector, int index);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool std_vector_int32_t_empty(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_int32_t_delete(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_int32_t_emplace_back(IntPtr vector);

        #endregion

        #region uint32_t

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_uint32_t_new1();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_uint32_t_new2(IntPtr size);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_uint32_t_new3([In] uint[] data, IntPtr dataLength);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_uint32_t_getSize(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_uint32_t_getPointer(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern uint std_vector_uint32_t_at(IntPtr vector, int index);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool std_vector_uint32_t_empty(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_uint32_t_delete(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_uint32_t_emplace_back(IntPtr vector);

        #endregion

        #region float

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_float_new1();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_float_new2(IntPtr size);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_float_new3([In] float[] data, IntPtr dataLength);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_float_getSize(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_float_getPointer(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern int std_vector_float_at(IntPtr vector, int index);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool std_vector_float_empty(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_float_delete(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_float_emplace_back(IntPtr vector);

        #endregion

        #region double

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_double_new1();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_double_new2(IntPtr size);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_double_new3([In] double[] data, IntPtr dataLength);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_double_getSize(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_double_getPointer(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern int std_vector_double_at(IntPtr vector, int index);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool std_vector_double_empty(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_double_delete(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_double_emplace_back(IntPtr vector);

        #endregion

        #region ErrorMode

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_ErrorMode_new1();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_ErrorMode_new2(IntPtr size);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_ErrorMode_new3([In] ErrorMode[] data, IntPtr dataLength);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_ErrorMode_getSize(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_ErrorMode_getPointer(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern ErrorMode std_vector_ErrorMode_at(IntPtr vector, int index);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool std_vector_ErrorMode_empty(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_ErrorMode_delete(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_ErrorMode_emplace_back(IntPtr vector);

        #endregion

        #region LogMode

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_LogMode_new1();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_LogMode_new2(IntPtr size);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_LogMode_new3([In] LogMode[] data, IntPtr dataLength);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_LogMode_getSize(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_LogMode_getPointer(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern LogMode std_vector_LogMode_at(IntPtr vector, int index);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool std_vector_LogMode_empty(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_LogMode_delete(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_LogMode_emplace_back(IntPtr vector);

        #endregion

        #region Point<int>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_PointOfInt32_t_new1();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_PointOfInt32_t_new2(IntPtr size);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_PointOfInt32_t_new3([In] NativeMethods.NativePointOfInt32[] data, IntPtr dataLength);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_PointOfInt32_t_getSize(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_PointOfInt32_t_getPointer(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_PointOfInt32_t_at(IntPtr vector, int index);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool std_vector_PointOfInt32_t_empty(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_PointOfInt32_t_delete(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_PointOfInt32_t_emplace_back(IntPtr vector);

        #endregion
        
        #region Rectangle<float>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_RectangleOfFloat_new1();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_RectangleOfFloat_new2(IntPtr size);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_RectangleOfFloat_new3([In] NativeMethods.NativeRectangleOfFloat[] data, IntPtr dataLength);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_RectangleOfFloat_getSize(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_RectangleOfFloat_getPointer(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_RectangleOfFloat_at(IntPtr vector, int index);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool std_vector_RectangleOfFloat_empty(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_RectangleOfFloat_delete(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_RectangleOfFloat_emplace_back(IntPtr vector);

        #endregion

        #region Array<float>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_op_ArrayOfFloat_new1();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_op_ArrayOfFloat_new2(IntPtr size);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_op_ArrayOfFloat_new3([In] IntPtr[] data, IntPtr dataLength);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_op_ArrayOfFloat_new4([In] IntPtr[] data, IntPtr dataLength);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_op_ArrayOfFloat_getSize(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_op_ArrayOfFloat_getPointer(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_op_ArrayOfFloat_at(IntPtr vector, int index);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool std_vector_op_ArrayOfFloat_empty(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_op_ArrayOfFloat_delete(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_op_ArrayOfFloat_copy(IntPtr vector, IntPtr[] dst);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_op_ArrayOfFloat_emplace_back(IntPtr vector);

        #endregion

        #region Datum

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_Datum_new1();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_Datum_new2(IntPtr size);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_Datum_new3([In] IntPtr[] data, IntPtr dataLength);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_Datum_getSize(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_Datum_getPointer(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_Datum_at(IntPtr vector, int index);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool std_vector_Datum_empty(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_Datum_delete(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_Datum_copy(IntPtr vector, IntPtr[] dst);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_Datum_emplace_back(IntPtr vector);

        #endregion

        #region CustomDatum

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_CustomDatum_new1();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_CustomDatum_new2(IntPtr size);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_CustomDatum_new3([In] IntPtr[] data, IntPtr dataLength);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_CustomDatum_getSize(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_CustomDatum_getPointer(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_CustomDatum_at(IntPtr vector, int index);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool std_vector_CustomDatum_empty(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_CustomDatum_delete(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_CustomDatum_copy(IntPtr vector, IntPtr[] dst);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_CustomDatum_emplace_back(IntPtr vector);

        #endregion

        #region StdSharedPtr<Datum>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_StdSharedPtrOfDatum_new1();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_StdSharedPtrOfDatum_new2(IntPtr size);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_StdSharedPtrOfDatum_new3([In] IntPtr[] data, IntPtr dataLength);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_StdSharedPtrOfDatum_getSize(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_StdSharedPtrOfDatum_getPointer(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_StdSharedPtrOfDatum_at(IntPtr vector, int index);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool std_vector_StdSharedPtrOfDatum_empty(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_StdSharedPtrOfDatum_delete(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_StdSharedPtrOfDatum_copy(IntPtr vector, IntPtr[] dst);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_StdSharedPtrOfDatum_emplace_back(IntPtr vector);

        #endregion

        #region StdSharedPtr<CustomDatum>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_StdSharedPtrOfCustomDatum_new1();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_StdSharedPtrOfCustomDatum_new2(IntPtr size);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_StdSharedPtrOfCustomDatum_new3([In] IntPtr[] data, IntPtr dataLength);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_StdSharedPtrOfCustomDatum_getSize(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_StdSharedPtrOfCustomDatum_getPointer(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_StdSharedPtrOfCustomDatum_at(IntPtr vector, int index);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool std_vector_StdSharedPtrOfCustomDatum_empty(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_StdSharedPtrOfCustomDatum_delete(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_StdSharedPtrOfCustomDatum_copy(IntPtr vector, IntPtr[] dst);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_StdSharedPtrOfCustomDatum_emplace_back(IntPtr vector);

        #endregion

        #region HeatMapType

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_HeatMapType_new1();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_HeatMapType_new2(IntPtr size);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_HeatMapType_new3([In] HeatMapType[] data, IntPtr dataLength);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_HeatMapType_getSize(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_vector_HeatMapType_getPointer(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern HeatMapType std_vector_HeatMapType_at(IntPtr vector, int index);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool std_vector_HeatMapType_empty(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_HeatMapType_delete(IntPtr vector);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_vector_HeatMapType_emplace_back(IntPtr vector);

        #endregion

        #endregion

        #region share_ptr

        #region op::Datum

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_Datum_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_Datum_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_Datum_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_Datum_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_Datum_reset(IntPtr p, IntPtr obj);

        #endregion

        #region CustomDatum

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_CustomDatum_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_CustomDatum_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_CustomDatum_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_CustomDatum_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_CustomDatum_reset(IntPtr p, IntPtr obj);

        #endregion

        #region std::vector<op::Datum>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_StdVectorOfDatum_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_StdVectorOfDatum_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_StdVectorOfDatum_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_StdVectorOfDatum_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_StdVectorOfDatum_reset(IntPtr p, IntPtr obj);

        #endregion

        #region std::vector<CustomDatum>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_StdVectorOfCustomDatum_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_StdVectorOfCustomDatum_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_StdVectorOfCustomDatum_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_StdVectorOfCustomDatum_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_StdVectorOfCustomDatum_reset(IntPtr p, IntPtr obj);

        #endregion

        #region std::vector<std::shared_ptr<Datum>>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_StdVectorOfStdSharedPtrOfDatum_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_StdVectorOfStdSharedPtrOfDatum_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_StdVectorOfStdSharedPtrOfDatum_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_StdVectorOfStdSharedPtrOfDatum_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_StdVectorOfStdSharedPtrOfDatum_reset(IntPtr p, IntPtr obj);

        #endregion

        #region std::vector<std::shared_ptr<CustomDatum>>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_StdVectorOfStdSharedPtrOfCustomDatum_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_StdVectorOfStdSharedPtrOfCustomDatum_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_StdVectorOfStdSharedPtrOfCustomDatum_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_StdVectorOfStdSharedPtrOfCustomDatum_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_StdVectorOfStdSharedPtrOfCustomDatum_reset(IntPtr p, IntPtr obj);

        #endregion

        #region op::PoseExtractorCaffe

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_PoseExtractorCaffe_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_PoseExtractorCaffe_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_op_PoseExtractorCaffe_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_PoseExtractorCaffe_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_PoseExtractorCaffe_reset(IntPtr p, IntPtr obj);

        #endregion

        #region op::Producer

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_Producer_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_Producer_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_op_Producer_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_Producer_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_Producer_reset(IntPtr p, IntPtr obj);

        #endregion

        #region op::Gui

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_Gui_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_Gui_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_op_Gui_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_Gui_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_Gui_reset(IntPtr p, IntPtr obj);

        #endregion

        #region op::WGui

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_WGui_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_WGui_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_op_WGui_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_WGui_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_WGui_reset(IntPtr p, IntPtr obj);

        #endregion

        #region op::DatumProducer<std::vector<op::Datum>>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_DatumProducerOfDatum_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_DatumProducerOfDatum_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_op_DatumProducerOfDatum_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_DatumProducerOfDatum_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_DatumProducerOfDatum_reset(IntPtr p, IntPtr obj);

        #endregion

        #region op::WDatumProducer<std::shared_ptr<std::vector<op::Datum>>, std::vector<op::Datum>>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_WDatumProducerOfDatum_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_WDatumProducerOfDatum_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_op_WDatumProducerOfDatum_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_WDatumProducerOfDatum_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_WDatumProducerOfDatum_reset(IntPtr p, IntPtr obj);

        #endregion

        #region op::UserWorker<Datum>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerOfDefault_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerOfDefault_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_op_UserWorkerOfDefault_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerOfDefault_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerOfDefault_reset(IntPtr p, IntPtr obj);

        #endregion

        #region op::UserWorker<CustomDatum>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerOfCustom_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerOfCustom_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_op_UserWorkerOfCustom_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerOfCustom_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerOfCustom_reset(IntPtr p, IntPtr obj);

        #endregion

        #region op::UserWorkerConsumer<Datum>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerConsumerOfDefault_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerConsumerOfDefault_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_op_UserWorkerConsumerOfDefault_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerConsumerOfDefault_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerConsumerOfDefault_reset(IntPtr p, IntPtr obj);

        #endregion

        #region op::UserWorkerConsumer<CustomDatum>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerConsumerOfCustom_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerConsumerOfCustom_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_op_UserWorkerConsumerOfCustom_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerConsumerOfCustom_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerConsumerOfCustom_reset(IntPtr p, IntPtr obj);

        #endregion

        #region op::UserWorkerProducer<Datum>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerProducerOfDefault_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerProducerOfDefault_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_op_UserWorkerProducerOfDefault_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerProducerOfDefault_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerProducerOfDefault_reset(IntPtr p, IntPtr obj);

        #endregion

        #region op::UserWorkerProducer<CustomDatum>

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerProducerOfCustom_new();

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerProducerOfCustom_new2(IntPtr ptr);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void std_shared_ptr_op_UserWorkerProducerOfCustom_delete(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerProducerOfCustom_get(IntPtr p);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_op_UserWorkerProducerOfCustom_reset(IntPtr p, IntPtr obj);

        #endregion

        #endregion

    }

}
