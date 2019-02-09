
/*
 * This sample program is ported by C# from examples/tutorial_api_cpp/06_face_from_image.cpp.
*/

using System;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;
using OpenPoseDotNet;

namespace FaceFromImage
{

    internal class Program
    {

        #region Fields

        private static string ImagePath;

        #endregion

        #region Methods

        private static void Main(string[] args)
        {
            var app = new CommandLineApplication(false)
            {
                Name = nameof(FaceFromImage)
            };

            app.HelpOption("-h|--help");

            var disableMultiThreadArgument = app.Argument("disableMultiThread", "Disable MultiThread");
            var inputImageOption = app.Option("-i|--image", "Input image", CommandOptionType.SingleValue);
            var noDisplay = app.Option("--no_display", "Enable to disable the visual display.", CommandOptionType.NoValue);

            app.OnExecute(() =>
            {
                if (disableMultiThreadArgument.Value != null)
                    Flags.DisableMultiThread = true;

                var path = inputImageOption.Value();
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                {
                    Console.WriteLine($"Argument 'image' is invalid or not found.");
                    app.ShowHelp();
                    return -1;
                }

                ImagePath = path;

                Flags.NoDisplay = noDisplay.HasValue();
                TutorialApiCpp();

                return 0;
            });

            app.Execute(args);
        }

        #region Helpers

        private static void ConfigureWrapper(Wrapper<Datum> opWrapper)
        {
            try
            {
                // Configuring OpenPose

                // logging_level
                OpenPose.Check(0 <= Flags.LoggingLevel && Flags.LoggingLevel <= 255, "Wrong logging_level value.");
                ConfigureLog.PriorityThreshold = (Priority)Flags.LoggingLevel;
                Profiler.SetDefaultX((ulong)Flags.ProfileSpeed);

                // Applying user defined configuration - GFlags to program variables
                // outputSize
                var outputSize = OpenPose.FlagsToPoint(Flags.OutputResolution, "-1x-1");
                // netInputSize
                var netInputSize = OpenPose.FlagsToPoint(Flags.NetResolution, "-1x368");
                // faceNetInputSize
                var faceNetInputSize = OpenPose.FlagsToPoint(Flags.FaceNetResolution, "368x368 (multiples of 16)");
                // handNetInputSize
                var handNetInputSize = OpenPose.FlagsToPoint(Flags.HandNetResolution, "368x368 (multiples of 16)");
                // poseModel
                var poseModel = OpenPose.FlagsToPoseModel(Flags.ModelPose);
                // JSON saving
                if (!string.IsNullOrEmpty(Flags.WriteKeyPoint))
                    OpenPose.Log("Flag `write_keypoint` is deprecated and will eventually be removed. Please, use `write_json` instead.", Priority.Max);
                // keypointScale
                var keypointScale = OpenPose.FlagsToScaleMode(Flags.KeyPointScale);
                // heatmaps to add
                var heatMapTypes = OpenPose.FlagsToHeatMaps(Flags.HeatmapsAddParts, Flags.HeatmapsAddBackground, Flags.HeatmapsAddPAFs);
                var heatMapScale = OpenPose.FlagsToHeatMapScaleMode(Flags.HeatmapsScale);
                // >1 camera view?
                var multipleView = (Flags.Enable3D || Flags.Views3D > 1);
                // Face and hand detectors
                var faceDetector = Detector.Provided;
                var handDetector = OpenPose.FlagsToDetector(Flags.HandDetector);
                // Enabling Google Logging
                const bool enableGoogleLogging = true;

                // Pose configuration (use WrapperStructPose{} for default and recommended configuration)
                const bool bodyEnable = false;
                var pose = new WrapperStructPose(bodyEnable,
                                                 netInputSize,
                                                 outputSize,
                                                 keypointScale,
                                                 Flags.NumGpu,
                                                 Flags.NumGpuStart,
                                                 Flags.ScaleNumber,
                                                 (float)Flags.ScaleGap,
                                                 OpenPose.FlagsToRenderMode(Flags.RenderPose, multipleView),
                                                 poseModel,
                                                 !Flags.DisableBlending,
                                                 (float)Flags.AlphaPose,
                                                 (float)Flags.AlphaHeatmap,
                                                 Flags.PartToShow,
                                                 Flags.ModelFolder,
                                                 heatMapTypes,
                                                 heatMapScale,
                                                 Flags.PartCandidates,
                                                 (float)Flags.RenderThreshold,
                                                 Flags.NumberPeopleMax,
                                                 Flags.MaximizePositives,
                                                 Flags.FpsMax,
                                                 Flags.PrototxtPath,
                                                 Flags.CaffeModelPath,
                                                 enableGoogleLogging);
                // Face configuration (use op::WrapperStructFace{} to disable it)
                var face = new WrapperStructFace(true,
                                                 faceDetector,
                                                 faceNetInputSize,
                                                 OpenPose.FlagsToRenderMode(Flags.FaceRender, multipleView, Flags.RenderPose),
                                                 (float)Flags.FaceAlphaPose,
                                                 (float)Flags.FaceAlphaHeatmap,
                                                 (float)Flags.FaceRenderThreshold);
                // Hand configuration (use op::WrapperStructHand{} to disable it)
                var hand = new WrapperStructHand(Flags.Hand,
                                                 handDetector,
                                                 handNetInputSize,
                                                 Flags.HandScaleNumber,
                                                 (float)Flags.HandScaleRange,
                                                 OpenPose.FlagsToRenderMode(Flags.HandRender, multipleView, Flags.RenderPose),
                                                 (float)Flags.HandAlphaPose,
                                                 (float)Flags.HandAlphaHeatmap,
                                                 (float)Flags.HandRenderThreshold);
                // Extra functionality configuration (use op::WrapperStructExtra{} to disable it)
                var extra = new WrapperStructExtra(Flags.Enable3D,
                                                   Flags.MinViews3D,
                                                   Flags.Identification,
                                                   Flags.Tracking,
                                                   Flags.IkThreads);
                // Output (comment or use default argument to disable any output)
                var output = new WrapperStructOutput(Flags.CliVerbose,
                                                     Flags.WriteKeyPoint,
                                                     OpenPose.StringToDataFormat(Flags.WriteKeyPointFormat),
                                                     Flags.WriteJson,
                                                     Flags.WriteCocoJson,
                                                     Flags.WriteCocoFootJson,
                                                     Flags.WriteCocoJsonVariant,
                                                     Flags.WriteImages,
                                                     Flags.WriteImagesFormat,
                                                     Flags.WriteVideo,
                                                     Flags.WriteVideoWithAudio,
                                                     Flags.WriteVideoFps,
                                                     Flags.WriteHeatmaps,
                                                     Flags.WriteHeatmapsFormat,
                                                     Flags.WriteVideoAdam,
                                                     Flags.WriteBvh,
                                                     Flags.UdpHost,
                                                     Flags.UdpPort);

                opWrapper.Configure(pose);
                opWrapper.Configure(face);
                opWrapper.Configure(hand);
                opWrapper.Configure(extra);
                opWrapper.Configure(output);

                // No GUI. Equivalent to: opWrapper.configure(op::WrapperStructGui{});
                // Set to single-thread (for sequential processing and/or debugging and/or reducing latency)
                if (Flags.DisableMultiThread)
                    opWrapper.DisableMultiThreading();

                // Return successful message
                OpenPose.Log("Stopping OpenPose...", Priority.High);
            }
            catch (Exception e)
            {
                OpenPose.Error(e.Message, -1, nameof(ConfigureWrapper));
            }
        }

        private static void Display(StdSharedPtr<StdVector<StdSharedPtr<Datum>>> datumsPtr)
        {
            try
            {
                // User's displaying/saving/other processing here
                // datum.cvOutputData: rendered frame with pose or heatmaps
                // datum.poseKeypoints: Array<float> with the estimated pose
                if (datumsPtr != null && datumsPtr.TryGet(out var data) && !data.Empty)
                {
                    // Display image
                    var temp = data.ToArray()[0].Get();
                    Cv.ImShow($"{OpenPose.OpenPoseNameAndVersion()} - Tutorial C++ API", temp.CvOutputData);
                    Cv.WaitKey();
                }
                else
                {
                    OpenPose.Log("Nullptr or empty datumsPtr found.", Priority.High);
                }
            }
            catch (Exception e)
            {
                OpenPose.Error(e.Message, -1, nameof(Display));
            }
        }

        private static void PrintKeypoints(StdSharedPtr<StdVector<StdSharedPtr<Datum>>> datumsPtr)
        {
            try
            {
                // Example: How to use the pose keypoints
                if (datumsPtr != null && datumsPtr.TryGet(out var data) && !data.Empty)
                {
                    // Alternative 1
                    var temp = data.ToArray()[0].Get();
                    OpenPose.Log($"Body keypoints: {temp.PoseKeyPoints}");
                    OpenPose.Log($"Face keypoints: {temp.FaceKeyPoints}");
                    OpenPose.Log($"Left hand keypoints: {temp.HandKeyPoints[0]}");
                    OpenPose.Log($"Right hand keypoints: {temp.HandKeyPoints[1]}");
                }
                else
                {
                    OpenPose.Log("Nullptr or empty datumsPtr found.", Priority.High);
                }
            }
            catch (Exception e)
            {
                OpenPose.Error(e.Message, -1, nameof(PrintKeypoints));
            }
        }

        private static int TutorialApiCpp()
        {
            try
            {
                OpenPose.Log("Starting OpenPose demo...", Priority.High);
                using (var opTimer = OpenPose.GetTimerInit())
                {
                    using (var opWrapper = new Wrapper<Datum>(ThreadManagerMode.Asynchronous))
                    {
                        // Configuring OpenPose
                        OpenPose.Log("Configuring OpenPose...", Priority.High);
                        ConfigureWrapper(opWrapper);

                        // Starting OpenPose
                        OpenPose.Log("Starting thread(s)...", Priority.High);
                        opWrapper.Start();

                        // Read image and face rectangle locations
                        using (var imageToProcess = Cv.ImRead(ImagePath))
                        {
                            var faceRectangles = new[]
                            {
                                new Rectangle<float>( 330.119385f, 277.532715f,  48.717274f,  48.717274f),  // Face of person 0
                                new Rectangle<float>(  24.036991f, 267.918793f,  65.175171f,  65.175171f),  // Face of person 1
                                new Rectangle<float>( 151.803436f,  32.477852f, 108.295761f, 108.295761f)   // Face of person 2
                            };

                            // Create new datum
                            using (var vector = new StdVector<StdSharedPtr<Datum>>())
                            using (var datumsPtr = new StdSharedPtr<StdVector<StdSharedPtr<Datum>>>(vector))
                            using (var datumPtr = new Datum())
                            {
                                datumsPtr.Get().EmplaceBack();
                                var datum = datumsPtr.Get().At(0);

                                // C# cannot set pointer object by using assignment operator
                                datum.Reset(datumPtr);

                                // Fill datum with image and faceRectangles
                                datumPtr.CvInputData = imageToProcess;
                                datumPtr.FaceRectangles = faceRectangles;

                                // Process and display image
                                opWrapper.EmplaceAndPop(datumsPtr);

                                if (datumsPtr.Get() != null)
                                {
                                    PrintKeypoints(datumsPtr);
                                    if (!Flags.NoDisplay)
                                        Display(datumsPtr);
                                }
                                else
                                {
                                    OpenPose.Log("Image could not be processed.", Priority.High);
                                }
                            }
                        }
                    }

                    // Info
                    OpenPose.Log("NOTE: In addition with the user flags, this demo has auto-selected the following flags: `--body_disable --face --face_detector 2`", Priority.High);

                    // Measuring total time
                    OpenPose.PrintTime(opTimer, "OpenPose demo successfully finished. Total time: ", " seconds.", Priority.High);
                }

                // Return
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        #endregion

        #endregion

    }

}