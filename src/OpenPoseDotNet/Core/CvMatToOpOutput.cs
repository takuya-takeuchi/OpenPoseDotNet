using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class CvMatToOpOutput : OpenPoseObject
    {

        #region Constructors

        public CvMatToOpOutput()
        {
            this.NativePtr = Native.op_core_CvMatToOpOutput_new();
        }

        #endregion

        #region Methods

        public Array<float> CreateArray(Mat cvInputData, double scaleInputToOutput, Point<int> outputResolution)
        {
            if (cvInputData == null)
                throw new ArgumentNullException(nameof(cvInputData));

            this.ThrowIfDisposed();

            using (var resolution = outputResolution.ToNative())
            {
                var ret = Native.op_core_CvMatToOpOutput_createArray(this.NativePtr, cvInputData.NativePtr, scaleInputToOutput, resolution.NativePtr);
                return new Array<float>(ret);
            }
        }

        #region Overrides

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            Native.op_core_CvMatToOpOutput_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_core_CvMatToOpOutput_new();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_core_CvMatToOpOutput_delete(IntPtr extractor);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_core_CvMatToOpOutput_createArray(IntPtr output,
                                                                            IntPtr cvInputData,
                                                                            double scaleInputToOutput,
                                                                            IntPtr outputResolution);
        }

    }

}
