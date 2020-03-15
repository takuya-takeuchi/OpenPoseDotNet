/*
 * This sample program is ported by C# from examples/tutorial_developer/2_thread_user_input_processing_output_and_datum.cpp.
*/

using System;
using OpenPoseDotNet;
using UserDatum = OpenPoseDotNet.CustomDatum;

namespace ThreadUserInputProcessingOutputAndDatum
{

    internal class Program
    {

        #region Constructors

        static Program()
        {
            // See all the available parameter options withe the `--help` flag. E.g., `build/examples/openpose/openpose.bin --help`
            // Note: This command will show you flags for other unnecessary 3rdparty files. Check only the flags for the OpenPose
            // executable. E.g., for `openpose.bin`, look for `Flags from examples/openpose/openpose.cpp:`.
            // Debugging/Other
            Flags.LoggingLevel = 3;                                      // The logging level. Integer in the range [0, 255]. 0 will output any opLog() message,
                                                                         // while 255 will not output any. Current OpenPose library messages are in the range 0-4:"
                                                                         // 1 for low priority messages and 4 for important ones.
            // Producer
            Flags.ImageDir = "examples/media/";                          // Process a directory of images. Read all standard formats (jpg, png, bmp, etc.)..
            // Consumer
            Flags.FullScreen = false;                                    // Run in full-screen mode (press f during runtime to toggle).
        }

        #endregion

        #region Methods

        private static void Main()
        {
            OpenPoseTutorialThread2();
        }

        #region Helpers

        private static int OpenPoseTutorialThread2()
        {
            try
            {
                OpenPose.Log("Starting OpenPose demo...", Priority.High);
                using (var opTimer = OpenPose.GetTimerInit())
                {
                    // ------------------------- INITIALIZATION -------------------------
                    // Step 1 - Set logging level
                    // - 0 will output all the logging messages
                    // - 255 will output nothing
                    OpenPose.CheckBool(0 <= Flags.LoggingLevel && Flags.LoggingLevel <= 255, "Wrong logging_level value.");
                    ConfigureLog.PriorityThreshold = (Priority)Flags.LoggingLevel;
                    // Step 2 - Setting thread workers && manage
                    using (var threadManager = new ThreadManager<UserDatum>())
                    {
                        // Step 3 - Initializing the worker classes
                        // Frames producer (e.g., video, webcam, ...)
                        using (var wUserInput = new StdSharedPtr<UserWorkerProducer<UserDatum>>(new WUserInput(Flags.ImageDir)))
                        {
                            // Processing
                            using (var wUserProcessing = new StdSharedPtr<UserWorker<UserDatum>>(new WUserPostProcessing()))
                            {
                                // GUI (Display)
                                using (var wUserOutput = new StdSharedPtr<UserWorkerConsumer<UserDatum>>(new WUserOutput()))
                                {
                                    // ------------------------- CONFIGURING THREADING -------------------------
                                    // In this simple multi-thread example, we will do the following:
                                    // 3 (virtual) queues: 0, 1, 2
                                    // 1 real queue: 1. The first and last queue ids (in this case 0 and 2) are not actual queues, but the
                                    // beginning and end of the processing sequence
                                    // 2 threads: 0, 1
                                    // wUserInput will generate frames (there is no real queue 0) and push them on queue 1
                                    // wGui will pop frames from queue 1 and process them (there is no real queue 2)
                                    var threadId = 0UL;
                                    var queueIn = 0UL;
                                    var queueOut = 1UL;
                                    threadManager.Add(threadId++, wUserInput, queueIn++, queueOut++);       // Thread 0, queues 0 -> 1
                                    threadManager.Add(threadId++, wUserProcessing, queueIn++, queueOut++);  // Thread 1, queues 1 -> 2
                                    threadManager.Add(threadId++, wUserOutput, queueIn++, queueOut++);      // Thread 2, queues 2 -> 3

                                    // ------------------------- STARTING AND STOPPING THREADING -------------------------
                                    OpenPose.Log("Starting thread(s)...", Priority.High);
                                    // Two different ways of running the program on multithread environment
                                    // Option a) Using the main thread (this thread) for processing (it saves 1 thread, recommended)
                                    threadManager.Exec();
                                    // Option b) Giving to the user the control of this thread
                                    // // VERY IMPORTANT NOTE: if OpenCV is compiled with Qt support, this option will not work. Qt needs the main
                                    // // thread to plot visual results, so the final GUI (which uses OpenCV) would return an exception similar to:
                                    // // `QMetaMethod::invoke: Unable to invoke methods with return values in queued connections`
                                    // // Start threads
                                    // threadManager.start();
                                    // // Keep program alive while running threads. Here the user could perform any other desired function
                                    // while (threadManager.isRunning())
                                    //     std::this_thread::sleep_for(std::chrono::milliseconds{33});
                                    // // Stop and join threads
                                    // op::log("Stopping thread(s)", op::Priority::High);
                                    // threadManager.stop();
                                }
                            }
                        }
                    }

                    // Measuring total time
                    OpenPose.PrintTime(opTimer, "OpenPose demo successfully finished. Total time: ", " seconds.", Priority.High);
                }

                // Return
                return 0;
            }
            catch (Exception e)
            {
                OpenPose.Error(e.Message, -1, nameof(OpenPoseTutorialThread2));
                return -1;
            }
        }

        #endregion

        #endregion

    }

}