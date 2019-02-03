using System;
using System.Drawing;
using System.Drawing.Imaging;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class Wrapper<T> : OpenPoseObject
        where T : Datum
    {

        #region Fields

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Wrapper{T}"/> class with the specified ThreadManager synchronization mode.
        /// </summary>
        /// <param name="threadManagerMode"></param>
        public Wrapper(ThreadManagerMode threadManagerMode = ThreadManagerMode.Synchronous)
        {
            this._DataType = GenericHelpers.CheckDatumSupportTypes<T>();
            this.NativePtr = NativeMethods.op_wrapper_new(this._DataType, threadManagerMode);
        }

        #endregion

        #region Properties

        public bool IsRunning
        {
            get
            {
                this.ThrowIfDisposed();

                return NativeMethods.op_wrapper_isRunning(this._DataType, this.NativePtr);
            }
        }

        #endregion

        #region Methods

        public void Configure(WrapperStructPose pose)
        {
            if (pose == null)
                throw new ArgumentNullException(nameof(pose));

            pose.ThrowIfDisposed();

            NativeMethods.op_wrapper_configure_pose(this._DataType, this.NativePtr, pose.NativePtr);
        }

        public void Configure(WrapperStructHand hand)
        {
            if (hand == null)
                throw new ArgumentNullException(nameof(hand));

            hand.ThrowIfDisposed();

            NativeMethods.op_wrapper_configure_hand(this._DataType, this.NativePtr, hand.NativePtr);
        }

        public void Configure(WrapperStructFace face)
        {
            if (face == null)
                throw new ArgumentNullException(nameof(face));

            face.ThrowIfDisposed();

            NativeMethods.op_wrapper_configure_face(this._DataType, this.NativePtr, face.NativePtr);
        }

        public void Configure(WrapperStructExtra extra)
        {
            if (extra == null)
                throw new ArgumentNullException(nameof(extra));

            extra.ThrowIfDisposed();

            NativeMethods.op_wrapper_configure_extra(this._DataType, this.NativePtr, extra.NativePtr);
        }

        public void Configure(WrapperStructInput input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            input.ThrowIfDisposed();

            NativeMethods.op_wrapper_configure_input(this._DataType, this.NativePtr, input.NativePtr);
        }

        public void Configure(WrapperStructOutput output)
        {
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            output.ThrowIfDisposed();

            NativeMethods.op_wrapper_configure_output(this._DataType, this.NativePtr, output.NativePtr);
        }

        public void Configure(WrapperStructGui gui)
        {
            if (gui == null)
                throw new ArgumentNullException(nameof(gui));

            gui.ThrowIfDisposed();

            NativeMethods.op_wrapper_configure_gui(this._DataType, this.NativePtr, gui.NativePtr);
        }

        public void DisableMultiThreading()
        {
            this.ThrowIfDisposed();

            NativeMethods.op_wrapper_disableMultiThreading(this._DataType, this.NativePtr);
        }

        public StdSharedPtr<StdVector<T>> EmplaceAndPop(Mat mat)
        {
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));

            mat.ThrowIfDisposed();

            var ret = NativeMethods.op_wrapper_emplaceAndPop_cvMat(this._DataType, this.NativePtr, mat.NativePtr);
            return new StdSharedPtr<StdVector<T>>(ret);
        }

        public StdSharedPtr<StdVector<T>> EmplaceAndPop(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException(nameof(bitmap));

            byte[] image = null;
            var format = bitmap.PixelFormat;
            var width = bitmap.Width;
            var height = bitmap.Height;
            var size = new Size(width, height);

            int type;
            switch (format)
            {
                case PixelFormat.Format24bppRgb:
                    type = MatType.CV_8UC3;
                    break;
                case PixelFormat.Format32bppArgb:
                    type = MatType.CV_8UC4;
                    break;
                case PixelFormat.Format8bppIndexed:
                    type = MatType.CV_8UC1;
                    break;
                default:
                    throw new ArgumentException($"{bitmap.PixelFormat} is not supported.");
            }

            BitmapData data = null;

            try
            {
                var channels = MatType.Channels(type);

                data = bitmap.LockBits(new Rectangle(Point.Empty, size), ImageLockMode.ReadOnly, format);

                var stride = data.Stride;
                var scan0 = data.Scan0;
                var line = width * channels;
                image = new byte[line * height];

                unsafe
                {
                    fixed (byte* pi = &image[0])
                    {
                        var ppi = pi;
                        var ps = (byte*)scan0;
                        for (var h = 0; h < height; h++)
                        {
                            NativeMethods.cstd_memcpy(ppi, ps, line);
                            ps += stride;
                            ppi += line;
                        }
                    }
                }
            }
            finally
            {
                if (data != null)
                    bitmap.UnlockBits(data);
            }

            var ret = NativeMethods.op_wrapper_emplaceAndPop_rawImage(this._DataType,
                                                                      this.NativePtr,
                                                                      image,
                                                                      width,
                                                                      height,
                                                                      type);
            return new StdSharedPtr<StdVector<T>>(ret);
        }

        public StdSharedPtr<StdVector<T>> EmplaceAndPop(byte[] image, int width, int height, int type)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            var ret = NativeMethods.op_wrapper_emplaceAndPop_rawImage(this._DataType,
                                                                      this.NativePtr,
                                                                      image,
                                                                      width,
                                                                      height,
                                                                      type);
            return new StdSharedPtr<StdVector<T>>(ret);
        }

        public void Exec()
        {
            this.ThrowIfDisposed();

            NativeMethods.op_wrapper_exec(this._DataType, this.NativePtr);
        }

        public void SetWorker<U>(WorkerType workerType, StdSharedPtr<U> worker, bool workerOnNewThread = true)
            where U : Worker<T>
        {
            this.ThrowIfDisposed();

            NativeMethods.op_wrapper_setWorker(this._DataType, this.NativePtr, workerType, worker.NativePtr, workerOnNewThread);
        }

        public void Start()
        {
            this.ThrowIfDisposed();

            NativeMethods.op_wrapper_start(this._DataType, this.NativePtr);
        }

        public void Stop()
        {
            this.ThrowIfDisposed();

            NativeMethods.op_wrapper_stop(this._DataType, this.NativePtr);
        }

        public bool WaitAndEmplace(StdSharedPtr<StdVector<T>> datums)
        {
            if (datums == null)
                throw new ArgumentNullException(nameof(datums));

            datums.ThrowIfDisposed();
            this.ThrowIfDisposed();

            return NativeMethods.op_wrapper_waitAndEmplace(this._DataType, this.NativePtr, datums.NativePtr);
        }

        public bool WaitAndPop(out StdSharedPtr<StdVector<T>> datums)
        {
            this.ThrowIfDisposed();

            var ret = NativeMethods.op_wrapper_waitAndPop(this._DataType, this.NativePtr, out var tDatums);
            datums = ret ? new StdSharedPtr<StdVector<T>>(tDatums) : null;
            return ret;
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

            NativeMethods.op_wrapper_delete(this._DataType, this.NativePtr);
        }

        #endregion

        #endregion

    }

}