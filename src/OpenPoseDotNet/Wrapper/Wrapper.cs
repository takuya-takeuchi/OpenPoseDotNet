using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class Wrapper : WrapperBase<Datum>
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

        public override bool IsRunning
        {
            get
            {
                this.ThrowIfDisposed();

                return Native.op_wrapper_isRunning(this.NativePtr);
            }
        }

        #endregion

        #region Methods

        public override void Configure(WrapperStructPose pose)
        {
            if (pose == null)
                throw new ArgumentNullException(nameof(pose));

            pose.ThrowIfDisposed();

            Native.op_wrapper_configure_pose(this.NativePtr, pose.NativePtr);
        }

        public override void Configure(WrapperStructHand hand)
        {
            if (hand == null)
                throw new ArgumentNullException(nameof(hand));

            hand.ThrowIfDisposed();

            Native.op_wrapper_configure_hand(this.NativePtr, hand.NativePtr);
        }

        public override void Configure(WrapperStructFace face)
        {
            if (face == null)
                throw new ArgumentNullException(nameof(face));

            face.ThrowIfDisposed();

            Native.op_wrapper_configure_face(this.NativePtr, face.NativePtr);
        }
        
        public override void Configure(WrapperStructExtra extra)
        {
            if (extra == null)
                throw new ArgumentNullException(nameof(extra));

            extra.ThrowIfDisposed();

            Native.op_wrapper_configure_extra(this.NativePtr, extra.NativePtr);
        }

        public override void Configure(WrapperStructInput input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            input.ThrowIfDisposed();

            Native.op_wrapper_configure_input(this.NativePtr, input.NativePtr);
        }

        public override void Configure(WrapperStructOutput output)
        {
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            output.ThrowIfDisposed();

            Native.op_wrapper_configure_output(this.NativePtr, output.NativePtr);
        }

        public override void Configure(WrapperStructGui gui)
        {
            if (gui == null)
                throw new ArgumentNullException(nameof(gui));

            gui.ThrowIfDisposed();

            Native.op_wrapper_configure_gui(this.NativePtr, gui.NativePtr);
        }

        public override void DisableMultiThreading()
        {
            this.ThrowIfDisposed();

            Native.op_wrapper_disableMultiThreading(this.NativePtr);
        }

        public override SharedHandle<StdVector<Datum>> EmplaceAndPop(Mat mat)
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

        public override void Exec()
        {
            this.ThrowIfDisposed();

            Native.op_wrapper_exec(this.NativePtr);
        }

        public override void SetWorker(WorkerType workerType, OpenPoseObject worker, bool workerOnNewThread = true)
        {
            this.ThrowIfDisposed();

            Native.op_wrapper_setWorker(this.NativePtr, workerType, worker.NativePtr, workerOnNewThread);
        }

        public override void Start()
        {
            this.ThrowIfDisposed();

            Native.op_wrapper_start(this.NativePtr);
        }

        public override void Stop()
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
            public static extern void op_wrapper_setWorker(IntPtr wrapper, WorkerType workerType, IntPtr worker, bool workerOnNewThread);

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
            public static extern void op_wrapper_configure_pose(IntPtr wrapper, IntPtr wrapperStructPose);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_configure_face(IntPtr wrapper, IntPtr wrapperStructFace);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_configure_hand(IntPtr wrapper, IntPtr wrapperStructHand);
                
            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_configure_extra(IntPtr wrapper, IntPtr wrapperStructExtra);
            
            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_configure_input(IntPtr wrapper, IntPtr wrapperStructInput);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_configure_output(IntPtr wrapper, IntPtr wrapperStructOutput);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapper_configure_gui(IntPtr wrapper, IntPtr wrapperStructOutput);

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
