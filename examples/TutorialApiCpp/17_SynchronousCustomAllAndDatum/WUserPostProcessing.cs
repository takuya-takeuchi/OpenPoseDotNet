using System;
using OpenPoseDotNet;
using UserDatum = OpenPoseDotNet.CustomDatum;

namespace SynchronousCustomAll
{

    internal sealed class WUserPostProcessing : UserWorker<UserDatum>
    {

        #region Constructors

        public WUserPostProcessing()
        {
            // User's constructor here
        }

        #endregion

        #region Methods

        #region Overrides

        protected override void InitializationOnThread()
        {
        }

        protected override void Work(StdSharedPtr<UserDatum>[] datums)
        {
            try
            {
                // User's post-processing (after OpenPose processing & before OpenPose outputs) here
                // datum.cvOutputData: rendered frame with pose or heatmaps
                // datum.poseKeypoints: Array<float> with the estimated pose
                if (datums != null && datums.Length != 0)
                    foreach (var datum in datums)
                        using (var cvOutputData = OpenPose.OP_OP2CVMAT(datum.Get().CvOutputData))
                            Cv.BitwiseNot(cvOutputData, cvOutputData);
            }
            catch (Exception e)
            {
                this.Stop();
                OpenPose.Error(e.Message, -1, nameof(this.Work));
            }
        }

        #endregion

        #endregion

    }

}