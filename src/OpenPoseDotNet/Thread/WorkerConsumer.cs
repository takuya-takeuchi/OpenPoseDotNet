using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public class WorkerConsumer<T> : Worker<T>
        where T : Datum
    {

        #region Fields

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors

        protected WorkerConsumer() :
            base(IntPtr.Zero)
        {
        }

        protected WorkerConsumer(IntPtr ptr, bool isEnabledDispose = true) :
            base(ptr, isEnabledDispose)
        {
            this._DataType = GenericHelpers.CheckDatumSupportTypes<T>();
        }

        #endregion

    }

}