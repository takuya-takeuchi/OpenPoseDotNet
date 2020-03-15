using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_wrapper_new(OpenPose.DataType dataType, ThreadManagerMode threadManagerMode);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapper_delete(OpenPose.DataType dataType, IntPtr wrapper);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapper_disableMultiThreading(OpenPose.DataType dataType, IntPtr wrapper);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapper_setWorker(OpenPose.DataType dataType, IntPtr wrapper, WorkerType workerType, IntPtr worker, bool workerOnNewThread);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapper_exec(OpenPose.DataType dataType, IntPtr wrapper);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapper_start(OpenPose.DataType dataType, IntPtr wrapper);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapper_stop(OpenPose.DataType dataType, IntPtr wrapper);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_wrapper_isRunning(OpenPose.DataType dataType, IntPtr wrapper);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapper_configure_pose(OpenPose.DataType dataType, IntPtr wrapper, IntPtr wrapperStructPose);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapper_configure_face(OpenPose.DataType dataType, IntPtr wrapper, IntPtr wrapperStructFace);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapper_configure_hand(OpenPose.DataType dataType, IntPtr wrapper, IntPtr wrapperStructHand);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapper_configure_extra(OpenPose.DataType dataType, IntPtr wrapper, IntPtr wrapperStructExtra);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapper_configure_input(OpenPose.DataType dataType, IntPtr wrapper, IntPtr wrapperStructInput);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapper_configure_output(OpenPose.DataType dataType, IntPtr wrapper, IntPtr wrapperStructOutput);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapper_configure_gui(OpenPose.DataType dataType, IntPtr wrapper, IntPtr wrapperStructOutput);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_wrapper_waitAndEmplace(OpenPose.DataType dataType, IntPtr wrapper, IntPtr tDatums);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_wrapper_waitAndEmplace_cvMat(OpenPose.DataType dataType, IntPtr wrapper, IntPtr tDatums);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_wrapper_waitAndPop(OpenPose.DataType dataType, IntPtr wrapper, out IntPtr tDatums);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_wrapper_emplaceAndPop(OpenPose.DataType dataType, IntPtr wrapper, IntPtr tDatums);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_wrapper_emplaceAndPop_cvMat(OpenPose.DataType dataType, IntPtr wrapper, IntPtr mat);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_wrapper_emplaceAndPop_rawImage(OpenPose.DataType dataType,
                                                                      IntPtr wrapper,
                                                                      byte[] data,
                                                                      int width,
                                                                      int height,
                                                                      int type);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapper_setDefaultMaxSizeQueues(OpenPose.DataType dataType,
                                                                     IntPtr wrapper,
                                                                     long defaultMaxSizeQueues);

    }

}