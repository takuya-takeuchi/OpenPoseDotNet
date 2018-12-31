using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class Wrapper<T> : OpenPoseObject
    {

        #region Fields

        private static readonly Dictionary<Type, ElementTypes> SupportTypes = new Dictionary<Type, ElementTypes>();

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors

        static Wrapper()
        {
            var types = new[]
            {
                new { Type = typeof(Datum),       ElementType = ElementTypes.Datum },
                new { Type = typeof(CustomDatum), ElementType = ElementTypes.CustomDatum }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Wrapper{T}"/> class with the specified ThreadManager synchronization mode.
        /// </summary>
        /// <param name="threadManagerMode"></param>
        public Wrapper(ThreadManagerMode threadManagerMode = ThreadManagerMode.Synchronous)
        {
            if (!SupportTypes.TryGetValue(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            switch (type)
            {
                case ElementTypes.Datum:
                    this._DataType = OpenPose.DataType.Default;
                    break;
                case ElementTypes.CustomDatum:
                    this._DataType = OpenPose.DataType.Custom;
                    break;
            }

            this.NativePtr = OpenPose.Native.op_wrapper_new(this._DataType, threadManagerMode);
        }

        #endregion

        #region Properties

        public bool IsRunning
        {
            get
            {
                this.ThrowIfDisposed();

                return OpenPose.Native.op_wrapper_isRunning(this._DataType, this.NativePtr);
            }
        }

        #endregion

        #region Methods

        public void Configure(WrapperStructPose pose)
        {
            if (pose == null)
                throw new ArgumentNullException(nameof(pose));

            pose.ThrowIfDisposed();

            OpenPose.Native.op_wrapper_configure_pose(this._DataType, this.NativePtr, pose.NativePtr);
        }

        public void Configure(WrapperStructHand hand)
        {
            if (hand == null)
                throw new ArgumentNullException(nameof(hand));

            hand.ThrowIfDisposed();

            OpenPose.Native.op_wrapper_configure_hand(this._DataType, this.NativePtr, hand.NativePtr);
        }

        public void Configure(WrapperStructFace face)
        {
            if (face == null)
                throw new ArgumentNullException(nameof(face));

            face.ThrowIfDisposed();

            OpenPose.Native.op_wrapper_configure_face(this._DataType, this.NativePtr, face.NativePtr);
        }
        
        public void Configure(WrapperStructExtra extra)
        {
            if (extra == null)
                throw new ArgumentNullException(nameof(extra));

            extra.ThrowIfDisposed();

            OpenPose.Native.op_wrapper_configure_extra(this._DataType, this.NativePtr, extra.NativePtr);
        }

        public void Configure(WrapperStructInput input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            input.ThrowIfDisposed();

            OpenPose.Native.op_wrapper_configure_input(this._DataType, this.NativePtr, input.NativePtr);
        }

        public void Configure(WrapperStructOutput output)
        {
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            output.ThrowIfDisposed();

            OpenPose.Native.op_wrapper_configure_output(this._DataType, this.NativePtr, output.NativePtr);
        }

        public void Configure(WrapperStructGui gui)
        {
            if (gui == null)
                throw new ArgumentNullException(nameof(gui));

            gui.ThrowIfDisposed();

            OpenPose.Native.op_wrapper_configure_gui(this._DataType, this.NativePtr, gui.NativePtr);
        }

        public void DisableMultiThreading()
        {
            this.ThrowIfDisposed();

            OpenPose.Native.op_wrapper_disableMultiThreading(this._DataType, this.NativePtr);
        }

        public StdSharedPtr<StdVector<T>> EmplaceAndPop(Mat mat)
        {
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));

            mat.ThrowIfDisposed();

            var ret = OpenPose.Native.op_wrapper_emplaceAndPop_cvMat(this._DataType, this.NativePtr, mat.NativePtr);
            return new StdSharedPtr<StdVector<T>>(ret);
        }

        public void Exec()
        {
            this.ThrowIfDisposed();

            OpenPose.Native.op_wrapper_exec(this._DataType, this.NativePtr);
        }

        public void SetWorker<U>(WorkerType workerType, StdSharedPtr<U> worker, bool workerOnNewThread = true)
            where U : Worker<T>
        {
            this.ThrowIfDisposed();

            OpenPose.Native.op_wrapper_setWorker(this._DataType, this.NativePtr, workerType, worker.NativePtr, workerOnNewThread);
        }

        public void Start()
        {
            this.ThrowIfDisposed();

            OpenPose.Native.op_wrapper_start(this._DataType, this.NativePtr);
        }

        public void Stop()
        {
            this.ThrowIfDisposed();

            OpenPose.Native.op_wrapper_stop(this._DataType, this.NativePtr);
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

            OpenPose.Native.op_wrapper_delete(this._DataType, this.NativePtr);
        }

        #endregion

        #endregion

        private enum ElementTypes
        {

            Datum,

            CustomDatum

        }

    }

}
