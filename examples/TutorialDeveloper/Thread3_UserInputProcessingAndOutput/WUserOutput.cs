using System;
using OpenPoseDotNet;

namespace Thread3_UserInputProcessingAndOutput
{

    // This worker will just read and return all the jpg files in a directory
    internal sealed class WUserOutput : UserWorkerConsumer<Datum>
    {

        #region Methods

        protected override void InitializationOnThread()
        {
        }

        protected override void WorkConsumer(Datum[] datumsPtr)
        {
            try
            {
                // User's displaying/saving/other processing here
                // datum.cvOutputData: rendered frame with pose or heatmaps
                // datum.poseKeypoints: Array<float> with the estimated pose
                if (datumsPtr != null && datumsPtr.Length != 0)
                {
                    Cv.ImShow("User worker GUI", datumsPtr[0].CvOutputData);

                    // It displays the image and sleeps at least 1 ms (it usually sleeps ~5-10 msec to display the image)
                    Cv.WaitKey(1);
                }
            }
            catch (Exception e)
            {
                OpenPose.Log("Some kind of unexpected error happened.");
                this.Stop();
                OpenPose.Error(e.Message, -1, nameof(this.WorkConsumer));
            }

            #endregion

        }

    }

}