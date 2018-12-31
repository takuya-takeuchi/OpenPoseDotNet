using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        internal sealed partial class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_wrapper_new(DataType dataType, ThreadManagerMode threadManagerMode);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_delete(DataType dataType, IntPtr wrapper);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_disableMultiThreading(DataType dataType, IntPtr wrapper);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_setWorker(DataType dataType, IntPtr wrapper, WorkerType workerType, IntPtr worker, bool workerOnNewThread);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_exec(DataType dataType, IntPtr wrapper);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_start(DataType dataType, IntPtr wrapper);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_stop(DataType dataType, IntPtr wrapper);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_wrapper_isRunning(DataType dataType, IntPtr wrapper);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_configure_pose(DataType dataType, IntPtr wrapper, IntPtr wrapperStructPose);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_configure_face(DataType dataType, IntPtr wrapper, IntPtr wrapperStructFace);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_configure_hand(DataType dataType, IntPtr wrapper, IntPtr wrapperStructHand);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_configure_extra(DataType dataType, IntPtr wrapper, IntPtr wrapperStructExtra);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_configure_input(DataType dataType, IntPtr wrapper, IntPtr wrapperStructInput);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_configure_output(DataType dataType, IntPtr wrapper, IntPtr wrapperStructOutput);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_configure_gui(DataType dataType, IntPtr wrapper, IntPtr wrapperStructOutput);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_wrapper_waitAndEmplace(DataType dataType, IntPtr wrapper, IntPtr tDatums);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_wrapper_waitAndPop(DataType dataType, IntPtr wrapper, out IntPtr tDatums);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_wrapper_emplaceAndPop_cvMat(DataType dataType, IntPtr wrapper, IntPtr mat);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_wrapper_emplaceAndPop_rawImage(DataType dataType, 
                                                                          IntPtr wrapper,
                                                                          byte[] data,
                                                                          int width,
                                                                          int height,
                                                                          int type);

        }

    }

}