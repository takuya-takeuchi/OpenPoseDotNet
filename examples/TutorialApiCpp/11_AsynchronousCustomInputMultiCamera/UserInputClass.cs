using OpenPoseDotNet;

namespace AsynchronousCustomInputMultiCamera
{

    // This worker will just read and return all the jpg files in a directory
    internal sealed class UserInputClass
    {

        #region Fields

        private readonly CameraParameterReader _CameraParameterReader;

        private readonly VideoCapture _VideoCapture;

        private ulong _FrameCounter;

        private bool _Closed;

        #endregion

        #region Constructors

        public UserInputClass(string videoPath, string cameraParameterPath)
        {
            this._VideoCapture = new VideoCapture(videoPath);
            if (!this._VideoCapture.IsOpened())
            {
                this._Closed = true;
                OpenPose.Error($"No video {videoPath} opened.", -1, nameof(UserInputClass));
            }

            // Create CameraParameterReader
            this._CameraParameterReader = new CameraParameterReader();
            this._CameraParameterReader.ReadParameters(cameraParameterPath);
        }

        #endregion

        #region Methods

        public bool IsFinished()
        {
            return this._Closed;
        }

        public StdSharedPtr<StdVector<StdSharedPtr<Datum>>> CreateDatum()
        {
            if (this._Closed)
            {
                OpenPose.Log("Video already closed, nullptr returned.", Priority.High);
                return null;
            }

            // Read cv::Mat
            using (var cvInputData = new Mat())
            {
                this._VideoCapture.Grab();
                this._VideoCapture.Retrieve(cvInputData);

                // If empty frame -> return nullptr
                if (cvInputData.Empty)
                {
                    // Close program when empty frame
                    OpenPose.Log("Empty frame detected, closing program.", Priority.High);
                    this._Closed = true;
                    return null;
                }

                // Create new datum and add 3D information (cv::Mat splitted and camera parameters)
                var vector = new StdVector<StdSharedPtr<Datum>>();
                var datumsPtr = new StdSharedPtr<StdVector<StdSharedPtr<Datum>>>(vector);
                datumsPtr.Get().EmplaceBack();
                var datum = datumsPtr.Get().At(0);

                //auto datumsPtr = std::make_shared<std::vector<std::shared_ptr<op::Datum>>>();
                OpenPose.CreateMultiviewTDatum<Datum>(datumsPtr,
                                                      ref this._FrameCounter,
                                                      this._CameraParameterReader,
                                                      cvInputData);

                return datumsPtr;
            }
        }

        #endregion

    }

}