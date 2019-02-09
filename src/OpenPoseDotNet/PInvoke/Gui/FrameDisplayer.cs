using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{
    
    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_FrameDisplayer_new(byte[] windowedName,
                                                          IntPtr initialWindowedSize,
                                                          bool fullScreen);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_FrameDisplayer_delete(IntPtr caffe);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_FrameDisplayer_displayFrame(IntPtr displayer, IntPtr frame, int waitKeyValue);

    }

}
