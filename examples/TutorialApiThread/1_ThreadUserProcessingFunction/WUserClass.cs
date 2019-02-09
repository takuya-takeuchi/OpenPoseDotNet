using System;
using OpenPoseDotNet;

namespace ThreadUserProcessingFunction
{

    // This class can be implemented either as a template or as a simple class given
    // that the user usually knows which kind of data he will move between the queues,
    // in this case we assume a std::shared_ptr of a std::vector of op::Datum
    internal sealed class WUserClass : UserWorker<Datum>
    {

        #region Constructors

        public WUserClass():
            base()
        {
            // User's constructor here
        }

        #endregion

        #region Methods

        protected override void InitializationOnThread()
        {
        }

        protected override void Work(StdSharedPtr<Datum>[] datumsPtr)
        {
            try
            {
                // User's processing here
                // datum.cvInputData: initial cv::Mat obtained from the frames producer (video, webcam, etc.)
                // datum.cvOutputData: final cv::Mat to be displayed
                if (datumsPtr != null)
                    foreach (var datum in datumsPtr)
                        Cv.BitwiseNot(datum.Get().CvInputData, datum.Get().CvOutputData);
            }
            catch (Exception e)
            {
                OpenPose.Log("Some kind of unexpected error happened.");
                this.Stop();
                OpenPose.Error(e.Message, -1, nameof(this.Work));
            }
        }

        #endregion

    }

}