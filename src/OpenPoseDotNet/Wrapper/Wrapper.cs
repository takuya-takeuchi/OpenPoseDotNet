using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class Wrapper : OpenPoseObject
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Wrapper"/> class with the specified ThreadManager synchronization mode.
        /// </summary>
        /// <param name="threadManagerMode"></param>
        public Wrapper(ThreadManagerMode threadManagerMode = ThreadManagerMode.Synchronous)
        {
            this.NativePtr = Native.op_wrapper_new(threadManagerMode);
        }

        #endregion

        #region Properties

        public bool IsRunning
        {
            get
            {
                this.ThrowIfDisposed();

                return Native.op_wrapper_isRunning(this.NativePtr);
            }
        }

        #endregion

        #region Methods

        public void DisableMultiThreading()
        {
            this.ThrowIfDisposed();

            Native.op_wrapper_disableMultiThreading(this.NativePtr);
        }

        public SharedHandle<StdVector<Datum>> EmplaceAndPop(Mat mat)
        {
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));

            mat.ThrowIfDisposed();

            var ret = Native.op_wrapper_emplaceAndPop_cvMat(this.NativePtr, mat.NativePtr);
            return new SharedHandle<StdVector<Datum>>(ret, 
                                                      ptr => new StdVector<Datum>(ptr, false), 
                                                      OpenPose.Native.op_shared_ptr_TDatums_getter,
                                                      OpenPose.Native.op_shared_ptr_TDatums_delete);
        }

        public void Exec()
        {
            this.ThrowIfDisposed();

            Native.op_wrapper_exec(this.NativePtr);
        }

        public void Start()
        {
            this.ThrowIfDisposed();

            Native.op_wrapper_start(this.NativePtr);
        }

        public void Stop()
        {
            this.ThrowIfDisposed();

            Native.op_wrapper_stop(this.NativePtr);
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

            Native.op_wrapper_delete(this.NativePtr);
        }

        #endregion

        #region Helpers
        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_wrapper_new(ThreadManagerMode threadManagerMode);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_delete(IntPtr wrapper);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_disableMultiThreading(IntPtr wrapper);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_exec(IntPtr wrapper);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_start(IntPtr wrapper);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_stop(IntPtr wrapper);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_wrapper_isRunning(IntPtr wrapper);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_wrapper_emplaceAndPop_cvMat(IntPtr wrapper, IntPtr mat);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_wrapper_emplaceAndPop_rawImage(IntPtr wrapper,
                                                                          byte[] data,
                                                                          int width,
                                                                          int height,
                                                                          int type);

        }

    }

}
