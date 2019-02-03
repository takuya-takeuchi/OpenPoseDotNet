/*
 * This sample program is ported by C# from examples/tutorial_api_cpp/9_synchronous_custom_all.cpp.
*/

using System;
using System.Diagnostics;
using Microsoft.Extensions.CommandLineUtils;
using OpenPoseDotNet;
using UserDatum = OpenPoseDotNet.CustomDatum;

namespace SynchronousCustomAll
{

    internal class Program
    {

        #region Constructors

        static Program()
        {
            // Custom OpenPose flags
            // Producer
            Flags.ImageDir = "examples/media/";    // Process a directory of images. Read all standard formats (jpg, png, bmp, etc.).
        }

        #endregion

        #region Methods

        private static void Main(string[] args)
        {
            var app = new CommandLineApplication(false)
            {
                Name = nameof(SynchronousCustomAll)
            };

            app.HelpOption("-h|--help");

            var noDisplay = app.Option("--no_display", "Enable to disable the visual display.", CommandOptionType.NoValue);

            app.OnExecute(() =>
            {
                Flags.NoDisplay = noDisplay.HasValue();
                TutorialApiCpp9();

                return 0;
            });

            app.Execute(args);
        }

        #region Helpers

        private static int TutorialApiCpp9()
        {
            try
            {
                OpenPose.Log("Starting OpenPose demo...", Priority.High);
                var timeBegin = new Stopwatch();
                timeBegin.Start();

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
                // Enabling Google Logging
                const bool enableGoogleLogging = true;

                // Initializing the user custom classes
                // Frames producer (e.g., video, webcam, ...)
                using (var wUserInput = new StdSharedPtr<UserWorkerProducer<UserDatum>>(new WUserInput(Flags.ImageDir)))
                // Processing
                using (var wUserPostProcessing = new StdSharedPtr<UserWorker<UserDatum>>(new WUserPostProcessing()))
                // GUI (Display)
                using (var wUserOutput = new StdSharedPtr<UserWorkerConsumer<UserDatum>>(new WUserOutput()))
                {
                    // OpenPose wrapper
                    OpenPose.Log("Configuring OpenPose...", Priority.High);
                    using (var opWrapperT = new Wrapper<UserDatum>())
                    {
                        // Add custom input
                        const bool workerInputOnNewThread = false;
                        opWrapperT.SetWorker(WorkerType.Input, wUserInput, workerInputOnNewThread);
                        // Add custom processing
                        const bool workerProcessingOnNewThread = false;
                        opWrapperT.SetWorker(WorkerType.PostProcessing, wUserPostProcessing, workerProcessingOnNewThread);
                        // Add custom output
                        const bool workerOutputOnNewThread = true;
                        opWrapperT.SetWorker(WorkerType.Output, wUserOutput, workerOutputOnNewThread);

                        // Pose configuration (use WrapperStructPose{} for default and recommended configuration)
                        using (var pose = new WrapperStructPose(!Flags.BodyDisabled,
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
                                                                enableGoogleLogging))

                        // Face configuration (use op::WrapperStructFace{} to disable it)
                        using (var face = new WrapperStructFace(Flags.Face,
                                                                faceNetInputSize,
                                                                OpenPose.FlagsToRenderMode(Flags.FaceRender, multipleView, Flags.RenderPose),
                                                                (float)Flags.FaceAlphaPose,
                                                                (float)Flags.FaceAlphaHeatmap,
                                                                (float)Flags.FaceRenderThreshold))

                        // Hand configuration (use op::WrapperStructHand{} to disable it)
                        using (var hand = new WrapperStructHand(Flags.Hand,
                                                                handNetInputSize,
                                                                Flags.HandScaleNumber,
                                                                (float)Flags.HandScaleRange, Flags.HandTracking,
                                                                OpenPose.FlagsToRenderMode(Flags.HandRender, multipleView, Flags.RenderPose),
                                                                (float)Flags.HandAlphaPose,
                                                                (float)Flags.HandAlphaHeatmap,
                                                                (float)Flags.HandRenderThreshold))

                        // Extra functionality configuration (use op::WrapperStructExtra{} to disable it)
                        using (var extra = new WrapperStructExtra(Flags.Enable3D,
                                                                  Flags.MinViews3D,
                                                                  Flags.Identification,
                                                                  Flags.Tracking,
                                                                  Flags.IkThreads))

                        // Output (comment or use default argument to disable any output)
                        using (var output = new WrapperStructOutput(Flags.CliVerbose,
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
                                                                    Flags.UdpPort))
                        {
                            opWrapperT.Configure(pose);
                            opWrapperT.Configure(face);
                            opWrapperT.Configure(hand);
                            opWrapperT.Configure(extra);
                            opWrapperT.Configure(output);

                            // No GUI. Equivalent to: opWrapper.configure(op::WrapperStructGui{});
                            // Set to single-thread (for sequential processing and/or debugging and/or reducing latency)
                            if (Flags.DisableMultiThread)
                                opWrapperT.DisableMultiThreading();

                            // Start, run, and stop processing - exec() blocks this thread until OpenPose wrapper has finished
                            OpenPose.Log("Starting thread(s)...", Priority.High);
                            opWrapperT.Exec();
                        }
                    }
                }

                // Measuring total time
                timeBegin.Stop();
                var totalTimeSec = timeBegin.ElapsedMilliseconds / 1000d;
                var message = $"OpenPose demo successfully finished. Total time: {totalTimeSec} seconds.";
                OpenPose.Log(message, Priority.High);

                // Return successful message
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