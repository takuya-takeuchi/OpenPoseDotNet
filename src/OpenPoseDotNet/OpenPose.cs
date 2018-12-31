using System;
using System.Runtime.InteropServices;

namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        internal sealed partial class Native
        {

            internal enum ErrorType
            {

                OK = 0x00000000,

                #region Common

                CommonError = 0x70000000,

                CommonErrorTypeNotSupport = -(CommonError | 0x00000001)

                #endregion

            }

        }

    }

}
