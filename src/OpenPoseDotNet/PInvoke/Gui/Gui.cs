using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_Gui_new(IntPtr outputSize,
                                               bool fullScreen,
                                               IntPtr isRunningSharedPtr,
                                               IntPtr videoSeekSharedPtr,
                                               IntPtr poseExtractorNets,
                                               IntPtr faceExtractorNets,
                                               IntPtr handExtractorNets,
                                               IntPtr renderers,
                                               DisplayMode displayMode);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_Gui_delete(IntPtr gui);

    }

}