using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class WDatumProducer<T> : WorkerProducer<T>
    {

        #region Fields

        private static readonly Dictionary<Type, ElementTypes> SupportTypes = new Dictionary<Type, ElementTypes>();

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors

        static WDatumProducer()
        {
            var types = new[]
            {
                new { Type = typeof(Datum),       ElementType = ElementTypes.Datum },
                new { Type = typeof(CustomDatum), ElementType = ElementTypes.CustomDatum }
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
                case ElementTypes.Datum:
                    this._DataType = OpenPose.DataType.Default;
                    break;
                case ElementTypes.CustomDatum:
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
                case ElementTypes.Datum:
                    this._DataType = OpenPose.DataType.Default;
                    break;
                case ElementTypes.CustomDatum:
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

        private enum ElementTypes
        {

            Datum,

            CustomDatum

        }

    }

}