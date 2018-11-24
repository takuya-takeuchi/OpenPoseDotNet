using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class Array<T> : OpenPoseObject
    {

        #region Fields

        private static readonly Dictionary<Type, OpenPose.Native.ArrayElementType> SupportTypes = new Dictionary<Type, OpenPose.Native.ArrayElementType>();

        #endregion

        #region Constructors

        static Array()
        {
            var types = new[]
            {
                new { Type = typeof(float), ElementType = OpenPose.Native.ArrayElementType.Float }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        internal Array(IntPtr ptr, bool isEnabledDispose = true) :
            base(isEnabledDispose)
        {
            if (!SupportTypes.TryGetValue(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            this.NativePtr = ptr;
            this.ArrayElementType = type;
        }

        #endregion

        #region Properties

        internal OpenPose.Native.ArrayElementType ArrayElementType
        {
            get;
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

            OpenPose.Native.op_core_array_delete(this.NativePtr);
        }
        public override string ToString()
        {
            var stdstr = IntPtr.Zero;
            var str = "";

            try
            {
                var ret = OpenPose.Native.op_core_Array_toString(this.NativePtr, this.ArrayElementType);
                str = StringHelper.FromStdString(ret) ?? "";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
            }

            return str;
        }

        #endregion

        #region Event Handlers
        #endregion

        #region Helpers
        #endregion

        #endregion

    }

}
