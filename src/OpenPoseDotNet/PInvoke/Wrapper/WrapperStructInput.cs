using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
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

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapperStructInput_delete(IntPtr face);

    }

}