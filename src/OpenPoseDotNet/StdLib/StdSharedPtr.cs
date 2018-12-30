using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class StdSharedPtr<T> : OpenPoseObject
        where T : OpenPoseObject
    {

        #region Fields

        private static readonly Dictionary<Type, ElementTypes> SupportTypes = new Dictionary<Type, ElementTypes>();

        private readonly StdSharedPtrImp<T> _Imp;

        private readonly T _Obj;

        #endregion

        #region Constructors

        static StdSharedPtr()
        {
            var types = new[]
            {
                new { Type = typeof(PoseExtractorCaffe), ElementType = ElementTypes.PoseExtractorCaffe }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        public StdSharedPtr(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            obj.ThrowIfDisposed();

            this._Imp = CreateImp();
            this.NativePtr = this._Imp.Create(obj.NativePtr);
            this._Obj = obj;
        }

        #endregion

        #region Methods

        public T Get()
        {
            this.ThrowIfDisposed();
            return this._Imp.Get(this.NativePtr);
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

            // need not to delete directly
            //this._Obj?.Dispose();
            this._Imp?.Delete(this.NativePtr);
        }

        #endregion

        #region Helpers

        private static StdSharedPtrImp<T> CreateImp()
        {
            if (SupportTypes.TryGetValue(typeof(T), out var type))
            {
                switch (type)
                {
                    case ElementTypes.PoseExtractorCaffe:
                        return new StdSharedPtrPoseExtractorCaffeImp() as StdSharedPtrImp<T>;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        #endregion

        #endregion

        private enum ElementTypes
        {

            PoseExtractorCaffe

        }

        #region StdSharedPtrImp

        private abstract class StdSharedPtrImp<U>
        {

            #region Methods

            public abstract IntPtr Create(IntPtr ptr);

            public abstract void Delete(IntPtr ptr);

            public abstract U Get(IntPtr ptr);

            #endregion

        }

        private sealed class StdSharedPtrPoseExtractorCaffeImp : StdSharedPtrImp<PoseExtractorCaffe>
        {

            #region Methods

            public override IntPtr Create(IntPtr ptr)
            {
                return OpenPose.Native.std_shared_ptr_op_PoseExtractorCaffe_new(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    OpenPose.Native.std_shared_ptr_op_PoseExtractorCaffe_delete(ptr);
            }

            public override PoseExtractorCaffe Get(IntPtr ptr)
            {
                var p = OpenPose.Native.std_shared_ptr_op_PoseExtractorCaffe_get(ptr);
                return new PoseExtractorCaffe(p, false);
            }

            #endregion

        }

        #endregion

    }

}