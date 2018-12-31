using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed class UserWorkerDelegateMediator : WorkerDelegateMediator
    {

        #region Constructors

        public UserWorkerDelegateMediator(OpenPose.DataType dataType) :
            base(dataType)
        {
        }

        #endregion

        #region Methods

        protected override IntPtr CreateObject()
        {
            return OpenPose.Native.op_UserWorker_new(this.DataType,
                this.InitializationOnThreadActionPointer,
                this.ProcessActionPointer);
        }

        #endregion

    }

}