using System.Runtime.InteropServices;

namespace OpenPoseDotNet
{

    internal static partial class NativeMethods
    {

#if LINUX
        public const string NativeLibrary = "libOpenPoseDotNet.Native.so";

        public const CallingConvention CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl;
#elif MAC
        public const string NativeLibrary = "libOpenPoseDotNet.Native.dylib";

        public const CallingConvention CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl;
#else
        public const string NativeLibrary = "OpenPoseDotNet.Native.dll";

        public const CallingConvention CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl;
#endif

    }
}
