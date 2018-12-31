/*
 * This sample program is ported by C# from examples/tutorial_api_cpp/1_body_from_image.cpp.
*/

using System;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;
using OpenPoseDotNet;

namespace BodyFromImage
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
                Name = nameof(BodyFromImage)
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

                TutorialApiCpp1();

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

        private static int TutorialApiCpp1()
        {
            try
            {
                OpenPose.Log("Starting OpenPose demo...", Priority.High);

                // Configuring OpenPose
                OpenPose.Log("Configuring OpenPose...", Priority.High);
                using (var opWrapper = new Wrapper<Datum>(ThreadManagerMode.Asynchronous))
                {
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

                // Return successful message
                OpenPose.Log("Stopping OpenPose...", Priority.High);

                return 0;
            }
            catch (Exception)
            {
                return -1;
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

                // // Alternative 2
                // op::log(datumsPtr->at(0).poseKeypoints);

                // // Alternative 3
                // std::cout << datumsPtr->at(0).poseKeypoints << std::endl;

                // // Alternative 4 - Accesing each element of the keypoints
                // op::log("\nKeypoints:");
                // const auto& poseKeypoints = datumsPtr->at(0).poseKeypoints;
                // op::log("Person pose keypoints:");
                // for (auto person = 0 ; person < poseKeypoints.getSize(0) ; person++)
                // {
                //     op::log("Person " + std::to_string(person) + " (x, y, score):");
                //     for (auto bodyPart = 0 ; bodyPart < poseKeypoints.getSize(1) ; bodyPart++)
                //     {
                //         std::string valueToPrint;
                //         for (auto xyscore = 0 ; xyscore < poseKeypoints.getSize(2) ; xyscore++)
                //             valueToPrint += std::to_string(   poseKeypoints[{person, bodyPart, xyscore}]   ) + " ";
                //         op::log(valueToPrint);
                //     }
                // }
                // op::log(" ");
            }
            else
            {
                OpenPose.Log("Nullptr or empty datumsPtr found.", Priority.High);
            }
        }

        #endregion

        #endregion

    }

}