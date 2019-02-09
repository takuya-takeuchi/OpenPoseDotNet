using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{
    
    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_ConfigureError_getErrorModes();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_ConfigureError_setErrorModes(IntPtr errorModes);

    }

}