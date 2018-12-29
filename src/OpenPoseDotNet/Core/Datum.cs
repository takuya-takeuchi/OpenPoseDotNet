using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public class Datum : OpenPoseObject
    {

        #region Constructors

        internal Datum(IntPtr ptr, bool isEnabledDispose = true) :
            base(isEnabledDispose)
        {
            this.NativePtr = ptr;
        }

        #endregion

        #region Properties

        public Mat CvOutputData
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = Native.op_core_datum_get_cvOutputData(this.NativePtr);

                // Datum.cvOutputData is not pointer. Therefore, this object must not be disposed.
                return new Mat(ret, false);
            }
        }

        public ulong FrameNumber
        {
            get
            {
                this.ThrowIfDisposed();
                return Native.op_core_datum_get_frameNumber(this.NativePtr);
            }
        }

        public ulong Id
        {
            get
            {
                this.ThrowIfDisposed();
                return Native.op_core_datum_get_id(this.NativePtr);
            }
        }

        public Array<float> PoseKeyPoints
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = Native.op_core_datum_get_poseKeypoints(this.NativePtr);

                // Datum.poseKeypoints is not pointer. Therefore, this object must not be disposed.
                return new Array<float>(ret, false);
            }
        }

        public Array<float> FaceKeyPoints
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = Native.op_core_datum_get_faceKeypoints(this.NativePtr);

                // Datum.poseKeypoints is not pointer. Therefore, this object must not be disposed.
                return new Array<float>(ret, false);
            }
        }

        public Array<float>[] HandKeyPoints
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = Native.op_core_datum_get_handKeypoints(this.NativePtr);

                // Datum.poseKeypoints is not pointer. Therefore, this object must not be disposed.
                using (var array = new StdArray<Array<float>>(ret, 2, false))
                    return array.ToArray();
            }
        }

        public ulong SubId
        {
            get
            {
                this.ThrowIfDisposed();
                return Native.op_core_datum_get_subId(this.NativePtr);
            }
        }

        public ulong SubIdMax
        {
            get
            {
                this.ThrowIfDisposed();
                return Native.op_core_datum_get_subIdMax(this.NativePtr);
            }
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

            Native.op_core_datum_delete(this.NativePtr);
        }

        #endregion

        #region Event Handlers
        #endregion

        #region Helpers
        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_core_datum_new();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_core_datum_delete(IntPtr datum);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern ulong op_core_datum_get_id(IntPtr datum);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern ulong op_core_datum_get_subId(IntPtr datum);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern ulong op_core_datum_get_subIdMax(IntPtr datum);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern ulong op_core_datum_get_frameNumber(IntPtr datum);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_core_datum_get_cvOutputData(IntPtr datum);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_core_datum_get_poseKeypoints(IntPtr datum);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_core_datum_get_faceKeypoints(IntPtr datum);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_core_datum_get_handKeypoints(IntPtr datum);



        }

    }

}
