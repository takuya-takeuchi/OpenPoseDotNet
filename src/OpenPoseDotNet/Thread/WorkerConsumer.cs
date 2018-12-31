using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public class WorkerConsumer<T> : Worker<T>
    {

        #region Fields

        private static readonly Dictionary<Type, DatumType> SupportTypes = new Dictionary<Type, DatumType>();

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors

        static WorkerConsumer()
        {
            var types = new[]
            {
                new { Type = typeof(Datum),       ElementType = DatumType.Default },
                new { Type = typeof(CustomDatum), ElementType = DatumType.Custom }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        protected WorkerConsumer() :
            base(IntPtr.Zero)
        {
        }

        protected WorkerConsumer(IntPtr ptr, bool isEnabledDispose = true) :
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
        }

        #endregion

    }

}