using System;
using OpenPoseDotNet;

namespace CustomPostProcessing
{

    internal sealed class UserPostProcessing
    {

        #region Methods

        public void InitializationOnThread()
        {
            try
            {
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DoSomething(Mat output, Mat input)
        {
            try
            {
                // Random operation on data
                Cv.BitwiseNot(input, output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion

    }

}