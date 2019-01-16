using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        #region UserWorker

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_UserWorker_new(OpenPose.DataType dataType, IntPtr initializationOnThread_function, IntPtr process_function);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_UserWorker_delete(OpenPose.DataType dataType, IntPtr worker);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_UserWorker_checkAndWork(OpenPose.DataType dataType, IntPtr worker, IntPtr datums);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_UserWorker_isRunning(OpenPose.DataType dataType, IntPtr worker);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_UserWorker_stop(OpenPose.DataType dataType, IntPtr worker);

        #endregion

        #region UserWorkerConsumer

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_UserWorkerConsumer_new(OpenPose.DataType dataType, IntPtr initializationOnThread_function, IntPtr process_function);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_UserWorkerConsumer_delete(OpenPose.DataType dataType, IntPtr worker);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_UserWorkerConsumer_checkAndWork(OpenPose.DataType dataType, IntPtr worker, IntPtr datums);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_UserWorkerConsumer_isRunning(OpenPose.DataType dataType, IntPtr worker);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_UserWorkerConsumer_stop(OpenPose.DataType dataType, IntPtr worker);

        #endregion

        #region UserWorkerProducer

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_UserWorkerProducer_new(OpenPose.DataType dataType, IntPtr initializationOnThread_function, IntPtr process_function);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_UserWorkerProducer_delete(OpenPose.DataType dataType, IntPtr worker);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_UserWorkerProducer_checkAndWork(OpenPose.DataType dataType, IntPtr worker, IntPtr datums);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_UserWorkerProducer_isRunning(OpenPose.DataType dataType, IntPtr worker);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_UserWorkerProducer_stop(OpenPose.DataType dataType, IntPtr worker);

        #endregion

    }

}