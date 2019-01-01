/*
 * This sample program is ported by C# from examples/tutorial_api_cpp/7_synchronous_custom_input.cpp.
*/

using System;
using System.Diagnostics;
using OpenPoseDotNet;
using UserDatum = OpenPoseDotNet.CustomDatum;

namespace Thread4_UserInputProcessingAndOutput
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

        private static void Main()
        {
            TutorialApiCpp7();
        }

        #region Helpers

        private static int TutorialApiCpp7()
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
                // // For debugging
                // // Print all logging messages
                // ConfigureLog.PriorityThreshold = Priority.None;
                // // Print out speed values faster
                // Profiler.setDefaultX(100);

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
                // var multipleView = (Flags.Enable3D || Flags.Views3D > 1 || Flags.FlirCamera);
                const bool multipleView = false;
                // Enabling Google Logging
                const bool enableGoogleLogging = true;

                // OpenPose wrapper
                OpenPose.Log("Configuring OpenPose...", Priority.High);
                using (var opWrapperT = new Wrapper<UserDatum>())
                {
                    // Initializing the user custom classes
                    // Frames producer (e.g., video, webcam, ...)
                    using (var wUserInput = new StdSharedPtr<UserWorkerProducer<UserDatum>>(new WUserInput(Flags.ImageDir)))
                    {
                        // Add custom processing
                        const bool workerInputOnNewThread = true;
                        opWrapperT.SetWorker(WorkerType.Input, wUserInput, workerInputOnNewThread);

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
                                                                    Flags.WriteVideoFps,
                                                                    Flags.WriteHeatmaps,
                                                                    Flags.WriteHeatmapsFormat,
                                                                    Flags.WriteVideoAdam,
                                                                    Flags.WriteBvh,
                                                                    Flags.UdpHost,
                                                                    Flags.UdpPort))
                        // GUI (comment or use default argument to disable any visual output)
                        using (var gui = new WrapperStructGui(OpenPose.FlagsToDisplayMode(Flags.Display, Flags.Enable3D),
                                                              !Flags.NoGuiVerbose,
                                                              Flags.FullScreen))
                        {
                            opWrapperT.Configure(pose);
                            opWrapperT.Configure(face);
                            opWrapperT.Configure(hand);
                            opWrapperT.Configure(extra);
                            opWrapperT.Configure(output);
                            opWrapperT.Configure(gui);

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