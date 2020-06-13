using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        #region Methods

        public static void CreateMultiviewTDatum<T>(StdSharedPtr<StdVector<StdSharedPtr<T>>> datum,
                                                    ref ulong frameCounter,
                                                    CameraParameterReader cameraParameterReader,
                                                    Mat mat)
            where T : Datum
        {
            if (datum == null) 
                throw new ArgumentNullException(nameof(datum));
            if (cameraParameterReader == null)
                throw new ArgumentNullException(nameof(cameraParameterReader));
            if (mat == null) 
                throw new ArgumentNullException(nameof(mat));

            datum.ThrowIfDisposed();
            cameraParameterReader.ThrowIfDisposed();
            mat.ThrowIfDisposed();

            var dataType = GenericHelpers.CheckDatumSupportTypes<T>();
            NativeMethods.op_createMultiviewTDatum(dataType,
                                                   datum.NativePtr, 
                                                   ref frameCounter,
                                                   cameraParameterReader.NativePtr,
                                                   mat.NativePtr);
        }

        #endregion

    }

}
