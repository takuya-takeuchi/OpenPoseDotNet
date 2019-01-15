using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal static partial class NativeMethods
    {

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
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
                                                               double writeVideoFps,
                                                               byte[] writeHeatMaps,
                                                               byte[] writeHeatMapsFormat,
                                                               byte[] writeVideoAdam,
                                                               byte[] writeBvh,
                                                               byte[] udpHost,
                                                               byte[] udpPort);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_wrapperStructOutput_delete(IntPtr face);

    }

}
