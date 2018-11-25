/*
 * This sample program is ported by C# from examples/tutorial_api_cpp/2_whole_body_from_image.cpp.
*/

using System;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;
using OpenPoseDotNet;

namespace WholeBodyFromImage
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
                Name = nameof(WholeBodyFromImage)
            };

            app.HelpOption("-h|--help");

            var disableMultiThreadArgument = app.Argument("disableMultiThread", "Disable MultiThread");
            var inputImageOption = app.Option("-i|--image", "Input image", CommandOptionType.SingleValue);

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

                TutorialApiCpp2();

                return 0;
            });

            app.Execute(args);
        }

        #region Helpers

        private static void Display(SharedHandle<StdVector<Datum>> datumsPtr)
        {
            // User's displaying/saving/other processing here
            // datum.cvOutputData: rendered frame with pose or heatmaps
            // datum.poseKeypoints: Array<float> with the estimated pose
            if (datumsPtr != null && datumsPtr.GetData(out var data) && !data.Empty)
            {
                // Display image
                var temp = data.ToArray();
                Cv.ImShow("User worker GUI", temp[0].CvOutputData);
                Cv.WaitKey();
            }
            else
            {
                OpenPose.Log("Nullptr or empty datumsPtr found.", Priority.High);
            }
        }

        private static void PrintKeypoints(SharedHandle<StdVector<Datum>> datumsPtr)
        {
            // Example: How to use the pose keypoints
            if (datumsPtr != null && datumsPtr.GetData(out var data) && !data.Empty)
            {
                // Alternative 1
                var temp = data.ToArray();
                OpenPose.Log($"Body keypoints: {temp[0].PoseKeyPoints}");
                OpenPose.Log($"Face keypoints: {temp[0].FaceKeyPoints}");
                OpenPose.Log($"Left hand keypoints: {temp[0].HandKeyPoints[0]}");
                OpenPose.Log($"Right hand keypoints: {temp[0].HandKeyPoints[1]}");
            }
            else
            {
                OpenPose.Log("Nullptr or empty datumsPtr found.", Priority.High);
            }
        }

        private static int TutorialApiCpp2()
        {
            try
            {
                OpenPose.Log("Starting OpenPose demo...", Priority.High);

                // Configuring OpenPose
                OpenPose.Log("Configuring OpenPose...", Priority.High);
                using (var opWrapper = new Wrapper(ThreadManagerMode.Asynchronous))
                {
                    // Add hand and face
                    using (var face = new WrapperStructFace(true))
                    using (var hand = new WrapperStructHand(true))
                    {
                        opWrapper.Configure(face);
                        opWrapper.Configure(hand);

                        // Set to single-thread (for sequential processing and/or debugging and/or reducing latency)
                        if (Flags.DisableMultiThread)
                            opWrapper.DisableMultiThreading();

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
                                Display(datumProcessed);
                            }
                            else
                            {
                                OpenPose.Log("Image could not be processed.", Priority.High);
                            }
                        }
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