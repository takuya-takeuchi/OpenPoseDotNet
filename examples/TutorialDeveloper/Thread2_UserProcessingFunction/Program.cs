/*
 * This sample program is ported by C# from examples/tutorial_developer/thread_2_user_processing_function.cpp.
*/

using System;
using System.Diagnostics;
using OpenPoseDotNet;

namespace Thread2_UserProcessingFunction
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
            Flags.LoggingLevel = 3;                                      // The logging level. Integer in the range [0, 255]. 0 will output any log() message, while
                                                                         // 255 will not output any. Current OpenPose library messages are in the range 0-4: 1 for
                                                                         // low priority messages and 4 for important ones.
                                                                         // Producer
            Flags.Camera = -1;                                           // The camera index for cv::VideoCapture. Integer in the range [0, 9]. Select a negative
                                                                         // number (by default), to auto-detect and open the first available camera.
            Flags.CameraResolution = "-1x-1";                            // Set the camera resolution (either `--camera` or `--flir_camera`). `-1x-1` will use the
                                                                         // default 1280x720 for `--camera`, or the maximum flir camera resolution available for
                                                                         // `--flir_camera`
            Flags.Video = "";                                            // Use a video file instead of the camera. Use `examples/media/video.avi` for our default
                                                                         // example video.
            Flags.ImageDir = "";                                         // Process a directory of images. Use `examples/media/` for our default example folder with 20
                                                                         // images. Read all standard formats (jpg, png, bmp, etc.).
            Flags.FlirCamera = false;                                    // Whether to use FLIR (Point-Grey) stereo camera.
            Flags.FlirCameraIndex = -1;                                  // Select -1 (default) to run on all detected flir cameras at once. Otherwise, select the flir
                                                                         // camera index to run, where 0 corresponds to the detected flir camera with the lowest"
                                                                         // serial number, and `n` to the `n`-th lowest serial number camera.
            Flags.IpCamera = "";                                         // String with the IP camera URL. It supports protocols like RTSP and HTTP.
            Flags.ProcessRealTime = false;                               // Enable to keep the original source frame rate (e.g., for video). If the processing time is"
                                                                         // too long, it will skip frames. If it is too fast, it will slow it down.
            Flags.CameraParameterPath = "models/cameraParameters/flir/"; // String with the folder where the camera parameters are located. If there
                                                                         // is only 1 XML file (for single video, webcam, or images from the same camera), you must
                                                                         // specify the whole XML file path (ending in .xml).
            Flags.FrameUndistort = false;                                // If false (default), it will not undistort the image, if true, it will undistortionate them
                                                                         // based on the camera parameters found in `camera_parameter_path`
                                                                         // OpenPose
            Flags.OutputResolution = "-1x-1";                            // The image resolution (display and output). Use \"-1x-1\" to force the program to use the
                                                                         // input image resolution.
            Flags.Views3D = 1;                                           // Complementary option to `--image_dir` or `--video`. OpenPose will read as many images per
                                                                         // iteration, allowing tasks such as stereo camera processing (`--3d`). Note that
                                                                         // `--camera_parameter_path` must be set. OpenPose must find as many `xml` files in the
                                                                         // parameter folder as this number indicates.
                                                                         // Consumer
            Flags.FullScreen = false;                                    // Run in full-screen mode (press f during runtime to toggle).
        }

        #endregion

        #region Methods

        private static void Main()
        {
            TutorialDeveloperThread2();
        }

        #region Helpers

        private static int TutorialDeveloperThread2()
        {
            try
            {
                OpenPose.Log("Starting OpenPose demo...", Priority.High);
                var timeBegin = new Stopwatch();
                timeBegin.Start();

                // ------------------------- INITIALIZATION -------------------------
                // Step 1 - Set logging level
                // - 0 will output all the logging messages
                // - 255 will output nothing
                OpenPose.Check(0 <= Flags.LoggingLevel && Flags.LoggingLevel <= 255, "Wrong logging_level value.");
                ConfigureLog.PriorityThreshold = (Priority)Flags.LoggingLevel;
                // Step 2 - Read GFlags (user defined configuration)
                // cameraSize
                var cameraSize = OpenPose.FlagsToPoint(Flags.CameraResolution, "-1x-1");
                // outputSize
                var outputSize = OpenPose.FlagsToPoint(Flags.OutputResolution, "-1x-1");
                // producerType
                var tie = OpenPose.FlagsToProducer(Flags.ImageDir, Flags.Video, Flags.IpCamera, Flags.Camera, Flags.FlirCamera, Flags.FlirCameraIndex);
                var producerType = tie.Item1;
                var producerString = tie.Item2;
                var displayProducerFpsMode = Flags.ProcessRealTime ? ProducerFpsMode.OriginalFps : ProducerFpsMode.RetrievalFps;
                using (var producerSharedPtr = OpenPose.CreateProducer(producerType,
                                                                       cameraSize,
                                                                       producerString,
                                                                       Flags.CameraParameterPath,
                                                                       Flags.FrameUndistort,
                                                                       Flags.Views3D))
                {
                    producerSharedPtr.Get().SetProducerFpsMode(displayProducerFpsMode);
                    OpenPose.Log("", Priority.Low);
                    // Step 3 - Setting producer
                    //var videoSeekSharedPtr = std::make_shared<std::pair<std::atomic<bool>, std::atomic<int>>>();
                    //videoSeekSharedPtr->first = false;
                    //videoSeekSharedPtr->second = 0;
                    // Step 4 - Setting thread workers && manager
                    // Note:
                    // nativeDebugging may occur crash
                    using (var threadManager = new ThreadManager<Datum>())
                    {
                        // Step 5 - Initializing the worker classes
                        // Frames producer (e.g., video, webcam, ...)
                        using (var datumProducer = new StdSharedPtr<DatumProducer<Datum>>(new DatumProducer<Datum>(producerSharedPtr)))
                        using (var wDatumProducer = new StdSharedPtr<WDatumProducer<Datum>>(new WDatumProducer<Datum>(datumProducer)))
                        {
                            // Specific WUserClass
                            using (var wUserClass = new StdSharedPtr<UserWorker<Datum>>(new WUserClass()))
                            {
                                // GUI (Display)
                                using (var gui = new StdSharedPtr<Gui>(new Gui(outputSize, Flags.FullScreen, threadManager.GetIsRunningSharedPtr())))
                                using (var wGui = new StdSharedPtr<WGui<Datum>>(new WGui<Datum>(gui)))
                                {
                                    // ------------------------- CONFIGURING THREADING -------------------------
                                    // In this simple multi-thread example, we will do the following:
                                    // 3 (virtual) queues: 0, 1, 2
                                    // 1 real queue: 1. The first and last queue ids (in this case 0 and 2) are not actual queues, but the
                                    // beginning and end of the processing sequence
                                    // 2 threads: 0, 1
                                    // wDatumProducer will generate frames (there is no real queue 0) and push them on queue 1
                                    // wGui will pop frames from queue 1 and process them (there is no real queue 2)
                                    var threadId = 0UL;
                                    var queueIn = 0UL;
                                    var queueOut = 1UL;
                                    threadManager.Add(threadId++, wDatumProducer, queueIn++, queueOut++);   // Thread 0, queues 0 -> 1
                                    threadManager.Add(threadId++, wUserClass, queueIn++, queueOut++);       // Thread 1, queues 1 -> 2
                                    threadManager.Add(threadId++, wGui, queueIn++, queueOut++);             // Thread 2, queues 2 -> 3

                                    // Equivalent single-thread version
                                    // const auto threadId = 0ull;
                                    // auto queueIn = 0ull;
                                    // auto queueOut = 1ull;
                                    // threadManager.add(threadId, wDatumProducer, queueIn++, queueOut++);     // Thread 0, queues 0 -> 1
                                    // threadManager.add(threadId, wUserClass, queueIn++, queueOut++);         // Thread 1, queues 1 -> 2
                                    // threadManager.add(threadId, wGui, queueIn++, queueOut++);               // Thread 2, queues 2 -> 3

                                    // Smart multi-thread version
                                    // Assume wUser is the slowest process, and that wDatumProducer + wGui is faster than wGui itself,
                                    // then, we can group the last 2 in the same thread and keep wGui in a different thread:
                                    // const auto threadId = 0ull;
                                    // auto queueIn = 0ull;
                                    // auto queueOut = 1ull;
                                    // threadManager.add(threadId, wDatumProducer, queueIn++, queueOut++);     // Thread 0, queues 0 -> 1
                                    // threadManager.add(threadId+1, wUserClass, queueIn++, queueOut++);       // Thread 1, queues 1 -> 2
                                    // threadManager.add(threadId, wGui, queueIn++, queueOut++);               // Thread 0, queues 2 -> 3

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
                }

                // ------------------------- CLOSING -------------------------
                // Measuring total time
                timeBegin.Stop();
                var totalTimeSec = timeBegin.ElapsedMilliseconds / 1000d;
                var message = $"OpenPose demo successfully finished. Total time: {totalTimeSec} seconds.";
                OpenPose.Log(message, Priority.High);

                // Return successful message
                return 0;
            }
            catch (Exception e)
            {
                OpenPose.Error(e.Message, -1, nameof(TutorialDeveloperThread2));
                return -1;
            }
        }

        #endregion

        #endregion

    }

}