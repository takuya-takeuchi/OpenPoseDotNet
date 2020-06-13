/*
 * This sample program is ported by C# from examples/tutorial_api_cpp/11_asynchronous_custom_input_multi_camera.cpp.
*/

using System;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;
using OpenPoseDotNet;

namespace AsynchronousCustomInputMultiCamera
{

    internal class Program
    {

        #region Constructor

        static Program()
        {
            // Custom OpenPose flags
            // Producer
            Flags.Video = "3d_4camera_video.avi";                         // Use a video file instead of the camera. Use `examples/media/video.avi` for our default example video.
            Flags.CameraParameterPath = "models/cameraParameters/flir/";  // String with the folder where the camera parameters are located. If there is only 1 XML file (for single
                                                                          // video, webcam, or images from the same camera), you must specify the whole XML file path (ending in .xml).
        }

        #endregion

        #region Methods

        private static void Main(string[] args)
        {
            var app = new CommandLineApplication(false)
            {
                Name = nameof(AsynchronousCustomInputMultiCamera)
            };

            app.HelpOption("-h|--help");

            var videoFileOption = app.Option("-v|--video", "Use a video file instead of the camera", CommandOptionType.SingleValue);
            var displayOption = app.Option("-d|--display", "Display mode.", CommandOptionType.SingleValue);

            app.OnExecute(() =>
            {
                if (videoFileOption.HasValue())
                {
                    var video = videoFileOption.Value();
                    if (string.IsNullOrWhiteSpace(video) || !File.Exists(video))
                    {
                        Console.WriteLine("Argument 'video' is invalid or not found.");
                        app.ShowHelp();
                        return -1;
                    }

                    Flags.Video = video;
                }

                if (displayOption.HasValue())
                {
                    if (!int.TryParse(displayOption.Value(), out var display))
                    {
                        Console.WriteLine("Argument 'display' must be number.");
                        app.ShowHelp();
                        return -1;
                    }

                    Flags.Display = display;
                }

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
                OpenPose.CheckBool(0 <= Flags.LoggingLevel && Flags.LoggingLevel <= 255, "Wrong logging_level value.");
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
                // poseMode
                var poseMode = OpenPose.FlagsToPoseMode(Flags.Body);
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
                var faceDetector = OpenPose.FlagsToDetector(Flags.FaceDetector);
                var handDetector = OpenPose.FlagsToDetector(Flags.HandDetector);
                // Enabling Google Logging
                const bool enableGoogleLogging = true;

                // Pose configuration (use WrapperStructPose{} for default and recommended configuration)
                var pose = new WrapperStructPose(poseMode,
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
                                                 (float)Flags.UpsamplingRatio,
                                                 enableGoogleLogging);
                // Face configuration (use op::WrapperStructFace{} to disable it)
                var face = new WrapperStructFace(Flags.Face,
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
                                                     Flags.WriteCocoJsonVariants,
                                                     Flags.WriteCocoJsonVariant,
                                                     Flags.WriteImages,
                                                     Flags.WriteImagesFormat,
                                                     Flags.WriteVideo,
                                                     Flags.WriteVideoFps,
                                                     Flags.WriteVideoWithAudio,
                                                     Flags.WriteHeatmaps,
                                                     Flags.WriteHeatmapsFormat,
                                                     Flags.WriteVideoAdam,
                                                     Flags.WriteBvh,
                                                     Flags.UdpHost,
                                                     Flags.UdpPort);
                // GUI (comment or use default argument to disable any visual output)
                var gui = new WrapperStructGui(OpenPose.FlagsToDisplayMode(Flags.Display, Flags.Enable3D),
                                               !Flags.NoGuiVerbose,
                                               Flags.FullScreen);
                opWrapper.Configure(pose);
                opWrapper.Configure(face);
                opWrapper.Configure(hand);
                opWrapper.Configure(extra);
                opWrapper.Configure(output);
                opWrapper.Configure(gui);

                // No GUI. Equivalent to: opWrapper.configure(op::WrapperStructGui{});
                // Set to single-thread (for sequential processing and/or debugging and/or reducing latency)
                if (Flags.DisableMultiThread)
                    opWrapper.DisableMultiThreading();
            }
            catch (Exception e)
            {
                OpenPose.Error(e.Message, -1, nameof(ConfigureWrapper));
            }
        }

        private static int TutorialApiCpp()
        {
            try
            {
                OpenPose.Log("Starting OpenPose demo...", Priority.High);
                using (var opTimer = OpenPose.GetTimerInit())
                {
                    // Required flags to enable 3-D
                    Flags.Enable3D = true;
                    Flags.NumberPeopleMax = 1;
                    Flags.MinViews3D = 3;
                    Flags.OutputResolution = "320x256"; // Optional, but otherwise it gets too big to render in real time
                                                        // FLAGS_3d_views = X; // Not required because it only affects OpenPose producers (rather than custom ones)

                    // Configuring OpenPose
                    OpenPose.Log("Configuring OpenPose...", Priority.High);
                    using (var opWrapper = new Wrapper<Datum>(ThreadManagerMode.AsynchronousIn))
                    {
                        ConfigureWrapper(opWrapper);

                        // Start, run, and stop processing - exec() blocks this thread until OpenPose wrapper has finished
                        OpenPose.Log("Starting thread(s)...", Priority.High);
                        opWrapper.Start();

                        // User processing
                        var userInputClass = new UserInputClass(Flags.Video, Flags.CameraParameterPath);
                        var userWantsToExit = false;
                        while (!userWantsToExit && !userInputClass.IsFinished())
                        {
                            if (!opWrapper.IsRunning)
                            {
                                OpenPose.Log("OpenPose wrapper is no longer running, exiting video.", Priority.High);
                                break;
                            }

                            // Push frame
                            using (var datumToProcess = userInputClass.CreateDatum())
                            {
                                if (datumToProcess != null)
                                {
                                    var successfullyEmplaced = opWrapper.WaitAndEmplace(datumToProcess);
                                    if (!successfullyEmplaced)
                                        OpenPose.Log("Processed datum could not be emplaced.", Priority.High);
                                }
                            }
                        }

                        OpenPose.Log("Stopping thread(s)", Priority.High);
                        opWrapper.Stop();
                    }

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