using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class Array<T> : OpenPoseObject
    {

        #region Fields

        private static readonly Dictionary<Type, NativeMethods.ArrayElementType> SupportTypes = new Dictionary<Type, NativeMethods.ArrayElementType>();

        private readonly ArrayImp<T> _Imp;

        #endregion

        #region Constructors

        static Array()
        {
            var types = new[]
            {
                new { Type = typeof(float), ElementType = NativeMethods.ArrayElementType.Float }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        internal Array(IntPtr ptr, bool isEnabledDispose = true) :
            base(isEnabledDispose)
        {
            if (!SupportTypes.TryGetValue(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            this.ArrayElementType = type;
            this._Imp = CreateImp();

            this.NativePtr = ptr;
        }

        #endregion

        #region Properties

        internal NativeMethods.ArrayElementType ArrayElementType
        {
            get;
        }

        public float[] this[int index]
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = this._Imp.Gets(this.NativePtr, index);
                using (var vector = new StdVector<float>(ret))
                    return vector.ToArray();
            }
        }

        public bool Empty
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Imp.Empty(this.NativePtr);
            }
        }

        public uint NumberDimensions
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Imp.GetNumberDimensions(this.NativePtr);
            }
        }

        public uint Volume
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Imp.GetVolume(this.NativePtr);
            }
        }

        public T this[IEnumerable<int> indexes]
        {
            get
            {
                this.ThrowIfDisposed();
                using (var vector = new StdVector<int>(indexes))
                    return this._Imp.Operator(this.NativePtr, vector.NativePtr);
            }
        }

        #endregion

        #region Methods

        public IntPtr GetPtr()
        {
            this.ThrowIfDisposed();
            return this._Imp.GetPtr(this.NativePtr);
        }

        public int[] GetSize()
        {
            this.ThrowIfDisposed();

            var ret = this._Imp.GetSize(this.NativePtr);
            using (var vector = new StdVector<int>(ret))
                return vector.ToArray();
        }

        public int GetSize(int index)
        {
            this.ThrowIfDisposed();

            var ret = this._Imp.GetSize(this.NativePtr, index);

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

            this._Imp.Delete(this.NativePtr);
        }

        public override string ToString()
        {
            this.ThrowIfDisposed();

            var stdstr = IntPtr.Zero;
            var str = "";

            //try
            //{
            //    stdstr = this._Imp.ToString(this.NativePtr);
            //    str = StringHelper.FromStdString(stdstr) ?? "";
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.StackTrace);
            //}
            //finally
            //{
            //    if (stdstr != IntPtr.Zero)
            //        NativeMethods.std_string_delete(stdstr);
            //}

            return str;
        }

        #endregion

        #region Helpers

        private static ArrayImp<T> CreateImp()
        {
            if (SupportTypes.TryGetValue(typeof(T), out var type))
            {
                switch (type)
                {
                    case NativeMethods.ArrayElementType.Float:
                        return new ArrayFloatImp() as ArrayImp<T>;
                    case NativeMethods.ArrayElementType.Double:
                        return new ArrayDoubleImp() as ArrayImp<T>;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        #endregion

        #endregion

        #region Implements

        private abstract class ArrayImp<U>
        {

            #region Methods

            public abstract void Delete(IntPtr ptr);

            public abstract bool Empty(IntPtr ptr);

            public abstract IntPtr GetPtr(IntPtr ptr);

            public abstract int GetSize(IntPtr ptr, int index);

            public abstract IntPtr GetSize(IntPtr ptr);

            public abstract uint GetNumberDimensions(IntPtr ptr);

            public abstract uint GetVolume(IntPtr ptr);

            public abstract IntPtr Gets(IntPtr ptr, int index);

            public abstract U Operator(IntPtr ptr, IntPtr indexes);

            public abstract IntPtr ToString(IntPtr ptr);

            #endregion

        }

        private sealed class ArrayFloatImp : ArrayImp<float>
        {

            #region Methods

            public override void Delete(IntPtr ptr)
            {
                NativeMethods.op_core_Array_float_delete(ptr);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.op_core_Array_float_empty(ptr);
            }

            public override IntPtr GetPtr(IntPtr ptr)
            {
                return NativeMethods.op_core_Array_float_getPtr(ptr);
            }

            public override int GetSize(IntPtr ptr, int index)
            {
                return NativeMethods.op_core_Array_float_getSize(ptr, index);
            }

            public override IntPtr GetSize(IntPtr ptr)
            {
                return NativeMethods.op_core_Array_float_getSize2(ptr);
            }

            public override uint GetNumberDimensions(IntPtr ptr)
            {
                return NativeMethods.op_core_Array_float_getNumberDimensions(ptr);
            }

            public override uint GetVolume(IntPtr ptr)
            {
                return NativeMethods.op_core_Array_float_getVolume(ptr);
            }

            // vector<float>
            public override IntPtr Gets(IntPtr ptr, int index)
            {
                return NativeMethods.op_core_Array_float_gets(ptr, index);
            }

            // vector<float>
            public override float Operator(IntPtr ptr, IntPtr indexes)
            {
                return NativeMethods.op_core_Array_float_operator_indexes(ptr, indexes);
            }

            public override IntPtr ToString(IntPtr ptr)
            {
                return NativeMethods.op_core_Array_float_toString(ptr);
            }

            #endregion

        }

        private sealed class ArrayDoubleImp : ArrayImp<double>
        {

            #region Methods

            public override void Delete(IntPtr ptr)
            {
                NativeMethods.op_core_Array_double_delete(ptr);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.op_core_Array_double_empty(ptr);
            }

            public override IntPtr GetPtr(IntPtr ptr)
            {
                return NativeMethods.op_core_Array_double_getPtr(ptr);
            }

            public override int GetSize(IntPtr ptr, int index)
            {
                return NativeMethods.op_core_Array_double_getSize(ptr, index);
            }

            public override IntPtr GetSize(IntPtr ptr)
            {
                return NativeMethods.op_core_Array_double_getSize2(ptr);
            }

            public override uint GetNumberDimensions(IntPtr ptr)
            {
                return NativeMethods.op_core_Array_double_getNumberDimensions(ptr);
            }

            public override uint GetVolume(IntPtr ptr)
            {
                return NativeMethods.op_core_Array_double_getVolume(ptr);
            }

            public override IntPtr Gets(IntPtr ptr, int index)
            {
                return NativeMethods.op_core_Array_double_gets(ptr, index);
            }

            public override double Operator(IntPtr ptr, IntPtr indexes)
            {
                return NativeMethods.op_core_Array_double_operator_indexes(ptr, indexes);
            }

            public override IntPtr ToString(IntPtr ptr)
            {
                return NativeMethods.op_core_Array_double_toString(ptr);
            }

            #endregion

        }

        #endregion

    }

}
