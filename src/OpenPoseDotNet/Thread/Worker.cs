using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public class Worker<T> : OpenPoseObject
    {

        #region Fields

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors
        
        protected Worker(IntPtr ptr, bool isEnabledDispose = true) :
            base(isEnabledDispose)
        {
            this._DataType = GenericHelpers.CheckDatumSupportTypes<T>();
            this.NativePtr = ptr;
        }

        #endregion

    }

}