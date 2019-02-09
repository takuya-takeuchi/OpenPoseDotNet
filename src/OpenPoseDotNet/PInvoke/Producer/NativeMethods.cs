using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_createProducer(ProducerType type,
                                                      byte[] producerString,
                                                      IntPtr cameraResolution,
                                                      byte[] cameraParameterPath,
                                                      bool undistortImage,
                                                      int mNumberViews);

        #region op::DatumManager

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_DatumProducer_new(OpenPose.DataType dataType,
                                                         IntPtr producerSharedPtr,
                                                         ulong frameFirst,
                                                         ulong frameStep,
                                                         ulong frameLast,
                                                         IntPtr videoSeekSharedPtr);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_DatumProducer_delete(OpenPose.DataType dataType, IntPtr producer);

        #endregion

        #region op::WDatumManager

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_WDatumProducer_new(OpenPose.DataType dataType,
                                                          IntPtr datumProducer);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_WDatumProducer_delete(OpenPose.DataType dataType, IntPtr producer);

        #endregion

    }

}