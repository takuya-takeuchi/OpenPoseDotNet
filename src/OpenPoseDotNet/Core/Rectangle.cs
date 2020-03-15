using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public struct Rectangle<T>
    {

        #region Fields

        private static readonly Dictionary<Type, ElementTypes> SupportTypes = new Dictionary<Type, ElementTypes>();

        private RectangleImp<T> _Imp;

        #endregion

        #region Constructors

        static Rectangle()
        {
            var types = new[]
            {
                new { Type = typeof(float),   ElementType = ElementTypes.Float }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        public Rectangle(T x, T y, T width, T height)
        {
            if (!SupportTypes.TryGetValue(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            this._Imp = CreateImp();
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        internal Rectangle(IntPtr ptr, bool isEnabledDispose = true)
        {
            if (!SupportTypes.TryGetValue(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            this._Imp = CreateImp();
            this.X = default(T);
            this.Y = default(T);
            this.Width = default(T);
            this.Height = default(T);
        }

        #endregion

        #region Properties

        public T Height
        {
            get;
            set;
        }

        public T Width
        {
            get;
            set;
        }

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

        private static RectangleImp<T> CreateImp()
        {
            if (SupportTypes.TryGetValue(typeof(T), out var type))
            {
                switch (type)
                {
                    case ElementTypes.Float:
                        return new RectangleFloatImp() as RectangleImp<T>;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        internal IOpenPoseObject ToNative()
        {
            if (this._Imp == null)
                this._Imp = CreateImp();
            return this._Imp.ToNative(this.X, this.Y, this.Width, this.Height);
        }

        #endregion

        #endregion

        private enum ElementTypes
        {

            Float

        }

        private abstract class RectangleImp<U>
        {

            #region Methods

            public abstract IOpenPoseObject ToNative(U x, U y, U width, U height);

            public abstract IOpenPoseObject ToNative(IntPtr ptr);

            #endregion

        }

        private sealed class RectangleFloatImp : RectangleImp<float>
        {

            #region Methods

            public override IOpenPoseObject ToNative(float x, float y, float width, float height)
            {
                return new NativeRectangle(x, y, width, height);
            }

            public override IOpenPoseObject ToNative(IntPtr ptr)
            {
                return new NativeRectangle(ptr);
            }

            #endregion

            private sealed class NativeRectangle : OpenPoseObject
            {

                #region Constructors

                public NativeRectangle(float x, float y, float width, float height)
                {
                    this.NativePtr = NativeMethods.op_core_rectangle_float_new(x, y, width, height);
                }

                public NativeRectangle(IntPtr ptr)
                {
                    this.NativePtr = ptr;
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

                    NativeMethods.op_core_rectangle_float_delete(this.NativePtr);
                }

                #endregion

                #endregion

            }

        }

    }

}
