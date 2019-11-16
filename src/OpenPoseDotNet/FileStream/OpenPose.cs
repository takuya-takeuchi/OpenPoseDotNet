using System;
using System.IO;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        #region Methods

        #region filestream/filestream

        public static Matrix LoadImage(string path, LoadImageFlag flag)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path))
                throw new FileNotFoundException($"'{path}' is not found.");

            var pathBytes = Encoding.UTF8.GetBytes(path);
            var ret = NativeMethods.op_loadImage(pathBytes, flag);
            return new Matrix(ret);
        }

        public static DataFormat StringToDataFormat(string dataFormat)
        {
            if (dataFormat == null)
                throw new ArgumentNullException(nameof(dataFormat));

            var dataFormatBytes = Encoding.UTF8.GetBytes(dataFormat);

            return NativeMethods.op_stringToDataFormat(dataFormatBytes);
        }

        #endregion

        #endregion

    }

}
