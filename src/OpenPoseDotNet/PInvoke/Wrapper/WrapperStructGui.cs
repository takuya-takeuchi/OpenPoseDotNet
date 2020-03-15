using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_wrapperStructGui_new(DisplayMode displayMode,
                                                            bool guiVerbose,
                                                            bool fullScreen);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_wrapperStructGui_delete(IntPtr face);

    }

}