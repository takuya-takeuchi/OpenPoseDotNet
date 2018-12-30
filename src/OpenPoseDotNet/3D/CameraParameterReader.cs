using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class CameraParameterReader : OpenPoseObject
    {

        #region Constructors

        public CameraParameterReader()
        {
            this.NativePtr = Native.op_CameraParameterReader_new();
        }

        #endregion

        #region Properties

        public UInt64 NumberCameras
        {
            get
            {
                this.ThrowIfDisposed();
                return Native.op_CameraParameterReader_getNumberCameras(this.NativePtr);
            }
        }

        public bool UndistortImage
        {
            get
            {
                this.ThrowIfDisposed();
                return Native.op_CameraParameterReader_getUndistortImage(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                Native.op_CameraParameterReader_setUndistortImage(this.NativePtr, value);
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

            Native.op_CameraParameterReader_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_CameraParameterReader_new();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_CameraParameterReader_delete(IntPtr parameter);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern UInt64 op_CameraParameterReader_getNumberCameras(IntPtr parameter);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_CameraParameterReader_getUndistortImage(IntPtr parameter);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_CameraParameterReader_setUndistortImage(IntPtr parameter, bool undistortImage);

        }

    }

}