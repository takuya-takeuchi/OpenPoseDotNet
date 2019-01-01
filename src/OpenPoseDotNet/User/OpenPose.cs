using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        internal sealed partial class Native
        {


            #region UserWorker

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_UserWorker_new(DataType dataType, IntPtr initializationOnThread_function, IntPtr process_function);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_UserWorker_delete(DataType dataType, IntPtr worker);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_UserWorker_checkAndWork(DataType dataType, IntPtr worker, IntPtr datums);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_UserWorker_isRunning(DataType dataType, IntPtr worker);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_UserWorker_stop(DataType dataType, IntPtr worker);

            #endregion

            #region UserWorkerConsumer

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_UserWorkerConsumer_new(DataType dataType, IntPtr initializationOnThread_function, IntPtr process_function);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_UserWorkerConsumer_delete(DataType dataType, IntPtr worker);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_UserWorkerConsumer_checkAndWork(DataType dataType, IntPtr worker, IntPtr datums);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_UserWorkerConsumer_isRunning(DataType dataType, IntPtr worker);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_UserWorkerConsumer_stop(DataType dataType, IntPtr worker);

            #endregion

            #region UserWorkerProducer

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_UserWorkerProducer_new(DataType dataType, IntPtr initializationOnThread_function, IntPtr process_function);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_UserWorkerProducer_delete(DataType dataType, IntPtr worker);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_UserWorkerProducer_checkAndWork(DataType dataType, IntPtr worker, IntPtr datums);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_UserWorkerProducer_isRunning(DataType dataType, IntPtr worker);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_UserWorkerProducer_stop(DataType dataType, IntPtr worker);

            #endregion

        }

    }

}