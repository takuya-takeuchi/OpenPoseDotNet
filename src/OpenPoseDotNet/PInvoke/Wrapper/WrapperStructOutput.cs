using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_wrapperStructOutput_new(double verbose,
                                                               byte[] writeKeyPoint,
                                                               DataFormat writeKeyPointFormat,
                                                               byte[] writeJson,
                                                               byte[] writeCocoJson,
                                                               byte[] writeCocoFootJson,
                                                               int writeCocoJsonVariant,
                                                               byte[] writeImages,
                                                               byte[] writeImagesFormat,
                                                               byte[] writeVideo,
                                                               bool writeVideoWithAudio,
                                                               double writeVideoFps,
                                                               byte[] writeHeatMaps,
                                                               byte[] writeHeatMapsFormat,
                                                               byte[] writeVideoAdam,
                                                               byte[] writeBvh,
                                                               byte[] udpHost,
                                                               byte[] udpPort);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapperStructOutput_delete(IntPtr face);

    }

}
