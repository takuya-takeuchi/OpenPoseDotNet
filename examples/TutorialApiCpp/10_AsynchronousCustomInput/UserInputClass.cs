using OpenPoseDotNet;

namespace AsynchronousLoopCustomInput
{

    // This worker will just read and return all the jpg files in a directory
    internal sealed class UserInputClass
    {

        #region Fields

        private readonly string[] _ImageFiles;

        private uint _Counter;

        private bool _Closed;

        #endregion

        #region Constructors

        public UserInputClass(string directoryPath)
        {
            // For all basic image formats
            // If we want only e.g., "jpg" + "png" images
            this._ImageFiles = OpenPose.GetFilesOnDirectory(directoryPath, Extensions.Images);
            if (this._ImageFiles.Length == 0)
                OpenPose.Error("No images found on: " + directoryPath, -1, nameof(UserInputClass));
        }

        #endregion

        #region Methods

        public bool IsFinished()
        {
            return this._Closed;
        }

        public StdSharedPtr<StdVector<StdSharedPtr<Datum>>> CreateDatum()
        {
            // Close program when empty frame
            if (this._Closed || this._ImageFiles.Length <= this._Counter)
            {
                OpenPose.Log("Last frame read and added to queue. Closing program after it is processed.", Priority.High);

                // This funtion stops this worker, which will eventually stop the whole thread system once all the
                // frames have been processed
                this._Closed = true;
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
                    OpenPose.Log($"Empty frame detected on path: {this._ImageFiles[this._Counter - 1]}. Closing program.", Priority.High);
                    this._Closed = true;
                    datumsPtr = null;
                }

                return datumsPtr;
            }
        }

        #endregion

    }

}