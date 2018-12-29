using System;
using OpenPoseDotNet;

namespace CustomPostProcessing
{

    internal sealed class WUserPostProcessing : CustomWorker
    {

        #region Fields

        private readonly UserPostProcessing _UserPostProcessing;

        #endregion

        #region Constructors

        public WUserPostProcessing(UserPostProcessing userPostProcessing)
        {
            if (userPostProcessing == null)
                throw new ArgumentNullException(nameof(userPostProcessing));

            this._UserPostProcessing = userPostProcessing;
        }

        #endregion

        #region Methods

        #region Overrids

        protected override void InitializationOnThread()
        {
        }

        protected override void Work(CustomDatum[] datums)
        {
            try
            {
                if (datums != null)
                {
                    // Debugging log
                    OpenPose.DebugLog("", Priority.Low, -1, nameof(this.Work), "");
                    // Profiling speed
                    var profilerKey = Profiler.TimerInit(-1,nameof(this.Work),"");

                    foreach (var datum in datums)
                    {
                        // THIS IS THE ONLY LINE THAT THE USER MUST MODIFY ON THIS HPP FILE, by using the proper function
                        // and datum elements
                        this._UserPostProcessing.DoSomething(datum.CvOutputData, datum.CvOutputData);
                        // Profiling speed
                        Profiler.TimerEnd(profilerKey);
                        Profiler.PrintAveragedTimeMsOnIterationX(profilerKey, -1, nameof(this.Work), "");
                        // Debugging log
                        OpenPose.DebugLog("", Priority.Low, -1, nameof(this.Work), "");
                    }
                }
            }
            catch (Exception e)
            {
                this.Stop();
                datums = null;
                Console.WriteLine(e.Message);
            }
        }

        #endregion

        #endregion

    }

}