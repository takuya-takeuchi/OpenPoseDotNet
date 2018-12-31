using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class WDatumProducer<T> : WorkerProducer<T>
    {

        #region Fields

        private static readonly Dictionary<Type, DatumType> SupportTypes = new Dictionary<Type, DatumType>();

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors

        static WDatumProducer()
        {
            var types = new[]
            {
                new { Type = typeof(Datum),       ElementType = DatumType.Default },
                new { Type = typeof(CustomDatum), ElementType = DatumType.Custom }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        public WDatumProducer(StdSharedPtr<DatumProducer<T>> datumProducer)
        {
            if (datumProducer == null)
                throw new ArgumentNullException(nameof(datumProducer));

            datumProducer.ThrowIfDisposed();

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

            this.NativePtr = OpenPose.Native.op_WDatumProducer_new(this._DataType,
                                                                   datumProducer.NativePtr);
        }
        
        internal WDatumProducer(IntPtr ptr, bool isEnabledDispose = true) :
            base(ptr, isEnabledDispose)
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

            OpenPose.Native.op_WDatumProducer_delete(this._DataType, this.NativePtr);
        }

        #endregion

        #endregion

    }

}