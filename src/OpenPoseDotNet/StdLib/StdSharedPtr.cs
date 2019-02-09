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

        private static readonly Dictionary<Type, ElementSubTypes> SupportSubTypes = new Dictionary<Type, ElementSubTypes>();

        private readonly StdSharedPtrImp<T> _Imp;

        private readonly OpenPoseObject _Obj;

        #endregion

        #region Constructors

        static StdSharedPtr()
        {
            var types = new[]
            {
                new { Type = typeof(Datum),                                ElementType = ElementTypes.Datum },
                new { Type = typeof(CustomDatum),                          ElementType = ElementTypes.CustomDatum },
                new { Type = typeof(StdVector<Datum>),                     ElementType = ElementTypes.StdVectorOfDatum },
                new { Type = typeof(StdVector<CustomDatum>),               ElementType = ElementTypes.StdVectorOfCustomDatum },
                new { Type = typeof(StdVector<StdSharedPtr<Datum>>),       ElementType = ElementTypes.StdVectorOfStdSharedPtrOfDatum },
                new { Type = typeof(StdVector<StdSharedPtr<CustomDatum>>), ElementType = ElementTypes.StdVectorOfStdSharedPtrOfCustomDatum },
                new { Type = typeof(PoseExtractorCaffe),                   ElementType = ElementTypes.PoseExtractorCaffe },
                new { Type = typeof(Producer),                             ElementType = ElementTypes.Producer },
                new { Type = typeof(DatumProducer<Datum>),                 ElementType = ElementTypes.DatumProducerOfDatum },
                new { Type = typeof(WDatumProducer<Datum>),                ElementType = ElementTypes.WDatumProducerOfDatum },
                new { Type = typeof(Gui),                                  ElementType = ElementTypes.Gui },
                new { Type = typeof(WGui<Datum>),                          ElementType = ElementTypes.WGui },
                new { Type = typeof(UserWorker<Datum>),                    ElementType = ElementTypes.UserWorkerOfDefault },
                new { Type = typeof(UserWorker<CustomDatum>),              ElementType = ElementTypes.UserWorkerOfCustom },
                new { Type = typeof(UserWorkerConsumer<Datum>),            ElementType = ElementTypes.UserWorkerConsumerOfDefault },
                new { Type = typeof(UserWorkerConsumer<CustomDatum>),      ElementType = ElementTypes.UserWorkerConsumerOfCustom },
                new { Type = typeof(UserWorkerProducer<Datum>),            ElementType = ElementTypes.UserWorkerProducerOfDefault },
                new { Type = typeof(UserWorkerProducer<CustomDatum>),      ElementType = ElementTypes.UserWorkerProducerOfCustom }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);

            var subtypes = new[]
            {
                new { Type = typeof(UserWorker<Datum>),               ElementType = ElementSubTypes.UserWorkerOfDefault },
                new { Type = typeof(UserWorker<CustomDatum>),         ElementType = ElementSubTypes.UserWorkerOfCustom },
                new { Type = typeof(UserWorkerConsumer<Datum>),       ElementType = ElementSubTypes.UserWorkerConsumerOfDefault },
                new { Type = typeof(UserWorkerConsumer<CustomDatum>), ElementType = ElementSubTypes.UserWorkerConsumerOfCustom },
                new { Type = typeof(UserWorkerProducer<Datum>),       ElementType = ElementSubTypes.UserWorkerProducerOfDefault },
                new { Type = typeof(UserWorkerProducer<CustomDatum>), ElementType = ElementSubTypes.UserWorkerProducerOfCustom }
            };

            foreach (var type in subtypes)
                SupportSubTypes.Add(type.Type, type.ElementType);
        }
        
        //public StdSharedPtr()
        //{
        //    this._Imp = CreateImp();
        //    this.NativePtr = this._Imp.Create();
        //}

        public StdSharedPtr(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            obj.ThrowIfDisposed();

            this._Imp = CreateImp();
            this.NativePtr = this._Imp.Create(obj.NativePtr);
            this._Obj = obj;
            
            // set object will be destructed by native domain
            obj.IsEnableDispose = false;
        }

        internal StdSharedPtr(IntPtr sharedPtr, bool isEnabledDispose = true) :
            base(isEnabledDispose)
        {
            this._Imp = CreateImp();
            this.NativePtr = sharedPtr;
        }

        #endregion

        #region Methods

        public T Get()
        {
            this.ThrowIfDisposed();
            return this._Imp.Get(this.NativePtr);
        }

        public void Reset(T obj)
        {
            this.ThrowIfDisposed();
            obj.ThrowIfDisposed();

            // set object will be destructed by native domain
            obj.IsEnableDispose = false;

            this._Imp.Reset(this.NativePtr, obj);
        }

        public bool TryGet(out T data)
        {
            data = default(T);

            try
            {
                this.ThrowIfDisposed();
            }
            catch (ObjectDisposedException)
            {
                return false;
            }

            data = this._Imp.Get(this.NativePtr);
            return true;
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
            var t = typeof(T);
            if (SupportTypes.TryGetValue(t, out var type))
            {
                switch (type)
                {
                    case ElementTypes.Datum:
                        return new StdSharedPtrDatumImp() as StdSharedPtrImp<T>;
                    case ElementTypes.CustomDatum:
                        return new StdSharedPtrCustomDatumImp() as StdSharedPtrImp<T>;
                    case ElementTypes.StdVectorOfDatum:
                        return new StdSharedPtrStdVectorOfDatumImp() as StdSharedPtrImp<T>;
                    case ElementTypes.StdVectorOfCustomDatum:
                        return new StdSharedPtrStdVectorOfCustomDatumImp() as StdSharedPtrImp<T>;
                    case ElementTypes.StdVectorOfStdSharedPtrOfDatum:
                        return new StdSharedPtrStdVectorStdSharedPtrOfDatumImp() as StdSharedPtrImp<T>;
                    case ElementTypes.StdVectorOfStdSharedPtrOfCustomDatum:
                        return new StdSharedPtrStdVectorStdSharedPtrOfCustomDatumImp() as StdSharedPtrImp<T>;
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
                    case ElementTypes.UserWorkerOfDefault:
                        return new StdSharedPtrUserWorkerOfDefaultImp() as StdSharedPtrImp<T>;
                    case ElementTypes.UserWorkerOfCustom:
                        return new StdSharedPtrUserWorkerOfCustomImp() as StdSharedPtrImp<T>;
                    case ElementTypes.UserWorkerConsumerOfDefault:
                        return new StdSharedPtrUserWorkerConsumerOfDefaultImp() as StdSharedPtrImp<T>;
                    case ElementTypes.UserWorkerConsumerOfCustom:
                        return new StdSharedPtrUserWorkerConsumerOfCustomImp() as StdSharedPtrImp<T>;
                    case ElementTypes.UserWorkerProducerOfDefault:
                        return new StdSharedPtrUserWorkerProducerOfDefaultImp() as StdSharedPtrImp<T>;
                    case ElementTypes.UserWorkerProducerOfCustom:
                        return new StdSharedPtrUserWorkerProducerOfCustomImp() as StdSharedPtrImp<T>;
                }
            }
            else
            {
                foreach (var subType in SupportSubTypes)
                {
                    if (!subType.Key.IsSubclassOf(t))
                        continue;

                    switch (subType.Value)
                    {
                        case ElementSubTypes.UserWorkerOfDefault:
                            return new StdSharedPtrUserWorkerOfDefaultImp() as StdSharedPtrImp<T>;
                        case ElementSubTypes.UserWorkerOfCustom:
                            return new StdSharedPtrUserWorkerOfCustomImp() as StdSharedPtrImp<T>;
                        case ElementSubTypes.UserWorkerConsumerOfDefault:
                            return new StdSharedPtrUserWorkerConsumerOfDefaultImp() as StdSharedPtrImp<T>;
                        case ElementSubTypes.UserWorkerConsumerOfCustom:
                            return new StdSharedPtrUserWorkerConsumerOfCustomImp() as StdSharedPtrImp<T>;
                        case ElementSubTypes.UserWorkerProducerOfDefault:
                            return new StdSharedPtrUserWorkerProducerOfDefaultImp() as StdSharedPtrImp<T>;
                        case ElementSubTypes.UserWorkerProducerOfCustom:
                            return new StdSharedPtrUserWorkerProducerOfCustomImp() as StdSharedPtrImp<T>;
                    }
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        #endregion

        #endregion

        private enum ElementTypes
        {

            Datum,

            CustomDatum,

            StdVectorOfDatum,

            StdVectorOfCustomDatum,

            StdVectorOfStdSharedPtrOfDatum,

            StdVectorOfStdSharedPtrOfCustomDatum,

            PoseExtractorCaffe,

            Producer,

            DatumProducerOfDatum,

            WDatumProducerOfDatum,

            Gui,

            WGui,

            UserWorkerOfDefault,

            UserWorkerOfCustom,

            UserWorkerConsumerOfDefault,

            UserWorkerConsumerOfCustom,

            UserWorkerProducerOfDefault,

            UserWorkerProducerOfCustom

        }

        private enum ElementSubTypes
        {

            UserWorkerOfDefault,

            UserWorkerOfCustom,

            UserWorkerConsumerOfDefault,

            UserWorkerConsumerOfCustom,

            UserWorkerProducerOfDefault,

            UserWorkerProducerOfCustom

        }

        #region StdSharedPtrImp

        private abstract class StdSharedPtrImp<U>
        {

            #region Methods

            public abstract IntPtr Create();

            public abstract IntPtr Create(IntPtr ptr);

            public abstract void Delete(IntPtr ptr);

            public abstract U Get(IntPtr ptr);

            public abstract void Reset(IntPtr ptr, U obj);

            #endregion

        }

        private sealed class StdSharedPtrDatumImp : StdSharedPtrImp<Datum>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_Datum_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_Datum_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_Datum_delete(ptr);
            }

            public override Datum Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_Datum_get(ptr);
                return new Datum(p, false);
            }

            public override void Reset(IntPtr ptr, Datum obj)
            {
                NativeMethods.std_shared_ptr_Datum_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrCustomDatumImp : StdSharedPtrImp<CustomDatum>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_CustomDatum_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_CustomDatum_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_CustomDatum_delete(ptr);
            }

            public override CustomDatum Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_CustomDatum_get(ptr);
                return new CustomDatum(p, false);
            }

            public override void Reset(IntPtr ptr, CustomDatum obj)
            {
                NativeMethods.std_shared_ptr_CustomDatum_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrStdVectorOfDatumImp : StdSharedPtrImp<StdVector<Datum>>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_StdVectorOfDatum_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_StdVectorOfDatum_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_StdVectorOfDatum_delete(ptr);
            }

            public override StdVector<Datum> Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_StdVectorOfDatum_get(ptr);
                return new StdVector<Datum>(p, false);
            }

            public override void Reset(IntPtr ptr, StdVector<Datum> obj)
            {
                NativeMethods.std_shared_ptr_StdVectorOfDatum_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrStdVectorOfCustomDatumImp : StdSharedPtrImp<StdVector<CustomDatum>>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_StdVectorOfCustomDatum_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_StdVectorOfCustomDatum_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_StdVectorOfCustomDatum_delete(ptr);
            }

            public override StdVector<CustomDatum> Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_StdVectorOfCustomDatum_get(ptr);
                return new StdVector<CustomDatum>(p, false);
            }

            public override void Reset(IntPtr ptr, StdVector<CustomDatum> obj)
            {
                NativeMethods.std_shared_ptr_StdVectorOfCustomDatum_reset(ptr, obj.NativePtr);
            }

            #endregion

        }
        
        private sealed class StdSharedPtrStdVectorStdSharedPtrOfDatumImp : StdSharedPtrImp<StdVector<StdSharedPtr<Datum>>>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_StdVectorOfStdSharedPtrOfDatum_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_StdVectorOfStdSharedPtrOfDatum_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_StdVectorOfStdSharedPtrOfDatum_delete(ptr);
            }

            public override StdVector<StdSharedPtr<Datum>> Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_StdVectorOfStdSharedPtrOfDatum_get(ptr);
                return new StdVector<StdSharedPtr<Datum>>(p, false);
            }

            public override void Reset(IntPtr ptr, StdVector<StdSharedPtr<Datum>> obj)
            {
                NativeMethods.std_shared_ptr_StdVectorOfStdSharedPtrOfDatum_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrStdVectorStdSharedPtrOfCustomDatumImp : StdSharedPtrImp<StdVector<StdSharedPtr<CustomDatum>>>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_StdVectorOfStdSharedPtrOfCustomDatum_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_StdVectorOfStdSharedPtrOfCustomDatum_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_StdVectorOfStdSharedPtrOfCustomDatum_delete(ptr);
            }

            public override StdVector<StdSharedPtr<CustomDatum>> Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_StdVectorOfStdSharedPtrOfCustomDatum_get(ptr);
                return new StdVector<StdSharedPtr<CustomDatum>>(p, false);
            }

            public override void Reset(IntPtr ptr, StdVector<StdSharedPtr<CustomDatum>> obj)
            {
                NativeMethods.std_shared_ptr_StdVectorOfStdSharedPtrOfCustomDatum_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrPoseExtractorCaffeImp : StdSharedPtrImp<PoseExtractorCaffe>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_op_PoseExtractorCaffe_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_op_PoseExtractorCaffe_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_op_PoseExtractorCaffe_delete(ptr);
            }

            public override PoseExtractorCaffe Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_op_PoseExtractorCaffe_get(ptr);
                return new PoseExtractorCaffe(p, false);
            }

            public override void Reset(IntPtr ptr, PoseExtractorCaffe obj)
            {
                NativeMethods.std_shared_ptr_op_PoseExtractorCaffe_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrProducerImp : StdSharedPtrImp<Producer>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_op_Producer_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_op_Producer_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_op_Producer_delete(ptr);
            }

            public override Producer Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_op_Producer_get(ptr);
                return new ConcreteProducer(p, false);
            }

            public override void Reset(IntPtr ptr, Producer obj)
            {
                NativeMethods.std_shared_ptr_op_Producer_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrDatumProducerOfDatumImp : StdSharedPtrImp<DatumProducer<Datum>>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_op_DatumProducerOfDatum_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_op_DatumProducerOfDatum_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_op_DatumProducerOfDatum_delete(ptr);
            }

            public override DatumProducer<Datum> Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_op_DatumProducerOfDatum_get(ptr);
                return new DatumProducer<Datum>(p, false);
            }

            public override void Reset(IntPtr ptr, DatumProducer<Datum> obj)
            {
                NativeMethods.std_shared_ptr_op_DatumProducerOfDatum_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrWDatumProducerOfDatumImp : StdSharedPtrImp<WDatumProducer<Datum>>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_op_WDatumProducerOfDatum_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_op_WDatumProducerOfDatum_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_op_WDatumProducerOfDatum_delete(ptr);
            }

            public override WDatumProducer<Datum> Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_op_WDatumProducerOfDatum_get(ptr);
                return new WDatumProducer<Datum>(p, false);
            }

            public override void Reset(IntPtr ptr, WDatumProducer<Datum> obj)
            {
                NativeMethods.std_shared_ptr_op_WDatumProducerOfDatum_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrGuiImp : StdSharedPtrImp<Gui>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_op_Gui_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_op_Gui_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_op_Gui_delete(ptr);
            }

            public override Gui Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_op_Gui_get(ptr);
                return new Gui(p, false);
            }

            public override void Reset(IntPtr ptr, Gui obj)
            {
                NativeMethods.std_shared_ptr_op_Gui_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrWGuiImp : StdSharedPtrImp<WGui<Datum>>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_op_WGui_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_op_WGui_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_op_WGui_delete(ptr);
            }

            public override WGui<Datum> Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_op_WGui_get(ptr);
                return new WGui<Datum>(p, false);
            }

            public override void Reset(IntPtr ptr, WGui<Datum> obj)
            {
                NativeMethods.std_shared_ptr_op_WGui_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrUserWorkerOfDefaultImp : StdSharedPtrImp<UserWorker<Datum>>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_op_UserWorkerOfDefault_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_op_UserWorkerOfDefault_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_op_UserWorkerOfDefault_delete(ptr);
            }

            public override UserWorker<Datum> Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_op_UserWorkerOfDefault_get(ptr);
                return new UserWorker<Datum>(p, false);
            }

            public override void Reset(IntPtr ptr, UserWorker<Datum> obj)
            {
                NativeMethods.std_shared_ptr_op_UserWorkerOfDefault_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrUserWorkerOfCustomImp : StdSharedPtrImp<UserWorker<CustomDatum>>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_op_UserWorkerOfCustom_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_op_UserWorkerOfCustom_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_op_UserWorkerOfCustom_delete(ptr);
            }

            public override UserWorker<CustomDatum> Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_op_UserWorkerOfCustom_get(ptr);
                return new UserWorker<CustomDatum>(p, false);
            }

            public override void Reset(IntPtr ptr, UserWorker<CustomDatum> obj)
            {
                NativeMethods.std_shared_ptr_op_UserWorkerOfCustom_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrUserWorkerConsumerOfDefaultImp : StdSharedPtrImp<UserWorkerConsumer<Datum>>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_op_UserWorkerConsumerOfDefault_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_op_UserWorkerConsumerOfDefault_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_op_UserWorkerConsumerOfDefault_delete(ptr);
            }

            public override UserWorkerConsumer<Datum> Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_op_UserWorkerConsumerOfDefault_get(ptr);
                return new UserWorkerConsumer<Datum>(p, false);
            }

            public override void Reset(IntPtr ptr, UserWorkerConsumer<Datum> obj)
            {
                NativeMethods.std_shared_ptr_op_UserWorkerConsumerOfDefault_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrUserWorkerConsumerOfCustomImp : StdSharedPtrImp<UserWorkerConsumer<CustomDatum>>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_op_UserWorkerConsumerOfCustom_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_op_UserWorkerConsumerOfCustom_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_op_UserWorkerConsumerOfCustom_delete(ptr);
            }

            public override UserWorkerConsumer<CustomDatum> Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_op_UserWorkerConsumerOfCustom_get(ptr);
                return new UserWorkerConsumer<CustomDatum>(p, false);
            }

            public override void Reset(IntPtr ptr, UserWorkerConsumer<CustomDatum> obj)
            {
                NativeMethods.std_shared_ptr_op_UserWorkerConsumerOfCustom_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrUserWorkerProducerOfDefaultImp : StdSharedPtrImp<UserWorkerProducer<Datum>>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_op_UserWorkerProducerOfDefault_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_op_UserWorkerProducerOfDefault_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_op_UserWorkerProducerOfDefault_delete(ptr);
            }

            public override UserWorkerProducer<Datum> Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_op_UserWorkerProducerOfDefault_get(ptr);
                return new UserWorkerProducer<Datum>(p, false);
            }

            public override void Reset(IntPtr ptr, UserWorkerProducer<Datum> obj)
            {
                NativeMethods.std_shared_ptr_op_UserWorkerProducerOfDefault_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        private sealed class StdSharedPtrUserWorkerProducerOfCustomImp : StdSharedPtrImp<UserWorkerProducer<CustomDatum>>
        {

            #region Methods

            public override IntPtr Create()
            {
                return NativeMethods.std_shared_ptr_op_UserWorkerProducerOfCustom_new();
            }

            public override IntPtr Create(IntPtr ptr)
            {
                return NativeMethods.std_shared_ptr_op_UserWorkerProducerOfCustom_new2(ptr);
            }

            public override void Delete(IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                    NativeMethods.std_shared_ptr_op_UserWorkerProducerOfCustom_delete(ptr);
            }

            public override UserWorkerProducer<CustomDatum> Get(IntPtr ptr)
            {
                var p = NativeMethods.std_shared_ptr_op_UserWorkerProducerOfCustom_get(ptr);
                return new UserWorkerProducer<CustomDatum>(p, false);
            }

            public override void Reset(IntPtr ptr, UserWorkerProducer<CustomDatum> obj)
            {
                NativeMethods.std_shared_ptr_op_UserWorkerProducerOfCustom_reset(ptr, obj.NativePtr);
            }

            #endregion

        }

        #endregion

    }

}