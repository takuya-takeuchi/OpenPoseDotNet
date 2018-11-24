using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenPoseDotNet.Interop;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class StdVector<TItem> : OpenPoseObject, IEnumerable<TItem>
    {

        #region Fields

        private static readonly Dictionary<Type, ElementTypes> SupportTypes = new Dictionary<Type, ElementTypes>();

        private readonly StdVectorImp<TItem> _Imp;

        #endregion

        #region Constructors

        static StdVector()
        {
            var types = new[]
            {
                new { Type = typeof(ErrorMode), ElementType = ElementTypes.ErrorMode },
                new { Type = typeof(LogMode),   ElementType = ElementTypes.LogMode },
                new { Type = typeof(Datum),     ElementType = ElementTypes.Datum }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        public StdVector(params object[] param)
        {
            this.Param = param;
            this._Imp = CreateImp(true, param);
            this.NativePtr = this._Imp.Create();
        }

        public StdVector(int size, params object[] param)
        {
            this.Param = param;
            this._Imp = CreateImp(true, param);
            this.NativePtr = this._Imp.Create(size);
        }

        public StdVector(IEnumerable<TItem> data, params object[] param)
        {
            this.Param = param;
            this._Imp = CreateImp(true, param);
            this.NativePtr = this._Imp.Create(data);
        }

        internal StdVector(IntPtr ptr, bool isEnabledDispose = true, params object[] param) :
            base(isEnabledDispose)
        {
            this.Param = param;
            this._Imp = CreateImp(isEnabledDispose, param);
            this.NativePtr = ptr;
        }

        #endregion

        #region Properties

        public bool Empty
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Imp.Empty(this.NativePtr);
            }
        }

        public IntPtr ElementPtr
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Imp.GetElementPtr(this.NativePtr);
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
                return this._Imp.GetSize(this.NativePtr);
            }
        }

        #endregion

        #region Methods

        public TItem[] ToArray()
        {
            this.ThrowIfDisposed();
            return this._Imp.ToArray(this.NativePtr);
        }

        #region Helpers

        private static StdVectorImp<TItem> CreateImp(bool isEnabledDispose, object[] param = null)
        {
            if (SupportTypes.TryGetValue(typeof(TItem), out var type))
            {
                switch (type)
                {
                    case ElementTypes.ErrorMode:
                        return new StdVectorErrorModeImp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.LogMode:
                        return new StdVectorLogModeImp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.Datum:
                        return new StdVectorDatumImp(isEnabledDispose) as StdVectorImp<TItem>;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        #endregion

        #endregion

        private enum ElementTypes
        {

            ErrorMode,

            LogMode,

            Datum

        }

        #region StdVectorImp

        private abstract class StdVectorImp<T>
        {

            #region Constructors

            protected StdVectorImp(bool isEnabledDispose)
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

            public abstract IntPtr Create();

            public abstract IntPtr Create(int size);

            public abstract IntPtr Create(IEnumerable<T> data);

            public abstract void Dispose(IntPtr ptr);

            public abstract bool Empty(IntPtr ptr);

            public abstract IntPtr GetElementPtr(IntPtr ptr);

            public abstract int GetSize(IntPtr ptr);

            public abstract T[] ToArray(IntPtr ptr);

            #endregion

        }

        private sealed class StdVectorErrorModeImp : StdVectorImp<ErrorMode>
        {

            #region Constructors

            internal StdVectorErrorModeImp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create()
            {
                return OpenPose.Native.stdvector_ErrorMode_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return OpenPose.Native.stdvector_ErrorMode_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<ErrorMode> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.ToArray();
                return OpenPose.Native.stdvector_ErrorMode_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                OpenPose.Native.stdvector_ErrorMode_delete(ptr);
            }

            public override bool Empty(IntPtr ptr)
            {
                return OpenPose.Native.stdvector_ErrorMode_empty(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return OpenPose.Native.stdvector_ErrorMode_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return OpenPose.Native.stdvector_ErrorMode_getSize(ptr).ToInt32();
            }

            public override ErrorMode[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new ErrorMode[0];

                var dst = new ErrorMode[size];
                var elementPtr = this.GetElementPtr(ptr);
                InteropHelper.Copy(elementPtr, dst, dst.Length);
                return dst;
            }

            #endregion

        }

        private sealed class StdVectorLogModeImp : StdVectorImp<LogMode>
        {

            #region Constructors

            internal StdVectorLogModeImp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create()
            {
                return OpenPose.Native.stdvector_LogMode_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return OpenPose.Native.stdvector_LogMode_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<LogMode> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.ToArray();
                return OpenPose.Native.stdvector_LogMode_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                OpenPose.Native.stdvector_LogMode_delete(ptr);
            }

            public override bool Empty(IntPtr ptr)
            {
                return OpenPose.Native.stdvector_LogMode_empty(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return OpenPose.Native.stdvector_LogMode_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return OpenPose.Native.stdvector_LogMode_getSize(ptr).ToInt32();
            }

            public override LogMode[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new LogMode[0];

                var dst = new LogMode[size];
                var elementPtr = this.GetElementPtr(ptr);
                InteropHelper.Copy(elementPtr, dst, dst.Length);
                return dst;
            }

            #endregion

        }

        private sealed class StdVectorDatumImp : StdVectorImp<Datum>
        {

            #region Constructors

            internal StdVectorDatumImp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create()
            {
                return OpenPose.Native.stdvector_Datum_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return OpenPose.Native.stdvector_Datum_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<Datum> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.Select(rectangle => rectangle.NativePtr).ToArray();
                return OpenPose.Native.stdvector_Datum_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                if (this.IsEnabledDispose)
                    OpenPose.Native.stdvector_Datum_delete(ptr);
            }

            public override bool Empty(IntPtr ptr)
            {
                return OpenPose.Native.stdvector_Datum_empty(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return OpenPose.Native.stdvector_Datum_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return OpenPose.Native.stdvector_Datum_getSize(ptr).ToInt32();
            }

            public override Datum[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new Datum[0];

                var dst = new IntPtr[size];
                OpenPose.Native.stdvector_Datum_copy(ptr, dst);
                return dst.Select(p => new Datum(p, this.IsEnabledDispose)).ToArray();
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