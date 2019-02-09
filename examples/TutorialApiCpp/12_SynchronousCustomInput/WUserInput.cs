using System;
using OpenPoseDotNet;

namespace SynchronousCustomInput
{

    // This worker will just read and return all the jpg files in a directory
    internal sealed class WUserInput : UserWorkerProducer<Datum>
    {

        #region Fields

        private readonly string[] _ImageFiles;

        private uint _Counter;

        #endregion

        #region Constructors

        public WUserInput(string directoryPath)
        {
            // For all basic image formats
            // If we want only e.g., "jpg" + "png" images
            this._ImageFiles = OpenPose.GetFilesOnDirectory(directoryPath, Extensions.Images);
            if (this._ImageFiles.Length == 0)
                OpenPose.Error("No images found on: " + directoryPath, -1, nameof(WUserInput));
        }

        #endregion

        #region Methods

        protected override void InitializationOnThread()
        {
        }

        protected override StdSharedPtr<StdVector<StdSharedPtr<Datum>>> WorkProducer()
        {
            try
            {
                // Close program when empty frame
                if (this._ImageFiles.Length <= this._Counter)
                {
                    OpenPose.Log("Last frame read and added to queue. Closing program after it is processed.", Priority.High);
                    // This funtion stops this worker, which will eventually stop the whole thread system once all the
                    // frames have been processed
                    this.Stop();
                    return null;
                }
                else
                {
                    // Create new datum
                    var vector = new StdVector<StdSharedPtr<Datum>>();
                    var datumsPtr = new StdSharedPtr<StdVector<StdSharedPtr<Datum>>>(vector);
                    datumsPtr.Get().EmplaceBack();
                    var datum = datumsPtr.Get().At(0);

                    // C# cannot set pointer object by using assignment operator
                    datum.Reset(new Datum());

                    // Fill datum
                    using (var mat = Cv.ImRead(this._ImageFiles[this._Counter++]))
                        datum.Get().CvInputData = mat;

                    // If empty frame -> return nullptr
                    if (datum.Get().CvInputData.Empty)
                    {
                        this.Stop();
                        datumsPtr = null;
                    }

                    return datumsPtr;
                }
            }
            catch (Exception e)
            {
                OpenPose.Log("Some kind of unexpected error happened.");
                this.Stop();
                OpenPose.Error(e.Message, -1, nameof(this.WorkProducer));
                return null;
            }
        }

        #endregion

    }

}