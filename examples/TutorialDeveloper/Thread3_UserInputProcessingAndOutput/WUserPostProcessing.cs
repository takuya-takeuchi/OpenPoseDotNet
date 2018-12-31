using System;
using OpenPoseDotNet;

namespace Thread3_UserInputProcessingAndOutput
{

    // This worker will just invert the image
    internal sealed class WUserPostProcessing : UserWorker<Datum>
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

        protected override void Work(Datum[] datumsPtr)
        {
            // User's post-processing (after OpenPose processing & before OpenPose outputs) here
            // datum.cvOutputData: rendered frame with pose or heatmaps
            // datum.poseKeypoints: Array<float> with the estimated pose
            try
            {
                if (datumsPtr != null && datumsPtr.Length != 0)
                    foreach (var datum in datumsPtr)
                        Cv.BitwiseNot(datum.CvInputData, datum.CvOutputData);
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