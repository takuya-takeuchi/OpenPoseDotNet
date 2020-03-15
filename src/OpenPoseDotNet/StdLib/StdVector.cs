using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
                new { Type = typeof(int),                       ElementType = ElementTypes.Int32 },
                new { Type = typeof(uint),                      ElementType = ElementTypes.UInt32 },
                new { Type = typeof(float),                     ElementType = ElementTypes.Float },
                new { Type = typeof(double),                    ElementType = ElementTypes.Double },
                new { Type = typeof(ErrorMode),                 ElementType = ElementTypes.ErrorMode },
                new { Type = typeof(LogMode),                   ElementType = ElementTypes.LogMode },
                new { Type = typeof(Point<int>),                ElementType = ElementTypes.PointOfInt32 },
                new { Type = typeof(Rectangle<float>),          ElementType = ElementTypes.RectangleOfFloat },
                new { Type = typeof(Array<float>),              ElementType = ElementTypes.ArrayFloat },
                new { Type = typeof(Datum),                     ElementType = ElementTypes.Datum },
                new { Type = typeof(CustomDatum),               ElementType = ElementTypes.CustomDatum },
                new { Type = typeof(StdSharedPtr<Datum>),       ElementType = ElementTypes.SharedPtrDatum },
                new { Type = typeof(StdSharedPtr<CustomDatum>), ElementType = ElementTypes.SharedPtrCustomDatum },
                new { Type = typeof(HeatMapType),               ElementType = ElementTypes.HeatMapType },
                new { Type = typeof(Mat),                       ElementType = ElementTypes.OpenCVMat }
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

        public TItem At(int index)
        {
            this.ThrowIfDisposed();
            return this._Imp.At(this.NativePtr, index);
        }

        public void EmplaceBack()
        {
            this.ThrowIfDisposed();
            this._Imp.EmplaceBack(this.NativePtr);
        }

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
                    case ElementTypes.Int32:
                        return new StdVectorInt32Imp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.UInt32:
                        return new StdVectorUInt32Imp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.Float:
                        return new StdVectorFloatImp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.Double:
                        return new StdVectorDoubleImp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.ErrorMode:
                        return new StdVectorErrorModeImp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.LogMode:
                        return new StdVectorLogModeImp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.PointOfInt32:
                        return new StdVectorPointOfInt32Imp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.RectangleOfFloat:
                        return new StdVectorRectangleOfFloatImp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.ArrayFloat:
                        return new StdVectorArrayOfFloatImp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.Datum:
                        return new StdVectorDatumImp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.CustomDatum:
                        return new StdVectorCustomDatumImp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.SharedPtrDatum:
                        return new StdVectorStdSharedPtrOfDatumImp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.SharedPtrCustomDatum:
                        return new StdVectorStdSharedPtrOfCustomDatumImp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.HeatMapType:
                        return new StdVectorHeatMapTypeImp(isEnabledDispose) as StdVectorImp<TItem>;
                    case ElementTypes.OpenCVMat:
                        return new StdVectorOpenCVMatImp(isEnabledDispose) as StdVectorImp<TItem>;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        #endregion

        #endregion

        private enum ElementTypes
        {

            Int32,

            UInt32,

            Float,

            Double,

            ErrorMode,

            LogMode,

            PointOfInt32,

            RectangleOfFloat,

            ArrayFloat,

            Datum,

            CustomDatum,

            SharedPtrDatum,

            SharedPtrCustomDatum,

            HeatMapType,

            OpenCVMat

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

            public abstract T At(IntPtr ptr, int index);

            public abstract bool Empty(IntPtr ptr);

            public abstract void EmplaceBack(IntPtr ptr);

            public abstract IntPtr GetElementPtr(IntPtr ptr);

            public abstract int GetSize(IntPtr ptr);

            public abstract T[] ToArray(IntPtr ptr);

            #endregion

        }

        private sealed class StdVectorInt32Imp : StdVectorImp<int>
        {

            #region Constructors

            internal StdVectorInt32Imp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_vector_int32_t_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_int32_t_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<int> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.ToArray();
                return NativeMethods.std_vector_int32_t_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.std_vector_int32_t_delete(ptr);
            }

            public override int At(IntPtr ptr, int index)
            {
                return NativeMethods.std_vector_int32_t_at(ptr, index);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.std_vector_int32_t_empty(ptr);
            }

            public override void EmplaceBack(IntPtr ptr)
            {
                NativeMethods.std_vector_int32_t_emplace_back(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_int32_t_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_int32_t_getSize(ptr).ToInt32();
            }

            public override int[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new int[0];

                var dst = new int[size];
                var elementPtr = this.GetElementPtr(ptr);
                Marshal.Copy(elementPtr, dst, 0, dst.Length);
                return dst;
            }

            #endregion

        }

        private sealed class StdVectorUInt32Imp : StdVectorImp<uint>
        {

            #region Constructors

            internal StdVectorUInt32Imp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_vector_uint32_t_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_uint32_t_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<uint> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.ToArray();
                return NativeMethods.std_vector_uint32_t_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.std_vector_uint32_t_delete(ptr);
            }

            public override uint At(IntPtr ptr, int index)
            {
                return NativeMethods.std_vector_uint32_t_at(ptr, index);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.std_vector_uint32_t_empty(ptr);
            }

            public override void EmplaceBack(IntPtr ptr)
            {
                NativeMethods.std_vector_uint32_t_emplace_back(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_uint32_t_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_uint32_t_getSize(ptr).ToInt32();
            }

            public override uint[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new uint[0];

                var dst = new uint[size];
                var elementPtr = this.GetElementPtr(ptr);
                InteropHelper.Copy(elementPtr, dst, dst.Length);
                return dst;
            }

            #endregion

        }

        private sealed class StdVectorFloatImp : StdVectorImp<float>
        {

            #region Constructors

            internal StdVectorFloatImp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_vector_float_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_float_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<float> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.ToArray();
                return NativeMethods.std_vector_float_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.std_vector_float_delete(ptr);
            }

            public override float At(IntPtr ptr, int index)
            {
                return NativeMethods.std_vector_float_at(ptr, index);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.std_vector_float_empty(ptr);
            }

            public override void EmplaceBack(IntPtr ptr)
            {
                NativeMethods.std_vector_float_emplace_back(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_float_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_float_getSize(ptr).ToInt32();
            }

            public override float[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new float[0];

                var dst = new float[size];
                var elementPtr = this.GetElementPtr(ptr);
                Marshal.Copy(elementPtr, dst, 0, dst.Length);
                return dst;
            }

            #endregion

        }

        private sealed class StdVectorDoubleImp : StdVectorImp<double>
        {

            #region Constructors

            internal StdVectorDoubleImp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_vector_double_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_double_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<double> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.ToArray();
                return NativeMethods.std_vector_double_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.std_vector_double_delete(ptr);
            }

            public override double At(IntPtr ptr, int index)
            {
                return NativeMethods.std_vector_double_at(ptr, index);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.std_vector_double_empty(ptr);
            }

            public override void EmplaceBack(IntPtr ptr)
            {
                NativeMethods.std_vector_double_emplace_back(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_double_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_double_getSize(ptr).ToInt32();
            }

            public override double[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new double[0];

                var dst = new double[size];
                var elementPtr = this.GetElementPtr(ptr);
                Marshal.Copy(elementPtr, dst, 0, dst.Length);
                return dst;
            }

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
                return NativeMethods.std_vector_ErrorMode_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_ErrorMode_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<ErrorMode> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.ToArray();
                return NativeMethods.std_vector_ErrorMode_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.std_vector_ErrorMode_delete(ptr);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.std_vector_ErrorMode_empty(ptr);
            }

            public override ErrorMode At(IntPtr ptr, int index)
            {
                return NativeMethods.std_vector_ErrorMode_at(ptr, index);
            }

            public override void EmplaceBack(IntPtr ptr)
            {
                NativeMethods.std_vector_ErrorMode_emplace_back(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_ErrorMode_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_ErrorMode_getSize(ptr).ToInt32();
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
                return NativeMethods.std_vector_LogMode_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_LogMode_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<LogMode> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.ToArray();
                return NativeMethods.std_vector_LogMode_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.std_vector_LogMode_delete(ptr);
            }

            public override LogMode At(IntPtr ptr, int index)
            {
                return NativeMethods.std_vector_LogMode_at(ptr, index);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.std_vector_LogMode_empty(ptr);
            }

            public override void EmplaceBack(IntPtr ptr)
            {
                NativeMethods.std_vector_LogMode_emplace_back(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_LogMode_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_LogMode_getSize(ptr).ToInt32();
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

        private sealed class StdVectorPointOfInt32Imp : StdVectorImp<Point<int>>
        {

            #region Constructors

            internal StdVectorPointOfInt32Imp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_vector_PointOfInt32_t_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_PointOfInt32_t_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<Point<int>> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.Select(p => new NativeMethods.NativePointOfInt32 { x = p.X, y = p.Y }).ToArray();
                return NativeMethods.std_vector_PointOfInt32_t_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.std_vector_PointOfInt32_t_delete(ptr);
            }

            public override Point<int> At(IntPtr ptr, int index)
            {
                var ret = NativeMethods.std_vector_PointOfInt32_t_at(ptr, index);
                return new Point<int>(ret, false);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.std_vector_PointOfInt32_t_empty(ptr);
            }

            public override void EmplaceBack(IntPtr ptr)
            {
                NativeMethods.std_vector_PointOfInt32_t_emplace_back(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_PointOfInt32_t_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_PointOfInt32_t_getSize(ptr).ToInt32();
            }

            public override Point<int>[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new Point<int>[0];

                var dst = new NativeMethods.NativePointOfInt32[size];
                var elementPtr = this.GetElementPtr(ptr);
                InteropHelper.Copy(elementPtr, dst, dst.Length);
                return dst.Select(p => new Point<int>(p.x, p.y)).ToArray();
            }

            #endregion

        }

        private sealed class StdVectorRectangleOfFloatImp : StdVectorImp<Rectangle<float>>
        {

            #region Constructors

            internal StdVectorRectangleOfFloatImp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_vector_RectangleOfFloat_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_RectangleOfFloat_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<Rectangle<float>> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.Select(p => new NativeMethods.NativeRectangleOfFloat { x = p.X, y = p.Y, width = p.Width, height = p.Height }).ToArray();
                return NativeMethods.std_vector_RectangleOfFloat_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.std_vector_RectangleOfFloat_delete(ptr);
            }

            public override Rectangle<float> At(IntPtr ptr, int index)
            {
                var ret = NativeMethods.std_vector_RectangleOfFloat_at(ptr, index);
                return new Rectangle<float>(ret, false);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.std_vector_RectangleOfFloat_empty(ptr);
            }

            public override void EmplaceBack(IntPtr ptr)
            {
                NativeMethods.std_vector_RectangleOfFloat_emplace_back(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_RectangleOfFloat_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_RectangleOfFloat_getSize(ptr).ToInt32();
            }

            public override Rectangle<float>[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new Rectangle<float>[0];

                var dst = new NativeMethods.NativeRectangleOfFloat[size];
                var elementPtr = this.GetElementPtr(ptr);
                InteropHelper.Copy(elementPtr, dst, dst.Length);
                return dst.Select(r => new Rectangle<float>(r.x, r.y, r.width, r.height)).ToArray();
            }

            #endregion

        }

        private sealed class StdVectorArrayOfFloatImp : StdVectorImp<Array<float>>
        {

            #region Constructors

            internal StdVectorArrayOfFloatImp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_vector_op_ArrayOfFloat_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_op_ArrayOfFloat_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<Array<float>> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.Select(d => d.NativePtr).ToArray();
                return NativeMethods.std_vector_op_ArrayOfFloat_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                if (this.IsEnabledDispose)
                    NativeMethods.std_vector_op_ArrayOfFloat_delete(ptr);
            }

            public override Array<float> At(IntPtr ptr, int index)
            {
                var ret = NativeMethods.std_vector_op_ArrayOfFloat_at(ptr, index);
                return new Array<float>(ret, false);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.std_vector_op_ArrayOfFloat_empty(ptr);
            }

            public override void EmplaceBack(IntPtr ptr)
            {
                NativeMethods.std_vector_op_ArrayOfFloat_emplace_back(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_op_ArrayOfFloat_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_op_ArrayOfFloat_getSize(ptr).ToInt32();
            }

            public override Array<float>[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new Array<float>[0];

                var dst = new IntPtr[size];
                NativeMethods.std_vector_op_ArrayOfFloat_copy(ptr, dst);
                return dst.Select(p => new Array<float>(p, this.IsEnabledDispose)).ToArray();
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
                return NativeMethods.std_vector_Datum_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_Datum_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<Datum> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.Select(d => d.NativePtr).ToArray();
                return NativeMethods.std_vector_Datum_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                if (this.IsEnabledDispose)
                    NativeMethods.std_vector_Datum_delete(ptr);
            }

            public override Datum At(IntPtr ptr, int index)
            {
                var ret = NativeMethods.std_vector_Datum_at(ptr, index);
                return new Datum(ret, false);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.std_vector_Datum_empty(ptr);
            }

            public override void EmplaceBack(IntPtr ptr)
            {
                NativeMethods.std_vector_Datum_emplace_back(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_Datum_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_Datum_getSize(ptr).ToInt32();
            }

            public override Datum[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new Datum[0];

                var dst = new IntPtr[size];
                NativeMethods.std_vector_Datum_copy(ptr, dst);
                return dst.Select(p => new Datum(p, this.IsEnabledDispose)).ToArray();
            }

            #endregion

        }

        private sealed class StdVectorCustomDatumImp : StdVectorImp<CustomDatum>
        {

            #region Constructors

            internal StdVectorCustomDatumImp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_vector_CustomDatum_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_CustomDatum_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<CustomDatum> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.Select(d => d.NativePtr).ToArray();
                return NativeMethods.std_vector_CustomDatum_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                if (this.IsEnabledDispose)
                    NativeMethods.std_vector_CustomDatum_delete(ptr);
            }

            public override CustomDatum At(IntPtr ptr, int index)
            {
                var ret = NativeMethods.std_vector_CustomDatum_at(ptr, index);
                return new CustomDatum(ret, false);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.std_vector_CustomDatum_empty(ptr);
            }

            public override void EmplaceBack(IntPtr ptr)
            {
                NativeMethods.std_vector_CustomDatum_emplace_back(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_CustomDatum_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_CustomDatum_getSize(ptr).ToInt32();
            }

            public override CustomDatum[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new CustomDatum[0];

                var dst = new IntPtr[size];
                NativeMethods.std_vector_CustomDatum_copy(ptr, dst);
                return dst.Select(p => new CustomDatum(p, this.IsEnabledDispose)).ToArray();
            }

            #endregion

        }
        
        private sealed class StdVectorStdSharedPtrOfDatumImp : StdVectorImp<StdSharedPtr<Datum>>
        {

            #region Constructors

            internal StdVectorStdSharedPtrOfDatumImp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_vector_StdSharedPtrOfDatum_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_StdSharedPtrOfDatum_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<StdSharedPtr<Datum>> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.Select(d => d.NativePtr).ToArray();
                return NativeMethods.std_vector_StdSharedPtrOfDatum_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                if (this.IsEnabledDispose)
                    NativeMethods.std_vector_StdSharedPtrOfDatum_delete(ptr);
            }

            public override StdSharedPtr<Datum> At(IntPtr ptr, int index)
            {
                var ret = NativeMethods.std_vector_StdSharedPtrOfDatum_at(ptr, index);
                return new StdSharedPtr<Datum>(ret, false);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.std_vector_StdSharedPtrOfDatum_empty(ptr);
            }

            public override void EmplaceBack(IntPtr ptr)
            {
                NativeMethods.std_vector_StdSharedPtrOfDatum_emplace_back(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_StdSharedPtrOfDatum_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_StdSharedPtrOfDatum_getSize(ptr).ToInt32();
            }

            public override StdSharedPtr<Datum>[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new StdSharedPtr<Datum>[0];

                var dst = new IntPtr[size];
                NativeMethods.std_vector_StdSharedPtrOfDatum_copy(ptr, dst);
                return dst.Select(p => new StdSharedPtr<Datum>(p, this.IsEnabledDispose)).ToArray();
            }

            #endregion

        }

        private sealed class StdVectorStdSharedPtrOfCustomDatumImp : StdVectorImp<StdSharedPtr<CustomDatum>>
        {

            #region Constructors

            internal StdVectorStdSharedPtrOfCustomDatumImp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_vector_StdSharedPtrOfCustomDatum_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_StdSharedPtrOfCustomDatum_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<StdSharedPtr<CustomDatum>> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.Select(d => d.NativePtr).ToArray();
                return NativeMethods.std_vector_StdSharedPtrOfCustomDatum_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                if (this.IsEnabledDispose)
                    NativeMethods.std_vector_StdSharedPtrOfCustomDatum_delete(ptr);
            }

            public override StdSharedPtr<CustomDatum> At(IntPtr ptr, int index)
            {
                var ret = NativeMethods.std_vector_StdSharedPtrOfCustomDatum_at(ptr, index);
                return new StdSharedPtr<CustomDatum>(ret, false);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.std_vector_StdSharedPtrOfCustomDatum_empty(ptr);
            }

            public override void EmplaceBack(IntPtr ptr)
            {
                NativeMethods.std_vector_StdSharedPtrOfCustomDatum_emplace_back(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_StdSharedPtrOfCustomDatum_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_StdSharedPtrOfCustomDatum_getSize(ptr).ToInt32();
            }

            public override StdSharedPtr<CustomDatum>[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new StdSharedPtr<CustomDatum>[0];

                var dst = new IntPtr[size];
                NativeMethods.std_vector_StdSharedPtrOfCustomDatum_copy(ptr, dst);
                return dst.Select(p => new StdSharedPtr<CustomDatum>(p, this.IsEnabledDispose)).ToArray();
            }

            #endregion

        }

        private sealed class StdVectorHeatMapTypeImp : StdVectorImp<HeatMapType>
        {

            #region Constructors

            internal StdVectorHeatMapTypeImp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_vector_HeatMapType_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_HeatMapType_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<HeatMapType> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.ToArray();
                return NativeMethods.std_vector_HeatMapType_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.std_vector_HeatMapType_delete(ptr);
            }

            public override HeatMapType At(IntPtr ptr, int index)
            {
                return NativeMethods.std_vector_HeatMapType_at(ptr, index);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.std_vector_HeatMapType_empty(ptr);
            }

            public override void EmplaceBack(IntPtr ptr)
            {
                NativeMethods.std_vector_HeatMapType_emplace_back(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_HeatMapType_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_HeatMapType_getSize(ptr).ToInt32();
            }

            public override HeatMapType[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new HeatMapType[0];

                var dst = new HeatMapType[size];
                var elementPtr = this.GetElementPtr(ptr);
                InteropHelper.Copy(elementPtr, dst, dst.Length);
                return dst;
            }

            #endregion

        }

        private sealed class StdVectorOpenCVMatImp : StdVectorImp<Mat>
        {

            #region Constructors

            internal StdVectorOpenCVMatImp(bool isEnabledDispose) :
                base(isEnabledDispose)
            {
            }

            #endregion

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_vector_3rdparty_opencv_Mat_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_3rdparty_opencv_Mat_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<Mat> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.Select(d => d.NativePtr).ToArray();
                return NativeMethods.std_vector_3rdparty_opencv_Mat_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                if (this.IsEnabledDispose)
                    NativeMethods.std_vector_3rdparty_opencv_Mat_delete(ptr);
            }

            public override Mat At(IntPtr ptr, int index)
            {
                var ret = NativeMethods.std_vector_3rdparty_opencv_Mat_at(ptr, index);
                return new Mat(ret, false);
            }

            public override bool Empty(IntPtr ptr)
            {
                return NativeMethods.std_vector_3rdparty_opencv_Mat_empty(ptr);
            }

            public override void EmplaceBack(IntPtr ptr)
            {
                NativeMethods.std_vector_3rdparty_opencv_Mat_emplace_back(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_3rdparty_opencv_Mat_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_3rdparty_opencv_Mat_getSize(ptr).ToInt32();
            }

            public override Mat[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new Mat[0];

                var dst = new IntPtr[size];
                NativeMethods.std_vector_3rdparty_opencv_Mat_copy(ptr, dst);
                return dst.Select(p => new Mat(p, this.IsEnabledDispose)).ToArray();
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