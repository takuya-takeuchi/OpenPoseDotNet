using System.Runtime.InteropServices;

namespace OpenPoseDotNet
{

    public static class Flags
    {

        #region Properties

        public static bool DisableMultiThread
        {
            get => Native.op_flags_get_disable_multi_thread();
            set => Native.op_flags_set_disable_multi_thread(value);
        }

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_disable_multi_thread();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_disable_multi_thread(bool value);

        }

    }

}
