using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        #region Methods

        public static StdSharedPtr<Producer> CreateProducer(ProducerType type,
                                                            Point<int> cameraResolution,
                                                            string producerString = "",
                                                            string cameraParameterPath = "models/cameraParameters/",
                                                            bool undistortImage = true,
                                                            int numberViews = -1)
        {
            var producerStringBytes = Encoding.UTF8.GetBytes(producerString ?? "");
            var cameraParameterPathBytes = Encoding.UTF8.GetBytes(cameraParameterPath ?? "");

            using (var resolution = cameraResolution.ToNative())
            {
                var ret = NativeMethods.op_createProducer(type,
                                                          producerStringBytes,
                                                          resolution.NativePtr,
                                                          cameraParameterPathBytes,
                                                          undistortImage,
                                                          numberViews);
                return new StdSharedPtr<Producer>(ret);
            }
        }

        #endregion

    }

}