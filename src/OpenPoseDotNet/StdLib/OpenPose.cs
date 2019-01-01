using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        internal sealed partial class Native
        {

            #region std::shared_ptr

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr std_shared_ptr_TDatum_get(DataType dataType, IntPtr p);

            #endregion

        }

    }

}
