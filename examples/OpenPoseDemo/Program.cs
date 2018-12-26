
/*
 * This sample program is ported by C# from examples/openpose/openpose.cpp.
*/

using System;
using System.Diagnostics;
using OpenPoseDotNet;

namespace OpenPoseDemo
{

    internal class Program
    {

        #region Methods

        private static void Main()
        {
            OpenPoseDemo();
        }

        #region Helpers

        private static int OpenPoseDemo()
        {
            try
            {
                OpenPose.Log("Starting OpenPose demo...", Priority.High);
                var timer = new Stopwatch();
                timer.Start();

                // logging_level
                OpenPose.Check(0 <= Flags.LoggingLevel && Flags.LoggingLevel <= 255, "Wrong logging_level value.");
                ConfigureLog.PriorityThreshold = (Priority)Flags.LoggingLevel;
                Profiler.SetDefaultX((ulong)Flags.ProfileSpeed);
                // // For debugging
                // // Print all logging messages
                // op::ConfigureLog::setPriorityThreshold(op::Priority::None);
                // // Print out speed values faster
                // op::Profiler::setDefaultX(100);

                // Applying user defined configuration - GFlags to program variables
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
                // producerType
                var tie = OpenPose.FlagsToProducer(Flags.ImageDir, Flags.Video, Flags.IpCamera, Flags.Camera, Flags.FlirCamera, Flags.FlirCameraIndex);
                var producerType = tie.Item1;
                var producerString = tie.Item2;
                // poseModel
                var poseModel = OpenPose.FlagsToPoseModel(Flags.ModelPose);
                // JSON saving
                if (!string.IsNullOrEmpty(Flags.WriteKeyPoint))
                    OpenPose.Log("Flag `write_keypoint` is deprecated and will eventually be removed. Please, use `write_json` instead.", Priority.Max);
                // keyPointScale
                var keyPointScale = OpenPose.FlagsToScaleMode(Flags.KeyPointScale);
                // heatmaps to add
                var heatMapTypes = OpenPose.FlagsToHeatMaps(Flags.HeatmapsAddParts, Flags.HeatmapsAddBackground, Flags.HeatmapsAddPAFs);
                var heatMapScale = OpenPose.FlagsToHeatMapScaleMode(Flags.HeatmapsScale);
                // >1 camera view?
                var multipleView = (Flags.Enable3D || Flags.Views3D > 1 || Flags.FlirCamera);
                // Enabling Google Logging
                const bool enableGoogleLogging = true;

                // Configuring OpenPose
                OpenPose.Log("Configuring OpenPose...", Priority.High);
                using (var opWrapper = new Wrapper())
                {
                    // Pose configuration (use WrapperStructPose{} for default and recommended configuration)
                    using (var pose = new WrapperStructPose(!Flags.BodyDisabled,
                                                            netInputSize,
                                                            outputSize,
                                                            keyPointScale,
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
                    // Producer (use default to disable any input)
                    using (var input = new WrapperStructInput(producerType,
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
                                                              !Flags.FrameUndistort,
                                                              Flags.Views3D))
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
                        opWrapper.Configure(pose);
                        opWrapper.Configure(face);
                        opWrapper.Configure(hand);
                        opWrapper.Configure(extra);
                        opWrapper.Configure(input);
                        opWrapper.Configure(output);
                        opWrapper.Configure(gui);

                        // Set to single-thread (for sequential processing and/or debugging and/or reducing latency)
                        if (Flags.DisableMultiThread)
                            opWrapper.DisableMultiThreading();

                        // Start, run, and stop processing - exec() blocks this thread until OpenPose wrapper has finished
                        OpenPose.Log("Starting thread(s)...", Priority.High);
                        opWrapper.Exec();

                        // Measuring total time
                        timer.Stop();
                        var totalTimeSec = timer.ElapsedMilliseconds * 1000;
                        var message = $"OpenPose demo successfully finished. Total time: {totalTimeSec} seconds.";
                        OpenPose.Log(message, Priority.High);
                    }
                }

                // Return successful message
                OpenPose.Log("Stopping OpenPose...", Priority.High);

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