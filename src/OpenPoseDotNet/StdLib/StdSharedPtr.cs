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

        private readonly OpenPoseObject _Obj;

        #endregion

        #region Constructors

        static StdSharedPtr()
        {
            var types = new[]
            {
                new { Type = typeof(PoseExtractorCaffe),    ElementType = ElementTypes.PoseExtractorCaffe },
                new { Type = typeof(Producer),              ElementType = ElementTypes.Producer },
                new { Type = typeof(DatumProducer<Datum>),  ElementType = ElementTypes.DatumProducerOfDatum },
                new { Type = typeof(WDatumProducer<Datum>), ElementType = ElementTypes.WDatumProducerOfDatum },
                new { Type = typeof(Gui),                   ElementType = ElementTypes.Gui },
                new { Type = typeof(WGui<Datum>),           ElementType = ElementTypes.WGui },
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
            obj.IsEnableDispose = false;
        }

        internal StdSharedPtr(IntPtr ptr)
        {
            this._Imp = CreateImp();
            this.NativePtr = ptr;
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
                    case ElementTypes.Producer:
                        return new StdSharedPtrProducerImp() as StdSharedPtrImp<T>;
                    case ElementTypes.DatumProducerOfDatum:
                        return new StdSharedPtrDatumProducerOfDatumImp() as StdSharedPtrImp<T>;
                    case ElementTypes.WDatumProducerOfDatum:
                        return new StdSharedPtrWDatumProducerOfDatumImp() as StdSharedPtrImp<T>;
                    case ElementTypes.Gui:
                        return new StdSharedPtrGuiImp() as StdSharedPtrImp<T>;
                    case ElementTypes.WGui:
                        return new StdSharedPtrWGuiImp() as StdSharedPtrImp<T>;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        #endregion

        #endregion

        private enum ElementTypes
        {

            PoseExtractorCaffe,

            Producer,

            DatumProducerOfDatum,

            WDatumProducerOfDatum,

            Gui,

            WGui

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
        
        private sealed class StdSharedPtrProducerImp : StdSharedPtrImp<Producer>
        {

            #region Methods

            public override IntPtr Create(IntPtr ptr)
            {
                return OpenPose.Native.std_shared_ptr_op_Producer_new(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    OpenPose.Native.std_shared_ptr_op_Producer_delete(ptr);
            }

            public override Producer Get(IntPtr ptr)
            {
                var p = OpenPose.Native.std_shared_ptr_op_Producer_get(ptr);
                return new ConcreteProducer(p, false);
            }

            #endregion

        }
        
        private sealed class StdSharedPtrDatumProducerOfDatumImp : StdSharedPtrImp<DatumProducer<Datum>>
        {

            #region Methods

            public override IntPtr Create(IntPtr ptr)
            {
                return OpenPose.Native.std_shared_ptr_op_DatumProducerOfDatum_new(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    OpenPose.Native.std_shared_ptr_op_DatumProducerOfDatum_delete(ptr);
            }

            public override DatumProducer<Datum> Get(IntPtr ptr)
            {
                var p = OpenPose.Native.std_shared_ptr_op_DatumProducerOfDatum_get(ptr);
                return new DatumProducer<Datum>(p, false);
            }

            #endregion

        }
        
        private sealed class StdSharedPtrWDatumProducerOfDatumImp : StdSharedPtrImp<WDatumProducer<Datum>>
        {

            #region Methods

            public override IntPtr Create(IntPtr ptr)
            {
                return OpenPose.Native.std_shared_ptr_op_WDatumProducerOfDatum_new(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    OpenPose.Native.std_shared_ptr_op_WDatumProducerOfDatum_delete(ptr);
            }

            public override WDatumProducer<Datum> Get(IntPtr ptr)
            {
                var p = OpenPose.Native.std_shared_ptr_op_WDatumProducerOfDatum_get(ptr);
                return new WDatumProducer<Datum>(p, false);
            }

            #endregion

        }

        private sealed class StdSharedPtrGuiImp : StdSharedPtrImp<Gui>
        {

            #region Methods

            public override IntPtr Create(IntPtr ptr)
            {
                return OpenPose.Native.std_shared_ptr_op_Gui_new(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    OpenPose.Native.std_shared_ptr_op_Gui_delete(ptr);
            }

            public override Gui Get(IntPtr ptr)
            {
                var p = OpenPose.Native.std_shared_ptr_op_Gui_get(ptr);
                return new Gui(p, false);
            }

            #endregion

        }

        private sealed class StdSharedPtrWGuiImp : StdSharedPtrImp<WGui<Datum>>
        {

            #region Methods

            public override IntPtr Create(IntPtr ptr)
            {
                return OpenPose.Native.std_shared_ptr_op_WGui_new(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    OpenPose.Native.std_shared_ptr_op_WGui_delete(ptr);
            }

            public override WGui<Datum> Get(IntPtr ptr)
            {
                var p = OpenPose.Native.std_shared_ptr_op_WGui_get(ptr);
                return new WGui<Datum>(p, false);
            }

            #endregion

        }

        #endregion

    }

}