// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public abstract class WrapperBase<T> : OpenPoseObject
    {

        #region Properties

        public abstract bool IsRunning
        {
            get;
        }

        #endregion

        #region Methods

        public abstract void Configure(WrapperStructPose pose);

        public abstract void Configure(WrapperStructHand hand);

        public abstract void Configure(WrapperStructFace face);

        public abstract void Configure(WrapperStructExtra extra);

        public abstract void Configure(WrapperStructInput input);

        public abstract void Configure(WrapperStructOutput output);

        public abstract void Configure(WrapperStructGui gui);

        public abstract void DisableMultiThreading();

        public abstract SharedHandle<StdVector<T>> EmplaceAndPop(Mat mat);

        public abstract void Exec();

        public abstract void SetWorker<U>(WorkerType workerType, StdSharedPtr<U> worker, bool workerOnNewThread = true)
            where U : Worker<T>;

        public abstract void Start();

        public abstract void Stop();

        #endregion

    }

}