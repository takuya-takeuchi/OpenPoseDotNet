using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed class UserWorkerProducerDelegateMediator : WorkerDelegateMediator
    {

        #region Constructors

        public UserWorkerProducerDelegateMediator(OpenPose.DataType dataType) :
            base(dataType)
        {
        }

        #endregion

        #region Methods

        protected override IntPtr CreateObject()
        {
            return OpenPose.Native.op_UserWorkerProducer_new(this.DataType,
                                                             this.InitializationOnThreadActionPointer,
                                                             this.ProcessAction2Pointer);
        }

        #endregion

    }

}