using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public class WorkerProducer<T> : Worker<T>
        where T : Datum
    {

        #region Fields

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors

        protected WorkerProducer():
            base(IntPtr.Zero)
        {
        }

        protected WorkerProducer(IntPtr ptr, bool isEnabledDispose = true) :
            base(ptr, isEnabledDispose)
        {
            this._DataType = GenericHelpers.CheckDatumSupportTypes<T>();
        }

        #endregion

    }

}