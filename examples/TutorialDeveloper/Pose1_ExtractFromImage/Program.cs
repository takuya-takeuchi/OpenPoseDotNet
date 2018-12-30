/*
 * This sample program is ported by C# from examples/tutorial_developer/pose_1_extract_from_image.cpp.
*/

using System;
using System.Diagnostics;
using OpenPoseDotNet;

namespace Pose1_ExtractFromImage
{

    internal class Program
    {

        #region Fields

        private static readonly string ImagePath;

        #endregion

        #region Constructors

        static Program()
        {
            // See all the available parameter options withe the `--help` flag. E.g., `build/examples/openpose/openpose.bin --help`
            // Note: This command will show you flags for other unnecessary 3rdparty files. Check only the flags for the OpenPose
            // executable. E.g., for `openpose.bin`, look for `Flags from examples/openpose/openpose.cpp:`.
            // Debugging/Other
            Flags.LoggingLevel = 3; // "The logging level. Integer in the range [0, 255]. 0 will output any log() message, while
                                    // " 255 will not output any. Current OpenPose library messages are in the range 0-4: 1 for
                                    // " low priority messages and 4 for important ones.
                                    // Producer
            ImagePath = "examples/media/COCO_val2014_000000000192.jpg"; // Process the desired image.
            //ImagePath.Replace("\\", "/");
            // OpenPose
            Flags.ModelPose = "BODY_25";      // "Model to be used. E.g., `COCO` (18 keypoints), `MPI` (15 keypoints, ~10% faster), 
                                              // "`MPI_4_layers` (15 keypoints, even faster but less accurate).
            Flags.ModelFolder = "models/";    // "Folder path (absolute or relative) where the models (pose, face, ...) are located.;
            Flags.NetResolution = "-1x368";   // "Multiples of 16. If it is increased, the accuracy potentially increases. If it is
                                              // " decreased, the speed increases. For maximum speed-accuracy balance, it should keep the
                                              // "  closest aspect ratio possible to the images or videos to be processed. Using `-1` in
                                              // " any of the dimensions, OP will choose the optimal aspect ratio depending on the user's
                                              // " input value. E.g., the default `-1x368` is equivalent to `656x368` in 16:9 resolutions,
                                              // " e.g., full HD (1980x1080) and HD (1280x720) resolutions.
            Flags.OutputResolution = "-1x-1"; // "The image resolution (display and output). Use \"-1x-1\" to force the program to use the
                                              // " input image resolution.
            Flags.NumGpuStart = 0;            // "GPU device start number.
            Flags.ScaleGap = 0.3;             // "Scale gap between scales. No effect unless scale_number > 1. Initial scale is always 1."
                                              // "  If you want to change the initial scale, you actually want to multiply the"
                                              // " `net_resolution` by your desired initial scale.
            Flags.ScaleNumber = 1;            // "Number of scales to average.;
            // OpenPose Rendering
            Flags.DisableBlending = false;    // If enabled, it will render the results (keypoint skeletons or heatmaps) on a black
                                              //  background, instead of being rendered into the original image. Related: `part_to_show`,
                                              //  `alpha_pose`, and `alpha_pose`.
            Flags.RenderThreshold = 0.05;     // Only estimated keypoints whose score confidences are higher than this threshold will be
                                              //   rendered. Generally, a high threshold (> 0.5) will only render very clear body parts;
                                              //  while small thresholds (~0.1) will also output guessed and occluded keypoints, but also
                                              //   more false positives (i.e., wrong detections).
            Flags.AlphaPose = 0.6;            // Blending factor (range 0-1) for the body part rendering. 1 will show it completely, 0 will
                                              //  hide it. Only valid for GPU rendering.
        }

        #endregion

        #region Methods

        private static void Main()
        {
            TutorialDeveloperPose1();
        }

        #region Helpers

        private static int TutorialDeveloperPose1()
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
                OpenPose.Log("", Priority.Low);
                // Step 2 - Read GFlags (user defined configuration)
                // outputSize
                var outputSize = OpenPose.FlagsToPoint(Flags.OutputResolution, "-1x-1");
                // netInputSize
                var netInputSize = OpenPose.FlagsToPoint(Flags.NetResolution, "-1x368");
                // poseModel
                var poseModel = OpenPose.FlagsToPoseModel(Flags.ModelPose);
                // Check no contradictory flags enabled
                if (Flags.AlphaPose < 0.0 || Flags.AlphaPose > 1.0)
                    OpenPose.Error("Alpha value for blending must be in the range [0,1].", -1, nameof(TutorialDeveloperPose1));
                if (Flags.ScaleGap <= 0.0 && Flags.ScaleNumber > 1)
                    OpenPose.Error("Incompatible flag configuration: scale_gap must be greater than 0 or scale_number = 1.", -1, nameof(TutorialDeveloperPose1));
                // Step 3 - Initialize all required classes
                using (var scaleAndSizeExtractor = new ScaleAndSizeExtractor(netInputSize, outputSize, Flags.ScaleNumber, Flags.ScaleGap))
                using (var cvMatToOpInput = new CvMatToOpInput(poseModel))
                using (var cvMatToOpOutput = new CvMatToOpOutput())
                using (var poseExtractorCaffe = new PoseExtractorCaffe(poseModel, Flags.ModelFolder, Flags.NumGpuStart))
                using (var poseRenderer = new PoseCpuRenderer(poseModel, (float)Flags.RenderThreshold, !Flags.DisableBlending, (float)Flags.AlphaPose))
                using (var opOutputToCvMat = new OpOutputToCvMat())
                using (var frameDisplayer = new FrameDisplayer("OpenPose Tutorial - Example 1", outputSize))
                {
                    // Step 4 - Initialize resources on desired thread (in this case single thread, i.e., we init resources here)
                    poseExtractorCaffe.InitializationOnThread();
                    poseRenderer.InitializationOnThread();

                    // ------------------------- POSE ESTIMATION AND RENDERING -------------------------
                    // Step 1 - Read and load image, error if empty (possibly wrong path)
                    // Alternative: cv::imread(Flags.image_path, CV_LOAD_IMAGE_COLOR);
                    using (var inputImage = OpenPose.LoadImage(ImagePath, LoadImageFlag.LoadImageColor))
                    {
                        if (inputImage.Empty)
                            OpenPose.Error("Could not open or find the image: " + ImagePath, -1, nameof(TutorialDeveloperPose1));
                        var imageSize = new Point<int>(inputImage.Cols, inputImage.Rows);
                        // Step 2 - Get desired scale sizes
                        var tuple = scaleAndSizeExtractor.Extract(imageSize);
                        var scaleInputToNetInputs = tuple.Item1;
                        var netInputSizes = tuple.Item2;
                        var scaleInputToOutput = tuple.Item3;
                        var outputResolution = tuple.Item4;
                        // Step 3 - Format input image to OpenPose input and output formats
                        var netInputArray = cvMatToOpInput.CreateArray(inputImage, scaleInputToNetInputs, netInputSizes);
                        var outputArray = cvMatToOpOutput.CreateArray(inputImage, scaleInputToOutput, outputResolution);
                        // Step 4 - Estimate poseKeypoints
                        poseExtractorCaffe.ForwardPass(netInputArray, imageSize, scaleInputToNetInputs);
                        var poseKeypoints = poseExtractorCaffe.GetPoseKeyPoints();
                        // Step 5 - Render poseKeypoints
                        poseRenderer.RenderPose(outputArray, poseKeypoints, (float)scaleInputToOutput);
                        // Step 6 - OpenPose output format to cv::Mat
                        using (var outputImage = opOutputToCvMat.FormatToCvMat(outputArray))
                        {
                            // ------------------------- SHOWING RESULT AND CLOSING -------------------------
                            // Show results
                            frameDisplayer.DisplayFrame(outputImage, 0); // Alternative: cv::imshow(outputImage) + cv::waitKey(0)
                                                                         // Measuring total time
                            timeBegin.Stop();
                            var totalTimeSec = timeBegin.ElapsedMilliseconds / 1000d;
                            var message = $"OpenPose demo successfully finished. Total time: {totalTimeSec} seconds.";
                            OpenPose.Log(message, Priority.High);
                            // Return successful message
                            return 0;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                OpenPose.Error(e.Message, -1, nameof(TutorialDeveloperPose1));
                return -1;
            }
        }

        #endregion

        #endregion

    }

}