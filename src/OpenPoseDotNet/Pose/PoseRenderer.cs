using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public interface IPoseRenderer
    {

        #region Methods

        void InitializationOnThread();

        Tuple<int, string> RenderPose(Array<float> outputData,
                                      Array<float> poseKeyPoints,
                                      float scaleInputToOutput,
                                      float scaleNetToOutput = -1.0f);

        #endregion

    }

}
