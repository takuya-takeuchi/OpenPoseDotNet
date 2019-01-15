using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal static partial class NativeMethods
    {

        #region op::WGui

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_WGui_new(OpenPose.DataType dataType, IntPtr gui);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_WGui_delete(OpenPose.DataType dataType, IntPtr wgui);

        #endregion

    }

}