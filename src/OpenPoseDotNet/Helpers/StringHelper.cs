using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal static class StringHelper
    {

        #region Methods
        
        public static string FromStdString(IntPtr ptr, bool dispose = false)
        {
            // Need not to delete str
            // Because string.c_str returns inner memory of string instance.
            // This inner memory will be deleted when string instance is deleted.
            var str = NativeMethods.std_string_c_str(ptr);
            var ret =  Marshal.PtrToStringAnsi(str);
            if (dispose && ptr != IntPtr.Zero)
                NativeMethods.std_string_delete(ptr);
            return ret;
        }

        #endregion

    }

}
