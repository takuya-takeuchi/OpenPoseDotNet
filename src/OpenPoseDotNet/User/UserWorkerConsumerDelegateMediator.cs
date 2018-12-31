using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed class UserWorkerConsumerDelegateMediator : WorkerDelegateMediator
    {

        #region Constructors

        public UserWorkerConsumerDelegateMediator(OpenPose.DataType dataType) :
            base(dataType)
        {
        }

        #endregion

        #region Methods

        protected override IntPtr CreateObject()
        {
            return OpenPose.Native.op_UserWorkerConsumer_new(this.DataType,
                                                             this.InitializationOnThreadActionPointer,
                                                             this.ProcessActionPointer);
        }

        #endregion

    }

}