using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [StructLayout(LayoutKind.Explicit)]
        internal struct NativePointOfInt32
        {

            [FieldOffset(0)]
            public int x;

            [FieldOffset(4)]
            public int y;

        }

        #region utilities/check

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_check(bool condition,
                                           byte[] message,
                                           int line,
                                           byte[] function,
                                           byte[] file);

        #endregion

        #region utilities/errorAndLog

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_dLog(byte[] message,
                                                  Priority priority,
                                                  int line,
                                                  byte[] function,
                                                  byte[] file);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_error(byte[] message,
                                           int line,
                                           byte[] function,
                                           byte[] file);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_log(byte[] message,
                                         Priority priority,
                                         int line,
                                         byte[] function,
                                         byte[] file);

        #endregion

        #region utilities/flagsToOpenPose

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_flagsToPoint(byte[] pointString, byte[] pointExample);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_flagsToPoint_xy(byte[] pointString, byte[] pointExample, out int x, out int y);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern RenderMode op_flagsToRenderMode(int renderFlag, bool gpuBuggy, int renderPoseFlag);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern PoseModel op_flagsToPoseModel(byte[] poseModeString);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern ScaleMode op_flagsToScaleMode(int keyPointScale);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern IntPtr op_flagsToHeatMaps(bool heatMapsAddParts,
                                                       bool heatMapsAddBkg,
                                                       bool heatMapsAddPAFs);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern ScaleMode op_flagsToHeatMapScaleMode(int heatMapScale);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern void op_flagsToProducer(byte[] imageDirectory,
                                                     byte[] videoPath,
                                                     byte[] ipCameraPath,
                                                     int webcamIndex,
                                                     bool flirCamera,
                                                     int flirCameraIndex,
                                                     out ProducerType item1,
                                                     out IntPtr item2);

        [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
        public static extern DisplayMode op_flagsToDisplayMode(int display, bool enabled3d);

        #endregion

    }

}
