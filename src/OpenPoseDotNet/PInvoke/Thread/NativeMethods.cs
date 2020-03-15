using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_ThreadManager_new(OpenPose.DataType dataType, ThreadManagerMode threadManagerMode);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_ThreadManager_delete(OpenPose.DataType dataType, IntPtr threadManager);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_ThreadManager_add(OpenPose.DataType dataType,
                                                       IntPtr threadManager,
                                                       ulong threadId,
                                                       IntPtr tWorker,
                                                       ulong queueInId,
                                                       ulong queueOutId);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_ThreadManager_reset(OpenPose.DataType dataType, IntPtr threadManager);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_ThreadManager_exec(OpenPose.DataType dataType, IntPtr threadManager);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_ThreadManager_start(OpenPose.DataType dataType, IntPtr threadManager);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_ThreadManager_stop(OpenPose.DataType dataType, IntPtr threadManager);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_ThreadManager_getIsRunningSharedPtr(OpenPose.DataType dataType, IntPtr threadManager);

    }

}