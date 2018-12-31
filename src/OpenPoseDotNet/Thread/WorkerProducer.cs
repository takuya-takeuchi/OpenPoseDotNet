using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public class WorkerProducer<T> : Worker<T>
    {

        #region Fields

        private static readonly Dictionary<Type, DatumType> SupportTypes = new Dictionary<Type, DatumType>();

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors

        static WorkerProducer()
        {
            var types = new[]
            {
                new { Type = typeof(Datum),       ElementType = DatumType.Datum },
                new { Type = typeof(CustomDatum), ElementType = DatumType.CustomDatum }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        protected WorkerProducer():
            base(IntPtr.Zero)
        {
        }

        protected WorkerProducer(IntPtr ptr, bool isEnabledDispose = true) :
            base(ptr, isEnabledDispose)
        {
            if (!SupportTypes.TryGetValue(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            switch (type)
            {
                case DatumType.Datum:
                    this._DataType = OpenPose.DataType.Default;
                    break;
                case DatumType.CustomDatum:
                    this._DataType = OpenPose.DataType.Custom;
                    break;
            }
        }

        #endregion

    }

}