/*
 * This sample program is ported by C# from examples/tutorial_api_cpp/05_keypoints_from_images_multi_gpu.cpp.
*/

using System;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;
using OpenPoseDotNet;

namespace KeyPointsFromImagesMultiGPU
{

    internal class Program
    {

        #region Constructors

        static Program()
        {
            // Producer
            Flags.ImageDir = "examples/media/";                          // Process a directory of images. Read all standard formats (jpg, png, bmp, etc.)..
            // Consumer
            Flags.LatencyIsIrrelevantAndComputerWithLotsOfRam = false;   // If false, it will read and then then process images right away. If true, it will first store all the frames and
                                                                         // later process them (slightly faster). However: 1) Latency will hugely increase (no frames will be processed
                                                                         // until they have all been read). And 2) The program might go out of RAM memory with long videos or folders with
                                                                         // many images (so the computer might freeze).
        }

        #endregion

        #region Methods

        private static void Main(string[] args)
        {
            var app = new CommandLineApplication(false)
            {
                Name = nameof(KeyPointsFromImagesMultiGPU)
            };

            app.HelpOption("-h|--help");

            var disableMultiThreadArgument = app.Argument("disableMultiThread", "Disable MultiThread");
            var imageDirOption = app.Option("-i|--imageDir", "Process a directory of images. Read all standard formats (jpg, png, bmp, etc.).", CommandOptionType.SingleValue);
            var noDisplay = app.Option("--no_display", "Enable to disable the visual display.", CommandOptionType.NoValue);

            app.OnExecute(() =>
            {
                if (disableMultiThreadArgument.Value != null)
                    Flags.DisableMultiThread = true;

                var path = imageDirOption.Value();
                if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
                {
                    Console.WriteLine("Argument 'imageDir' is invalid or not found.");
                    app.ShowHelp();
                    return -1;
                }

                Flags.ImageDir = path;
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

        private static bool Display(StdSharedPtr<StdVector<StdSharedPtr<Datum>>> datumsPtr)
        {
            try
            {
                // User's displaying/saving/other processing here
                // datum.cvOutputData: rendered frame with pose or heatmaps
                // datum.poseKeypoints: Array<float> with the estimated pose
                if (datumsPtr != null && datumsPtr.TryGet(out var data) && !data.Empty)
                {
                    // Display image and sleeps at least 1 ms (it usually sleeps ~5-10 msec to display the image)
                    var temp = data.ToArray()[0].Get();
                    using (var cvMat = OpenPose.OP_OP2CVCONSTMAT(temp.CvOutputData))
                        Cv.ImShow($"{OpenPose.OpenPoseNameAndVersion()} - Tutorial C++ API", cvMat);
                }
                else
                {
                    OpenPose.Log("Nullptr or empty datumsPtr found.", Priority.High);
                }

                var key = Cv.WaitKey(1);
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
                    var temp = data.ToArray()[0].Get();
                    OpenPose.Log($"Body keypoints: {temp.PoseKeyPoints}", Priority.High);
                    OpenPose.Log($"Face keypoints: {temp.FaceKeyPoints}", Priority.High);
                    OpenPose.Log($"Left hand keypoints: {temp.HandKeyPoints[0]}", Priority.High);
                    OpenPose.Log($"Right hand keypoints: {temp.HandKeyPoints[1]}", Priority.High);
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

                        // Increase maximum wrapper queue size
                        if (Flags.LatencyIsIrrelevantAndComputerWithLotsOfRam)
                            opWrapper.SetDefaultMaxSizeQueues(long.MaxValue);

                        // Starting OpenPose
                        OpenPose.Log("Starting thread(s)...", Priority.High);
                        opWrapper.Start();

                        // Read frames on directory
                        var imagePaths = OpenPose.GetFilesOnDirectory(Flags.ImageDir, Extensions.Images);

                        // Process and display images
                        // Option a) Harder to implement but the fastest method
                        // Create 2 different threads:
                        //     1. One pushing images to OpenPose all the time.
                        //     2. A second one retrieving those frames.
                        // Option b) Much easier and faster to implement but slightly slower runtime performance
                        if (!Flags.LatencyIsIrrelevantAndComputerWithLotsOfRam)
                        {
                            // Read number of GPUs in your system
                            var numberGPUs = OpenPose.GetGpuNumber();

                            for (var imageBaseId = 0; imageBaseId < imagePaths.Length; imageBaseId += numberGPUs)
                            {
                                // Read and push images into OpenPose wrapper
                                for (var gpuId = 0; gpuId < numberGPUs; gpuId++)
                                {
                                    var imageId = imageBaseId + gpuId;
                                    if (imageId < imagePaths.Length)
                                    {
                                        var imagePath = imagePaths[imageId];
                                        // Faster alternative that moves imageToProcess
                                        using (var cvImageToProcess = Cv.ImRead(imagePath))
                                        using (var imageToProcess = OpenPose.OP_CV2OPCONSTMAT(cvImageToProcess))
                                            opWrapper.WaitAndEmplace(imageToProcess);
                                        // // Slower but safer alternative that copies imageToProcess
                                        // const auto imageToProcess = cv::imread(imagePath);
                                        // opWrapper.waitAndPush(imageToProcess);
                                    }
                                }

                                // Retrieve processed results from OpenPose wrapper
                                for (var gpuId = 0; gpuId < numberGPUs; gpuId++)
                                {
                                    var imageId = imageBaseId + gpuId;
                                    if (imageId < imagePaths.Length)
                                    {
                                        var status = opWrapper.WaitAndPop(out var datumProcessed);
                                        if (status && datumProcessed != null)
                                        {
                                            PrintKeypoints(datumProcessed);
                                            if (!Flags.NoDisplay)
                                            {
                                                var userWantsToExit = Display(datumProcessed);
                                                if (userWantsToExit)
                                                {
                                                    OpenPose.Log("User pressed Esc to exit demo.", Priority.High);
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                            OpenPose.Log("Image could not be processed.", Priority.High);
                                    }
                                }
                            }
                        }
                        // Option c) Even easier and faster to implement than option b. In addition, its runtime performance should
                        // be slightly faster too, but:
                        //  - Latency will hugely increase (no frames will be processed until they have all been read).
                        //  - The program might go out of RAM memory with long videos or folders with many images (so the computer
                        //    might freeze).
                        else
                        {
                            // Read and push images into OpenPose wrapper
                            OpenPose.Log("Loading images into OpenPose wrapper...", Priority.High);
                            foreach (var imagePath in imagePaths)
                            {
                                // Faster alternative that moves imageToProcess
                                using (var cvImageToProcess = Cv.ImRead(imagePath))
                                using (var imageToProcess = OpenPose.OP_CV2OPCONSTMAT(cvImageToProcess))
                                    opWrapper.WaitAndEmplace(imageToProcess);
                                // // Slower but safer alternative that copies imageToProcess
                                // const auto imageToProcess = cv::imread(imagePath);
                                // opWrapper.waitAndPush(imageToProcess);
                            }

                            // Retrieve processed results from OpenPose wrapper
                            OpenPose.Log("Retrieving results from OpenPose wrapper...", Priority.High);
                            for (var imageId = 0; imageId < imagePaths.Length; imageId++)
                            {
                                var status = opWrapper.WaitAndPop(out var datumProcessed);
                                if (status && datumProcessed != null)
                                {
                                    PrintKeypoints(datumProcessed);
                                    if (!Flags.NoDisplay)
                                    {
                                        var userWantsToExit = Display(datumProcessed);
                                        if (userWantsToExit)
                                        {
                                            OpenPose.Log("User pressed Esc to exit demo.", Priority.High);
                                            break;
                                        }
                                    }
                                }
                                else
                                    OpenPose.Log("Image could not be processed.", Priority.High);
                            }
                        }
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