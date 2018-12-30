using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public struct Point<T>
    {

        #region Fields

        private static readonly Dictionary<Type, ElementTypes> SupportTypes = new Dictionary<Type, ElementTypes>();

        private PointImp<T> _Imp;

        #endregion

        #region Constructors

        static Point()
        {
            var types = new[]
            {
                new { Type = typeof(int),     ElementType = ElementTypes.Int32 },
                new { Type = typeof(float),   ElementType = ElementTypes.Float },
                new { Type = typeof(double),  ElementType = ElementTypes.Double }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        public Point(T x, T y)
        {
            if (!SupportTypes.TryGetValue(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            this._Imp = CreateImp();
            this.X = x;
            this.Y = y;
        }

        internal Point(IntPtr ptr, bool isEnabledDispose = true)
        {
            if (!SupportTypes.TryGetValue(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            this._Imp = CreateImp();
            this.X = default(T);
            this.Y = default(T);
        }

        #endregion

        #region Properties

        public T X
        {
            get;
            set;
        }

        public T Y
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Helpers

        private static PointImp<T> CreateImp()
        {
            if (SupportTypes.TryGetValue(typeof(T), out var type))
            {
                switch (type)
                {
                    case ElementTypes.Int32:
                        return new PointInt32Imp() as PointImp<T>;
                    case ElementTypes.Float:
                        return new PointFloatImp() as PointImp<T>;
                    case ElementTypes.Double:
                        return new PointDoubleImp() as PointImp<T>;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        internal IOpenPoseObject ToNative()
        {
            if (this._Imp == null)
                this._Imp = CreateImp();
            return this._Imp.ToNative(this.X, this.Y);
        }

        #endregion

        #endregion

        private enum ElementTypes
        {

            Int32,

            Float,

            Double

        }

        private abstract class PointImp<U>
        {

            #region Methods

            public abstract IOpenPoseObject ToNative(U x, U y);

            public abstract IOpenPoseObject ToNative(IntPtr ptr);

            #endregion

        }

        private sealed class PointInt32Imp : PointImp<int>
        {

            #region Methods

            public override IOpenPoseObject ToNative(int x, int y)
            {
                return new NativePoint(x, y);
            }

            public override IOpenPoseObject ToNative(IntPtr ptr)
            {
                return new NativePoint(ptr);
            }

            #endregion

            private sealed class NativePoint : OpenPoseObject
            {

                #region Constructors

                public NativePoint(int x, int y)
                {
                    this.NativePtr = OpenPose.Native.op_core_point_int_new(x, y);
                }

                public NativePoint(IntPtr ptr)
                {
                    this.NativePtr = ptr;
                }

                #endregion

                #region Methods

                #region Overrids

                /// <summary>
                /// Releases all unmanaged resources.
                /// </summary>
                protected override void DisposeUnmanaged()
                {
                    base.DisposeUnmanaged();

                    if (this.NativePtr == IntPtr.Zero)
                        return;

                    OpenPose.Native.op_core_point_int_delete(this.NativePtr);
                }

                #endregion

                #endregion

            }

        }

        private sealed class PointFloatImp : PointImp<float>
        {

            #region Methods

            public override IOpenPoseObject ToNative(float x, float y)
            {
                return new NativePoint(x, y);
            }

            public override IOpenPoseObject ToNative(IntPtr ptr)
            {
                return new NativePoint(ptr);
            }

            #endregion

            private sealed class NativePoint : OpenPoseObject
            {

                #region Constructors

                public NativePoint(float x, float y)
                {
                    this.NativePtr = OpenPose.Native.op_core_point_float_new(x, y);
                }

                public NativePoint(IntPtr ptr)
                {
                    this.NativePtr = ptr;
                }

                #endregion

                #region Methods

                #region Overrids

                /// <summary>
                /// Releases all unmanaged resources.
                /// </summary>
                protected override void DisposeUnmanaged()
                {
                    base.DisposeUnmanaged();

                    if (this.NativePtr == IntPtr.Zero)
                        return;

                    OpenPose.Native.op_core_point_float_delete(this.NativePtr);
                }

                #endregion

                #endregion

            }

        }

        private sealed class PointDoubleImp : PointImp<double>
        {

            #region Methods

            public override IOpenPoseObject ToNative(double x, double y)
            {
                return new NativePoint(x, y);
            }

            public override IOpenPoseObject ToNative(IntPtr ptr)
            {
                return new NativePoint(ptr);
            }

            #endregion

            private sealed class NativePoint : OpenPoseObject
            {

                #region Constructors

                public NativePoint(double x, double y)
                {
                    this.NativePtr = OpenPose.Native.op_core_point_double_new(x, y);
                }

                public NativePoint(IntPtr ptr)
                {
                    this.NativePtr = ptr;
                }

                #endregion

                #region Methods

                #region Overrids

                /// <summary>
                /// Releases all unmanaged resources.
                /// </summary>
                protected override void DisposeUnmanaged()
                {
                    base.DisposeUnmanaged();

                    if (this.NativePtr == IntPtr.Zero)
                        return;

                    OpenPose.Native.op_core_point_double_delete(this.NativePtr);
                }

                #endregion

                #endregion

            }

        }

    }

}
