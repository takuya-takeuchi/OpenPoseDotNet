using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        #region std::shared_ptr

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr std_shared_ptr_TDatum_get(OpenPose.DataType dataType, IntPtr p);

        #endregion

    }

}
