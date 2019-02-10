using System;
using OpenPoseDotNet;

namespace SynchronousCustomPreProcessing
{

    internal sealed class WUserPreProcessing : UserWorker<Datum>
    {

        #region Methods

        #region Overrides

        protected override void InitializationOnThread()
        {
        }

        protected override void Work(StdSharedPtr<Datum>[] datums)
        {
            try
            {
                // User's pre-processing (after OpenPose read the input image & before OpenPose processing) here
                // datumPtr->cvInputData: input frame
                if (datums != null && datums.Length != 0)
                    foreach (var datum in datums)
                        Cv.BitwiseNot(datum.Get().CvOutputData, datum.Get().CvOutputData);
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