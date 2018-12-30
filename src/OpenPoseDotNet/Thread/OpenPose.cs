using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        public enum DataType
        {

            Default = 0,

            Custom = 1

        }

        internal sealed partial class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_ThreadManager_new(DataType dataType, ThreadManagerMode threadManagerMode);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_ThreadManager_delete(DataType dataType, IntPtr threadManager);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_ThreadManager_add(DataType dataType,
                                                           IntPtr threadManager,
                                                           ulong threadId,
                                                           IntPtr tWorker,
                                                           ulong queueInId,
                                                           ulong queueOutId);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_ThreadManager_reset(DataType dataType, IntPtr threadManager);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_ThreadManager_exec(DataType dataType, IntPtr threadManager);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_ThreadManager_start(DataType dataType, IntPtr threadManager);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_ThreadManager_stop(DataType dataType, IntPtr threadManager);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_ThreadManager_getIsRunningSharedPtr(DataType dataType, IntPtr threadManager);

        }

    }

}