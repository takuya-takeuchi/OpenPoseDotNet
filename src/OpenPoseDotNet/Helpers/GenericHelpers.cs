using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal static class GenericHelpers
    {

        #region Fields

        private static readonly Dictionary<Type, DatumType> DatumSupportTypes = new Dictionary<Type, DatumType>();

        #endregion

        #region Constructors

        static GenericHelpers()
        {
            var datumSupportTypes = new[]
            {
                new { Type = typeof(Datum),       ElementType = DatumType.Default },
                new { Type = typeof(CustomDatum), ElementType = DatumType.Custom }
            };

            foreach (var type in datumSupportTypes)
                DatumSupportTypes.Add(type.Type, type.ElementType);
        }

        #endregion

        #region Methods

        public static OpenPose.DataType CheckDatumSupportTypes<T>()
        {
            if (DatumSupportTypes.TryGetValue(typeof(T), out var type))
            {
                switch (type)
                {
                    case DatumType.Default:
                        return OpenPose.DataType.Default;
                    case DatumType.Custom:
                        return OpenPose.DataType.Custom;
                }
            }

            throw new NotSupportedException($"{typeof(T).Name} does not support");
        }

        #endregion

    }

}