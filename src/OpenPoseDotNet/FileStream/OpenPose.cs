using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        #region Methods

        #region filestream/filestream

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

            #region filestream/filestream

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern DataFormat op_stringToDataFormat(byte[] dataFormat);

            #endregion

        }

    }

}
