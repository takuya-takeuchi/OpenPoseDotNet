using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        #region Methods

        #region utilities/check

        public static void Check(bool condition,
                                 string message,
                                 int line = -1,
                                 string function = "",
                                 string file = "")
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            var messageBytes = Encoding.UTF8.GetBytes(message);
            var functionBytes = Encoding.UTF8.GetBytes(function ?? "");
            var fileBytes = Encoding.UTF8.GetBytes(file ?? "");

            NativeMethods.op_check(condition, messageBytes, line, functionBytes, fileBytes);
        }

        #endregion

        #region utilities/errorAndLog

        public static void DebugLog(string message,
                                    Priority priority = Priority.Max,
                                    int line = -1,
                                    string function = "",
                                    string file = "")
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            var messageBytes = Encoding.UTF8.GetBytes(message);
            var functionBytes = Encoding.UTF8.GetBytes(function ?? "");
            var fileBytes = Encoding.UTF8.GetBytes(file ?? "");

            NativeMethods.op_dLog(messageBytes, priority, line, functionBytes, fileBytes);
        }

        public static void Error(string message,
                                 int line = -1,
                                 string function = "",
                                 string file = "")
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            var messageBytes = Encoding.UTF8.GetBytes(message);
            var functionBytes = Encoding.UTF8.GetBytes(function ?? "");
            var fileBytes = Encoding.UTF8.GetBytes(file ?? "");

            NativeMethods.op_error(messageBytes, line, functionBytes, fileBytes);
        }

        public static void Log(string message,
                               Priority priority = Priority.Max,
                               int line = -1,
                               string function = "",
                               string file = "")
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            var messageBytes = Encoding.UTF8.GetBytes(message);
            var functionBytes = Encoding.UTF8.GetBytes(function ?? "");
            var fileBytes = Encoding.UTF8.GetBytes(file ?? "");

            NativeMethods.op_log(messageBytes, priority, line, functionBytes, fileBytes);
        }

        #endregion

        #region utilities/flagsToOpenPose

        public static Point<int> FlagsToPoint(string pointString, string pointExample)
        {
            if (pointString == null)
                throw new ArgumentNullException(nameof(pointString));
            if (pointExample == null)
                throw new ArgumentNullException(nameof(pointExample));

            var pointStringBytes = Encoding.UTF8.GetBytes(pointString);
            var pointExampleBytes = Encoding.UTF8.GetBytes(pointExample);

            NativeMethods.op_flagsToPoint_xy(pointStringBytes, pointExampleBytes, out var x, out var y);
            return new Point<int>(x, y);
        }

        public static RenderMode FlagsToRenderMode(int renderFlag, bool gpuBuggy, int renderPoseFlag = -2)
        {
            return NativeMethods.op_flagsToRenderMode(renderFlag, gpuBuggy, renderPoseFlag);
        }

        public static PoseModel FlagsToPoseModel(string poseModeString)
        {
            if (poseModeString == null)
                throw new ArgumentNullException(nameof(poseModeString));

            var poseModeStringBytes = Encoding.UTF8.GetBytes(poseModeString);

            return NativeMethods.op_flagsToPoseModel(poseModeStringBytes);
        }

        public static ScaleMode FlagsToScaleMode(int keyPointScale)
        {
            return NativeMethods.op_flagsToScaleMode(keyPointScale);
        }

        public static IEnumerable<HeatMapType> FlagsToHeatMaps(bool heatMapsAddParts,
                                                               bool heatMapsAddBkg,
                                                               bool heatMapsAddPAFs)
        {
            var ret = NativeMethods.op_flagsToHeatMaps(heatMapsAddParts, heatMapsAddBkg, heatMapsAddPAFs);
            using (var vector = new StdVector<HeatMapType>(ret))
                return vector.ToArray();
        }

        public static ScaleMode FlagsToHeatMapScaleMode(int heatMapScale)
        {
            return NativeMethods.op_flagsToHeatMapScaleMode(heatMapScale);
        }


        public static Tuple<ProducerType, string> FlagsToProducer(string imageDirectory,
                                                                  string videoPath,
                                                                  string ipCameraPath,
                                                                  int webcamIndex,
                                                                  bool flirCamera,
                                                                  int flirCameraIndex)
        {
            var imageDirectoryBytes = Encoding.UTF8.GetBytes(imageDirectory ?? "");
            var videoPathBytes = Encoding.UTF8.GetBytes(videoPath ?? "");
            var ipCameraPathBytes = Encoding.UTF8.GetBytes(ipCameraPath ?? "");
            NativeMethods.op_flagsToProducer(imageDirectoryBytes,
                                             videoPathBytes,
                                             ipCameraPathBytes,
                                             webcamIndex,
                                             flirCamera,
                                             flirCameraIndex,
                                             out var item1, 
                                             out var item2);

            var str = "";
            if (item2 != IntPtr.Zero)
                str = StringHelper.FromStdString(item2, true);

            return new Tuple<ProducerType, string>(item1, str);
        }

        public static DisplayMode FlagsToDisplayMode(int display, bool enabled3d)
        {
            return NativeMethods.op_flagsToDisplayMode(display, enabled3d);
        }

        #endregion

        #endregion

    }

}
