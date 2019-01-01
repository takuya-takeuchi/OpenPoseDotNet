using System;
using OpenPoseDotNet;

namespace SynchronousCustomPostProcessing
{

    internal sealed class WUserPostProcessing : UserWorker<CustomDatum>
    {

        #region Methods

        #region Overrides

        protected override void InitializationOnThread()
        {
        }

        protected override void Work(CustomDatum[] datums)
        {
            try
            {
                // User's post-processing (after OpenPose processing & before OpenPose outputs) here
                // datum.cvOutputData: rendered frame with pose or heatmaps
                // datum.poseKeypoints: Array<float> with the estimated pose
                if (datums != null && datums.Length != 0)
                    foreach (var datum in datums)
                        Cv.BitwiseNot(datum.CvOutputData, datum.CvOutputData);
            }
            catch (Exception e)
            {
                OpenPose.Log("Some kind of unexpected error happened.");
                this.Stop();
                OpenPose.Error(e.Message, -1, nameof(this.Work));
            }
        }

        #endregion

        #endregion

    }

}