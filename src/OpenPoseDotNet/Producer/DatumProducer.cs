using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class DatumProducer<T> : OpenPoseObject
    {

        #region Fields

        private static readonly Dictionary<Type, DatumType> SupportTypes = new Dictionary<Type, DatumType>();

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors

        static DatumProducer()
        {
            var types = new[]
            {
                new { Type = typeof(Datum),       ElementType = DatumType.Default },
                new { Type = typeof(CustomDatum), ElementType = DatumType.Custom }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        public DatumProducer(StdSharedPtr<Producer> producerSharedPtr,
                             ulong frameFirst = 0,
                             ulong frameStep = 1,
                             ulong frameLast = ulong.MaxValue)
        {
            if (producerSharedPtr == null)
                throw new ArgumentNullException(nameof(producerSharedPtr));

            producerSharedPtr.ThrowIfDisposed();

            if (!SupportTypes.TryGetValue(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            switch (type)
            {
                case DatumType.Default:
                    this._DataType = OpenPose.DataType.Default;
                    break;
                case DatumType.Custom:
                    this._DataType = OpenPose.DataType.Custom;
                    break;
            }

            this.NativePtr = OpenPose.Native.op_DatumProducer_new(this._DataType,
                                                                  producerSharedPtr.NativePtr,
                                                                  frameFirst,
                                                                  frameStep,
                                                                  frameLast,
                                                                  IntPtr.Zero);
        }
        
        internal DatumProducer(IntPtr ptr, bool isEnabledDispose = true) :
            base(isEnabledDispose)
        {
            if (!SupportTypes.TryGetValue(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            switch (type)
            {
                case DatumType.Default:
                    this._DataType = OpenPose.DataType.Default;
                    break;
                case DatumType.Custom:
                    this._DataType = OpenPose.DataType.Custom;
                    break;
            }

            this.NativePtr = ptr;
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

            OpenPose.Native.op_DatumProducer_delete(this._DataType, this.NativePtr);
        }

        #endregion

        #endregion

    }

}