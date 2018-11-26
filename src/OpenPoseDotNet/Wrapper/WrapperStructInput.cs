using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class WrapperStructInput : OpenPoseObject
    {

        #region Fields

        public static readonly Point<int> DefaultCameraResolution = new Point<int>(-1, -1);

        #endregion

        #region Constructors

        public WrapperStructInput(ProducerType producerType = ProducerType.None,
                                  string producerString = "",
                                  ulong frameFirst = 0,
                                  ulong frameStep = 1,
                                  ulong frameLast = ulong.MaxValue,
                                  bool realTimeProcessing = false,
                                  bool frameFlip = false,
                                  int frameRotate = 0,
                                  bool framesRepeat = false,
                                  Point<int> cameraResolution = default(Point<int>),
                                  string cameraParameterPath = "models/cameraParameters/",
                                  bool undistortImage = true,
                                  uint imageDirectoryStereo = 1)
        {
            if (cameraParameterPath == null)
                throw new ArgumentNullException(nameof(cameraParameterPath));

            var producerStringBytes = Encoding.UTF8.GetBytes(producerString ?? "");
            var cameraParameterPathBytes = Encoding.UTF8.GetBytes(cameraParameterPath);

            using(var native = cameraResolution.ToNative())
                this.NativePtr = Native.op_wrapperStructInput_new(producerType,
                                                                  producerStringBytes,
                                                                  frameFirst,
                                                                  frameStep,
                                                                  frameLast,
                                                                  realTimeProcessing,
                                                                  frameFlip,
                                                                  frameRotate,
                                                                  framesRepeat,
                                                                  native.NativePtr,
                                                                  cameraParameterPathBytes,
                                                                  undistortImage,
                                                                  imageDirectoryStereo);
        }

        #endregion

        #region Methods

        #region Overrides

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            Native.op_wrapperStructInput_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_wrapperStructInput_new(ProducerType producerType,
                                                                  byte[] producerString,
                                                                  ulong frameFirst,
                                                                  ulong frameStep,
                                                                  ulong frameLast,
                                                                  bool realTimeProcessing,
                                                                  bool frameFlip,
                                                                  int frameRotate,
                                                                  bool framesRepeat,
                                                                  IntPtr cameraResolution,
                                                                  byte[] cameraParameterPath,
                                                                  bool undistortImage,
                                                                  uint imageDirectoryStereo);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapperStructInput_delete(IntPtr face);

        }

    }

}
