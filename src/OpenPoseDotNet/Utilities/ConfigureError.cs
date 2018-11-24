using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static class ConfigureError
    {

        #region Properties

        public static ErrorMode[] ErrorModes
        {
            get
            {
                var ret = Native.op_ConfigureError_getErrorModes();
                using (var vector = new StdVector<ErrorMode>(ret))
                    return vector.ToArray();
            }
            set
            {
                using (var vector = new StdVector<ErrorMode>(value ?? new ErrorMode[0]))
                    Native.op_ConfigureError_setErrorModes(vector.NativePtr);
            }
        }

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_ConfigureError_getErrorModes();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_ConfigureError_setErrorModes(IntPtr errorModes);

        }

    }

}
