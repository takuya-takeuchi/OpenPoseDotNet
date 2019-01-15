using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal static partial class NativeMethods
    {

        #region std::shared_ptr

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr std_shared_ptr_TDatum_get(OpenPose.DataType dataType, IntPtr p);

        #endregion

    }

}
