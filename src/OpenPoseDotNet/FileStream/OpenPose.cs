using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        #region Methods

        #region filestream/filestream

        public static Mat LoadImage(string path, LoadImageFlag flag)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path))
                throw new FileNotFoundException($"'{path}' is not found.");

            var pathBytes = Encoding.UTF8.GetBytes(path);
            var ret = Native.op_loadImage(pathBytes, flag);
            return new Mat(ret);
        }

        public static DataFormat StringToDataFormat(string dataFormat)
        {
            if (dataFormat == null)
                throw new ArgumentNullException(nameof(dataFormat));

            var dataFormatBytes = Encoding.UTF8.GetBytes(dataFormat);

            return Native.op_stringToDataFormat(dataFormatBytes);
        }

        #endregion

        #endregion

        internal sealed partial class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_loadImage(byte[] fullFilePath, LoadImageFlag openCvFlags);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern DataFormat op_stringToDataFormat(byte[] dataFormat);

        }

    }

}
