
/*
 * This sample program is ported by C# from examples/tutorial_api_cpp/10_asynchronous_custom_output.cpp.
*/

using System;
using Microsoft.Extensions.CommandLineUtils;
using OpenPoseDotNet;

namespace AsynchronousCustomOutput
{

    internal class Program
    {

        #region Methods

        private static void Main(string[] args)
        {
            var app = new CommandLineApplication(false)
            {
                Name = nameof(AsynchronousCustomOutput)
            };

            app.HelpOption("-h|--help");

            var noDisplay = app.Option("--no_display", "Enable to disable the visual display.", CommandOptionType.NoValue);

            app.OnExecute(() =>
            {
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
                // producerType
                var tie = OpenPose.FlagsToProducer(Flags.ImageDir, Flags.Video, Flags.IpCamera, Flags.Camera, Flags.FlirCamera, Flags.FlirCameraIndex);
                var producerType = tie.Item1;
                var producerString = tie.Item2;

                // cameraSize
                var cameraSize = OpenPose.FlagsToPoint(Flags.CameraResolution, "-1x-1");

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
                var multipleView = (Flags.Enable3D || Flags.Views3D > 1 || Flags.FlirCamera);

                // Face and hand detectors
                var faceDetector = OpenPose.FlagsToDetector(Flags.FaceDetector);
                var handDetector = OpenPose.FlagsToDetector(Flags.HandDetector);

                // Enabling Google Logging
                const bool enableGoogleLogging = true;

                // Configuring OpenPose
                OpenPose.Log("Configuring OpenPose...", Priority.High);

                // Pose configuration (use WrapperStructPose{} for default and recommended configuration)
                var pose = new WrapperStructPose(!Flags.BodyDisabled,
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

                // Producer (use default to disable any input)
                var input = new WrapperStructInput(producerType,
                                                   producerString,
                                                   Flags.FrameFirst,
                                                   Flags.FrameStep,
                                                   Flags.FrameLast,
                                                   Flags.ProcessRealTime,
                                                   Flags.FrameFlip,
                                                   Flags.FrameRotate,
                                                   Flags.FramesRepeat,
                                                   cameraSize,
                                                   Flags.CameraParameterPath,
                                                   Flags.FrameUndistort,
                                                   Flags.Views3D);

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
                opWrapper.Configure(input);
                opWrapper.Configure(output);

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
                    // Configuring OpenPose
                    OpenPose.Log("Configuring OpenPose...", Priority.High);
                    using (var opWrapper = new Wrapper<Datum>(ThreadManagerMode.AsynchronousOut))
                    {
                        ConfigureWrapper(opWrapper);

                        // Start, run, and stop processing - exec() blocks this thread until OpenPose wrapper has finished
                        OpenPose.Log("Starting thread(s)...", Priority.High);
                        opWrapper.Start();

                        // User processing
                        var userOutputClass = new UserOutputClass();
                        var userWantsToExit = false;
                        while (!userWantsToExit)
                        {
                            // Pop frame
                            if (opWrapper.WaitAndPop(out var datumProcessed))
                            {
                                if (!Flags.NoDisplay)
                                    userWantsToExit = userOutputClass.Display(datumProcessed);
                                userOutputClass.PrintKeyPoints(datumProcessed);
                                datumProcessed.Dispose();
                            }

                            // If OpenPose finished reading images
                            else if (!opWrapper.IsRunning)
                                break;

                            // Something else happened
                            else
                                OpenPose.Log("Processed datum could not be emplaced.", Priority.High);
                        }

                        OpenPose.Log("Stopping thread(s)", Priority.High);
                        opWrapper.Stop();

                        // Measuring total time
                        OpenPose.PrintTime(opTimer, "OpenPose demo successfully finished. Total time: ", " seconds.", Priority.High);
                    }
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