// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public enum ProducerType : byte
    {

        /** Stereo FLIR (Point-Grey) camera reader. Based on Spinnaker SDK. */
        FlirCamera,

        /** An image directory reader. It is able to read images on a folder with a interface similar to the OpenCV
         * cv::VideoCapture.
         */
        ImageDirectory,

        /** An IP camera frames extractor, extending the functionality of cv::VideoCapture. */
        IPCamera,

        /** A video frames extractor, extending the functionality of cv::VideoCapture. */
        Video,

        /** A webcam frames extractor, extending the functionality of cv::VideoCapture. */
        Webcam,

        /** No type defined. Default state when no specific Producer has been picked yet. */
        None,

    }

}
