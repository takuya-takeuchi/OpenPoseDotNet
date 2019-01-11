using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{
    
    internal static partial class NativeMethods
    {

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_FrameDisplayer_new(byte[] windowedName,
                                                          IntPtr initialWindowedSize,
                                                          bool fullScreen);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_FrameDisplayer_delete(IntPtr caffe);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_FrameDisplayer_displayFrame(IntPtr displayer, IntPtr frame, int waitKeyValue);

    }

}
