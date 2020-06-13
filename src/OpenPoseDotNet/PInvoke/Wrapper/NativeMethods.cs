using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_createMultiviewTDatum(OpenPose.DataType dataType,
                                                           IntPtr tDatumsSP,
                                                           ref ulong frameCounter,
                                                           IntPtr cameraParameterReader,
                                                           IntPtr cvMatPtr);

    }

}
