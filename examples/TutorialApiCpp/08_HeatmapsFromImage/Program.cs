/*
 * This sample program is ported by C# from examples/tutorial_api_cpp/08_heatmaps_from_image.cpp.
*/

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;
using OpenPoseDotNet;

namespace HeatmapsFromImage
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
                Name = nameof(HeatmapsFromImage)
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

        private static bool Display(StdSharedPtr<StdVector<StdSharedPtr<Datum>>> datumsPtr, int desiredChannel = 0)
        {
            try
            {
                if (datumsPtr != null && datumsPtr.TryGet(out var data) && !data.Empty)
                {
                    var datum = datumsPtr.Get().At(0).Get();

                    // Note: Heatmaps are in net_resolution size, which does not necessarily match the final image size
                    // Read heatmaps
                    var poseHeatMaps = datum.PoseHeatMaps;
                    // Read desired channel
                    var numberChannels = poseHeatMaps.GetSize(0);
                    var height = poseHeatMaps.GetSize(1);
                    var width = poseHeatMaps.GetSize(2);
                    var eleSize = sizeof(float);
                    using (var desiredChannelHeatMap = new Mat(height, width, MatType.CV_32F, IntPtr.Add(poseHeatMaps.GetPtr(), (desiredChannel % numberChannels) * height * width * eleSize)))
                    {
                        // Read image used from OpenPose body network (same resolution than heatmaps)
                        var inputNetData = datum.InputNetData[0];
                        using (var inputNetDataB = new Mat(height, width, MatType.CV_32F, IntPtr.Add(inputNetData.GetPtr(), 0 * height * width * eleSize)))
                        using (var inputNetDataG = new Mat(height, width, MatType.CV_32F, IntPtr.Add(inputNetData.GetPtr(), 1 * height * width * eleSize)))
                        using (var inputNetDataR = new Mat(height, width, MatType.CV_32F, IntPtr.Add(inputNetData.GetPtr(), 2 * height * width * eleSize)))
                        using (var vector = new StdVector<Mat>(new List<Mat>(new[] { inputNetDataB, inputNetDataG, inputNetDataR })))
                        using (var tmp = new Mat())
                        {
                            Cv.Merge(vector, tmp);

                            using (var add = tmp + 0.5)
                            using (var mul = add * 255)
                            using (var netInputImage = (Mat)mul)
                            {
                                // Turn into uint8 Cv.Mat
                                using (var netInputImageUint8 = new Mat())
                                {
                                    netInputImage.ConvertTo(netInputImageUint8, MatType.CV_8UC1);
                                    using (var desiredChannelHeatMapUint8 = new Mat())
                                    {
                                        desiredChannelHeatMap.ConvertTo(desiredChannelHeatMapUint8, MatType.CV_8UC1);

                                        // Combining both images
                                        using (var imageToRender = new Mat())
                                        {
                                            Cv.ApplyColorMap(desiredChannelHeatMapUint8, desiredChannelHeatMapUint8, ColormapType.COLORMAP_JET);
                                            Cv.AddWeighted(netInputImageUint8, 0.5, desiredChannelHeatMapUint8, 0.5, 0d, imageToRender);

                                            // Display image
                                            Cv.ImShow($"{OpenPose.OpenPoseNameAndVersion()} - Tutorial C++ API", imageToRender);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                    OpenPose.Log("Nullptr or empty datumsPtr found.", Priority.High);

                var key = (char)Cv.WaitKey(1);
                return (key == 27);
            }
            catch (Exception e)
            {
                OpenPose.Error(e.Message, -1, nameof(Display));
                return true;
            }
        }

        private static void PrintKeypoints(StdSharedPtr<StdVector<StdSharedPtr<Datum>>> datumsPtr)
        {
            try
            {
                // Example: How to use the pose keypoints
                if (datumsPtr != null && datumsPtr.TryGet(out var data) && !data.Empty)
                {
                    var poseHeatMaps = data.ToArray()[0].Get().PoseHeatMaps;
                    var numberChannels = poseHeatMaps.GetSize(0);
                    var height = poseHeatMaps.GetSize(1);
                    var width = poseHeatMaps.GetSize(2);
                    OpenPose.Log($"Body heatmaps has {numberChannels} channels, and each channel has a dimension of {width} x {height} pixels.", Priority.High);
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
                    // Required flags to enable heatmaps
                    Flags.HeatmapsAddParts = true;
                    Flags.HeatmapsAddBackground = true;
                    Flags.HeatmapsAddPAFs = true;
                    Flags.HeatmapsScale = 2;

                    using (var opWrapper = new Wrapper<Datum>(ThreadManagerMode.Asynchronous))
                    {
                        // Configuring OpenPose
                        OpenPose.Log("Configuring OpenPose...", Priority.High);
                        ConfigureWrapper(opWrapper);

                        // Starting OpenPose
                        OpenPose.Log("Starting thread(s)...", Priority.High);
                        opWrapper.Start();

                        // Process and display image
                        using (var imageToProcess = Cv.ImRead(ImagePath))
                        using (var datumProcessed = opWrapper.EmplaceAndPop(imageToProcess))
                        {
                            if (datumProcessed != null)
                            {
                                PrintKeypoints(datumProcessed);
                                if (!Flags.NoDisplay)
                                {
                                    var numberChannels = datumProcessed.Get().ToArray()[0].Get().PoseHeatMaps.GetSize(0);
                                    for (var desiredChannel = 0; desiredChannel < numberChannels; desiredChannel++)
                                        if (Display(datumProcessed, desiredChannel))
                                            break;
                                }
                            }
                        }
                    }

                    // Info
                    OpenPose.Log("NOTE: In addition with the user flags, this demo has auto-selected the following flags:\n\t`--heatmaps_add_parts --heatmaps_add_bkg --heatmaps_add_PAFs`", Priority.High);

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