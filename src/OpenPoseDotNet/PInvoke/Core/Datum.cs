using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{
    
    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_datum_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_core_datum_delete(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ulong op_core_datum_get_id(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ulong op_core_datum_get_subId(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ulong op_core_datum_get_subIdMax(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ulong op_core_datum_get_frameNumber(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_datum_get_cvInputData(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_core_datum_set_cvInputData(IntPtr datum, IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_datum_get_cvOutputData(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_core_datum_set_cvOutputData(IntPtr datum, IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_datum_get_poseKeypoints(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_datum_get_inputNetData(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_datum_get_poseHeatMaps(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_datum_get_poseNetOutput(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_core_datum_set_poseNetOutput(IntPtr datum, IntPtr output);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_datum_get_faceKeypoints(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_datum_get_faceHeatMaps(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_datum_get_handKeypoints(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_datum_get_handHeatMaps(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_datum_get_faceRectangles(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_core_datum_set_faceRectangles(IntPtr datum, IntPtr rectangles);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_core_datum_get_handRectangles(IntPtr datum);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_core_datum_set_handRectangles(IntPtr datum, IntPtr rectangles);

    }

}
