using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal static partial class NativeMethods
    {

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_wrapperStructInput_new(ProducerType producerType,
                                                              byte[] producerString,
                                                              ulong frameFirst,
                                                              ulong frameStep,
                                                              ulong frameLast,
                                                              bool realTimeProcessing,
                                                              bool frameFlip,
                                                              int frameRotate,
                                                              bool framesRepeat,
                                                              IntPtr cameraResolution,
                                                              byte[] cameraParameterPath,
                                                              bool undistortImage,
                                                              int numberViews);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_wrapperStructInput_delete(IntPtr face);

    }

}