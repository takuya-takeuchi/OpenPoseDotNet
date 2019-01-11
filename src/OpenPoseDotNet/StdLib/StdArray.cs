using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class StdArray<TItem> : OpenPoseObject, IEnumerable<TItem>
    {

        #region Fields

        private static readonly Dictionary<Type, ElementTypes> SupportTypes = new Dictionary<Type, ElementTypes>();

        private readonly StdArrayImp<TItem> _Imp;

        #endregion

        #region Constructors

        static StdArray()
        {
            var types = new[]
            {
                new { Type = typeof(Array<float>),     ElementType = ElementTypes.ArrayFloat }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        public StdArray(int templateSize, params object[] param)
        {
            this.Param = param;
            this._Imp = CreateImp(true, param);
            this._TemplateSize = templateSize;
            this.NativePtr = this._Imp.Create(templateSize);
        }

        internal StdArray(IntPtr ptr, int templateSize, bool isEnabledDispose = true, params object[] param) :
            base(isEnabledDispose)
        {
            this.Param = param;
            this._Imp = CreateImp(isEnabledDispose, param);
            this._TemplateSize = templateSize;
            this.NativePtr = ptr;
        }

        #endregion

        #region Properties

        public bool Empty
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Imp.Empty(this.NativePtr, this._TemplateSize);
            }
        }

        public IntPtr ElementPtr
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Imp.GetElementPtr(this.NativePtr, this._TemplateSize);
            }
        }

        internal object[] Param
        {
            get;
            private set;
        }

        public int Size
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Imp.GetSize(this.NativePtr, this._TemplateSize);
            }
        }

        private int _TemplateSize;

        public int TemplateSize
        {
            get
            {
                this.ThrowIfDisposed();
                return this._TemplateSize;
            }
            private set
            {
                this.ThrowIfDisposed();
                this._TemplateSize = value;
            }
        }

        #endregion

        #region Methods

        public TItem[] ToArray()
        {
            this.ThrowIfDisposed();
            return this._Imp.ToArray(this.NativePtr, this._TemplateSize);
        }

        #region Helpers

        private static StdArrayImp<TItem> CreateImp(bool isEnabledDispose, object[] param = null)
        {
            if (SupportTypes.TryGetValue(typeof(TItem), out var type))
            {
                switch (type)
                {
                    case ElementTypes.ArrayFloat:
                        return new StdArrayArrayFloatImp(isEnabledDispose) as StdArrayImp<TItem>;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        #endregion

        #endregion

        private enum ElementTypes
        {

            ArrayFloat

        }

        #region StdArrayImp

        private abstract class StdArrayImp<T>
        {

            #region Constructors

            protected StdArrayImp(bool isEnabledDispose)
            {
                this.IsEnabledDispose = isEnabledDispose;
            }

            #endregion

            #region Properties

            protected bool IsEnabledDispose
            {
                get;
            }

            #endregion

            #region Methods

            public abstract IntPtr Create(int templateSize);

            public abstract void Dispose(IntPtr ptr, int templateSize);

            public abstract bool Empty(IntPtr ptr, int templateSize);

            public abstract IntPtr GetElementPtr(IntPtr ptr, int templateSize);

            public abstract int GetSize(IntPtr ptr, int templateSize);

            public abstract T[] ToArray(IntPtr ptr, int templateSize);

            #endregion

        }

        private sealed class StdArrayArrayFloatImp : StdArrayImp<Array<float>>
        {

            #region Constructors

            internal StdArrayArrayFloatImp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create(int templateSize)
            {
                if (templateSize < 0)
                    throw new ArgumentOutOfRangeException(nameof(templateSize));

                return NativeMethods.std_array_op_Array_float_new1(templateSize);
            }

            public override void Dispose(IntPtr ptr, int templateSize)
            {
                if (this.IsEnabledDispose)
                    NativeMethods.std_array_op_Array_float_delete(ptr, templateSize);
            }

            public override bool Empty(IntPtr ptr, int templateSize)
            {
                return NativeMethods.std_array_op_Array_float_empty(ptr, templateSize);
            }

            public override IntPtr GetElementPtr(IntPtr ptr, int templateSize)
            {
                return NativeMethods.std_array_op_Array_float_getPointer(ptr, templateSize);
            }

            public override int GetSize(IntPtr ptr, int templateSize)
            {
                return NativeMethods.std_array_op_Array_float_getSize(ptr, templateSize).ToInt32();
            }

            public override Array<float>[] ToArray(IntPtr ptr, int templateSize)
            {
                var size = this.GetSize(ptr, templateSize);
                if (size == 0)
                    return new Array<float>[0];

                var dst = new IntPtr[templateSize];
                NativeMethods.std_array_op_Array_float_copy(ptr, dst, templateSize);
                return dst.Select(p => new Array<float>(p, this.IsEnabledDispose)).ToArray();
            }

            #endregion

        }

        #endregion

        #region IEnumerable<TItem> Members

        public IEnumerator<TItem> GetEnumerator()
        {
            return ((IEnumerable<TItem>)this.ToArray()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

    }

}