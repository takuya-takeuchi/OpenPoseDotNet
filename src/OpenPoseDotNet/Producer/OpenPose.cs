using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        #region Methods

        public static StdSharedPtr<Producer> CreateProducer(ProducerType type,
                                                            Point<int> cameraResolution,
                                                            string producerString = "",
                                                            string cameraParameterPath = "models/cameraParameters/",
                                                            bool undistortImage = true,
                                                            int numberViews = -1)
        {
            var producerStringBytes = Encoding.UTF8.GetBytes(producerString ?? "");
            var cameraParameterPathBytes = Encoding.UTF8.GetBytes(cameraParameterPath ?? "");

            using (var resolution = cameraResolution.ToNative())
            {
                var ret = Native.op_createProducer(type,
                                                   producerStringBytes,
                                                   resolution.NativePtr,
                                                   cameraParameterPathBytes,
                                                   undistortImage,
                                                   numberViews);
                return new StdSharedPtr<Producer>(ret);
            }
        }

        #endregion

        internal sealed partial class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_createProducer(ProducerType type,
                                                          byte[] producerString,
                                                          IntPtr cameraResolution,
                                                          byte[] cameraParameterPath,
                                                          bool undistortImage,
                                                          int mNumberViews);

            #region op::DatumManager
            
            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_DatumProducer_new(DataType dataType,
                                                             IntPtr producerSharedPtr,
                                                             ulong frameFirst,
                                                             ulong frameStep,
                                                             ulong frameLast,
                                                             IntPtr videoSeekSharedPtr);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_DatumProducer_delete(DataType dataType, IntPtr producer);

            #endregion

            #region op::WDatumManager

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_WDatumProducer_new(DataType dataType,
                                                              IntPtr datumProducer);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_WDatumProducer_delete(DataType dataType, IntPtr producer);

            #endregion

        }

    }

}