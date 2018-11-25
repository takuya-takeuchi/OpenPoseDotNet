using System;
using System.Runtime.InteropServices;

namespace OpenPoseDotNet.Interop
{

    internal static class InteropHelper
    {

        public static unsafe void Copy(IntPtr ptrSource, byte[] dest, int elements)
        {
            fixed (byte* ptrDest = &dest[0])
                NativeMethods.memcpy((IntPtr)ptrDest, ptrSource, (elements * sizeof(byte)));
        }

        public static unsafe void Copy(IntPtr ptrSource, uint[] dest, int elements)
        {
            fixed (uint* ptrDest = &dest[0])
                NativeMethods.memcpy((IntPtr)ptrDest, ptrSource, (elements * sizeof(uint)));
        }

        public static unsafe void Copy(IntPtr ptrSource, ushort[] dest, int elements)
        {
            fixed (ushort* ptrDest = &dest[0])
                NativeMethods.memcpy((IntPtr)ptrDest, ptrSource, (elements * sizeof(ushort)));
        }

        public static unsafe void Copy(IntPtr ptrSource, sbyte[] dest, int elements)
        {
            fixed (sbyte* ptrDest = &dest[0])
                NativeMethods.memcpy((IntPtr)ptrDest, ptrSource, (elements * sizeof(sbyte)));
        }

        public static unsafe void Copy(IntPtr ptrSource, ulong[] dest, int elements)
        {
            fixed (ulong* ptrDest = &dest[0])
                NativeMethods.memcpy((IntPtr)ptrDest, ptrSource, (elements * sizeof(ulong)));
        }

        public static void Copy(IntPtr ptrSource, ErrorMode[] dest, int elements)
        {
            var tmp = new byte[dest.Length];
            Copy(ptrSource, tmp, elements);

            for (var i = 0; i < dest.Length; i++)
                dest[i] = (ErrorMode)tmp[i];
        }

        public static void Copy(IntPtr ptrSource, LogMode[] dest, int elements)
        {
            var tmp = new byte[dest.Length];
            Copy(ptrSource, tmp, elements);

            for (var i = 0; i < dest.Length; i++)
                dest[i] = (LogMode)tmp[i];
        }

        public static void Copy(IntPtr ptrSource, HeatMapType[] dest, int elements)
        {
            var tmp = new byte[dest.Length];
            Copy(ptrSource, tmp, elements);

            for (var i = 0; i < dest.Length; i++)
                dest[i] = (HeatMapType)tmp[i];
        }

        public static unsafe void Copy(uint[] source, IntPtr ptrDest, int elements)
        {
            fixed (uint* ptrSource = &source[0])
                NativeMethods.memcpy(ptrDest, (IntPtr)ptrSource, (elements * sizeof(uint)));
        }

        public static unsafe void Copy(ushort[] source, IntPtr ptrDest, int elements)
        {
            fixed (ushort* ptrSource = &source[0])
                NativeMethods.memcpy(ptrDest, (IntPtr)ptrSource, (elements * sizeof(ushort)));
        }

        public static unsafe void Copy(sbyte[] source, IntPtr ptrDest, int elements)
        {
            fixed (sbyte* ptrSource = &source[0])
                NativeMethods.memcpy(ptrDest, (IntPtr)ptrSource, (elements * sizeof(sbyte)));
        }

        public static unsafe void Copy(ulong[] source, IntPtr ptrDest, int elements)
        {
            fixed (ulong* ptrSource = &source[0])
                NativeMethods.memcpy(ptrDest, (IntPtr)ptrSource, (elements * sizeof(ulong)));
        }

        public static unsafe void Copy(ErrorMode[] source, IntPtr ptrDest, int elements)
        {
            fixed (ErrorMode* ptrSource = &source[0])
                NativeMethods.memcpy(ptrDest, (IntPtr)ptrSource, (elements * Marshal.SizeOf<ErrorMode>()));
        }

        public static unsafe void Copy(LogMode[] source, IntPtr ptrDest, int elements)
        {
            fixed (LogMode* ptrSource = &source[0])
                NativeMethods.memcpy(ptrDest, (IntPtr)ptrSource, (elements * Marshal.SizeOf<LogMode>()));
        }

    }

}
