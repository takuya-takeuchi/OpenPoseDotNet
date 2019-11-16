using System;
using OpenPoseDotNet;
using UserDatum = OpenPoseDotNet.CustomDatum;

namespace ThreadUserInputProcessingOutputAndDatum
{

    // This worker will just invert the image
    internal sealed class WUserPostProcessing : UserWorker<UserDatum>
    {

        #region Constructors

        public WUserPostProcessing() :
            base()
        {
            // User's constructor here
        }

        #endregion

        #region Methods

        protected override void InitializationOnThread()
        {
        }

        protected override void Work(StdSharedPtr<UserDatum>[] datumsPtr)
        {
            // User's post-processing (after OpenPose processing & before OpenPose outputs) here
            // datum.cvOutputData: rendered frame with pose or heatmaps
            // datum.poseKeypoints: Array<float> with the estimated pose
            try
            {
                if (datumsPtr != null && datumsPtr.Length != 0)
                    foreach (var datum in datumsPtr)
                        using (var cvOutputData = OpenPose.OP_OP2CVMAT(datum.Get().CvOutputData))
                            Cv.BitwiseNot(cvOutputData, cvOutputData);
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