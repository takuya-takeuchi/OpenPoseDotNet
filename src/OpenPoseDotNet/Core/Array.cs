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

        public float[] this[int index]
        {
            get
            {
                this.ThrowIfDisposed();
                this.ThrowIfHasError(OpenPose.Native.op_core_Array_gets(this.NativePtr, this.ArrayElementType, index, out var ret));
                using (var vector = new StdVector<float>(ret))
                    return vector.ToArray();
            }
        }

        public bool Empty
        {
            get
            {
                this.ThrowIfDisposed();
                this.ThrowIfHasError(OpenPose.Native.op_core_Array_empty(this.NativePtr, this.ArrayElementType, out var ret));
                return ret;
            }
        }

        public uint NumberDimensions
        {
            get
            {
                this.ThrowIfDisposed();
                this.ThrowIfHasError(OpenPose.Native.op_core_Array_getNumberDimensions(this.NativePtr, this.ArrayElementType, out var ret));
                return ret;
            }
        }

        public uint Volume
        {
            get
            {
                this.ThrowIfDisposed();
                this.ThrowIfHasError(OpenPose.Native.op_core_Array_getVolume(this.NativePtr, this.ArrayElementType, out var ret));
                return ret;
            }
        }

        public float this[IEnumerable<int> indexes]
        {
            get
            {
                this.ThrowIfDisposed();
                using (var vector = new StdVector<int>(indexes))
                {
                    OpenPose.Native.op_core_Array_operator_indexes(this.NativePtr, this.ArrayElementType, vector.NativePtr, out var ret);
                    return ret;
                }
            }
        }

        #endregion

        #region Methods

        public int[] GetSize()
        {
            this.ThrowIfDisposed();
            this.ThrowIfHasError(OpenPose.Native.op_core_Array_getSize2(this.NativePtr, this.ArrayElementType, out var ret));
            using (var vector = new StdVector<int>(ret))
                return vector.ToArray();
        }

        public int GetSize(int index)
        {
            this.ThrowIfDisposed();
            this.ThrowIfHasError(OpenPose.Native.op_core_Array_getSize(this.NativePtr, this.ArrayElementType, index, out var ret));

            // openpose/include/openpose/core/array.hpp says
            // 'It will return 0 if the requested dimension is higher than the number of dimensions'
            // but this function never return 0. You can see this reason in  openpose/src/openpose/core/array.cpp.
            //if (ret == 0)
            //    throw new ArgumentOutOfRangeException();

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

            OpenPose.Native.op_core_array_delete(this.NativePtr);
        }

        public override string ToString()
        {
            this.ThrowIfDisposed();

            var stdstr = IntPtr.Zero;
            var str = "";

            try
            {
                stdstr = OpenPose.Native.op_core_Array_toString(this.NativePtr, this.ArrayElementType);
                str = StringHelper.FromStdString(stdstr) ?? "";
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

        #endregion

    }

}
