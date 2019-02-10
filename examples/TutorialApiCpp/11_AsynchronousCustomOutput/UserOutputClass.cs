using OpenPoseDotNet;

namespace AsynchronousCustomOutput
{

    // This worker will just read and return all the jpg files in a directory
    internal sealed class UserOutputClass
    {

        #region Methods

        public bool Display(StdSharedPtr<StdVector<StdSharedPtr<Datum>>> datumsPtr)
        {
            // User's displaying/saving/other processing here
            // datum.cvOutputData: rendered frame with pose or heatmaps
            // datum.poseKeypoints: Array<float> with the estimated pose
            if (datumsPtr != null && datumsPtr.TryGet(out var data) && !data.Empty)
            {
                var temp = data.ToArray()[0].Get();
                Cv.ImShow($"{OpenPose.OpenPoseNameAndVersion()} - Tutorial C++ API", temp.CvOutputData);
                // Display image and sleeps at least 1 ms (it usually sleeps ~5-10 msec to display the image)
            }
            else
                OpenPose.Log("Nullptr or empty datumsPtr found.", Priority.High);

            var key = (char)Cv.WaitKey(1);
            return (key == 27);
        }

        public void PrintKeyPoints(StdSharedPtr<StdVector<StdSharedPtr<Datum>>> datumsPtr)
        {
            if (datumsPtr != null && datumsPtr.TryGet(out var data) && !data.Empty)
            {
                var array = data.ToArray();
                var datum = array[0].Get();

                OpenPose.Log("\nKeypoints:");
                // Accesing each element of the keypoints
                var poseKeypoints = datum.PoseKeyPoints;
                OpenPose.Log("Person pose keypoints:");
                for (var person = 0; person < poseKeypoints.GetSize(0); person++)
                {
                    OpenPose.Log($"Person {person} (x, y, score):");
                    for (var bodyPart = 0; bodyPart < poseKeypoints.GetSize(1); bodyPart++)
                    {
                        var valueToPrint = "";
                        for (var xyscore = 0; xyscore < poseKeypoints.GetSize(2); xyscore++)
                        {
                            valueToPrint += poseKeypoints[new[] { person, bodyPart, xyscore }] + " ";
                        }
                        OpenPose.Log(valueToPrint);
                    }
                }

                OpenPose.Log(" ");
                // Alternative: just getting std::string equivalent
                OpenPose.Log($"Face keypoints: {datum.FaceKeyPoints}", Priority.High);
                OpenPose.Log($"Left hand keypoints: {datum.HandKeyPoints[0]}", Priority.High);
                OpenPose.Log($"Right hand keypoints: {datum.HandKeyPoints[1]}", Priority.High);
                // Heatmaps
                var poseHeatMaps = datum.PoseHeatMaps;
                if (!poseHeatMaps.Empty)
                {
                    OpenPose.Log($"Pose heatmaps size: [{poseHeatMaps.GetSize(0)}, {poseHeatMaps.GetSize(1)}, {poseHeatMaps.GetSize(2)}]");
                    var faceHeatMaps = datum.FaceHeatMaps;
                    OpenPose.Log($"Face heatmaps size: [{faceHeatMaps.GetSize(0)}, {faceHeatMaps.GetSize(1)}, {faceHeatMaps.GetSize(2)}, {faceHeatMaps.GetSize(3)}]");
                    var handHeatMaps = datum.HandHeatMaps;
                    OpenPose.Log($"Left hand heatmaps size: [{handHeatMaps[0].GetSize(0)}, {handHeatMaps[0].GetSize(1)}, {handHeatMaps[0].GetSize(2)}, {handHeatMaps[0].GetSize(3)}]");
                    OpenPose.Log($"Right hand heatmaps size: [{handHeatMaps[1].GetSize(0)}, {handHeatMaps[1].GetSize(1)}, {handHeatMaps[1].GetSize(2)}, {handHeatMaps[1].GetSize(3)}]");
                }
            }
            else
                OpenPose.Log("Nullptr or empty datumsPtr found.", Priority.High);
        }

        #endregion

    }

}