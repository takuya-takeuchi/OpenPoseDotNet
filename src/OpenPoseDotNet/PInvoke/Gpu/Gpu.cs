using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_getGpuNumber();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern GpuMode op_getGpuMode();

    }

}
