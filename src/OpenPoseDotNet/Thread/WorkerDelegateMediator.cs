using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal abstract class WorkerDelegateMediator : OpenPoseObject
    {

        #region Delegates

        protected delegate void InitializationOnThreadActionDelegate();

        protected delegate void ProcessActionDelegate(IntPtr datums);

        protected delegate IntPtr ProcessAction2Delegate();

        #endregion

        #region Fields

        protected readonly InitializationOnThreadActionDelegate InitializationOnThreadAction;

        protected readonly ProcessActionDelegate ProcessAction;

        protected readonly ProcessAction2Delegate ProcessAction2;

        protected readonly IntPtr InitializationOnThreadActionPointer;

        protected readonly IntPtr ProcessActionPointer;

        protected readonly IntPtr ProcessAction2Pointer;

        protected readonly OpenPose.DataType DataType;

        #endregion

        #region Constructors

        protected WorkerDelegateMediator(OpenPose.DataType dataType)
        {
            this.InitializationOnThreadAction = this.OnInitializationOnThread;
            this.InitializationOnThreadActionPointer = Marshal.GetFunctionPointerForDelegate(this.InitializationOnThreadAction);

            this.ProcessAction = this.OnWork;
            this.ProcessActionPointer = Marshal.GetFunctionPointerForDelegate(this.ProcessAction);

            this.ProcessAction2 = this.OnWork2;
            this.ProcessAction2Pointer = Marshal.GetFunctionPointerForDelegate(this.ProcessAction2);

            this.DataType = dataType;
        }

        #endregion

        #region Properties

        public Action InitializationOnThread
        {
            get;
            set;
        }

        public Action<IntPtr> Work
        {
            get;
            set;
        }

        public Func<IntPtr> Work2
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Setup()
        {
            this.NativePtr = this.CreateObject();
        }

        protected abstract IntPtr CreateObject();

        #region Helpers

        private void OnInitializationOnThread()
        {
            this.InitializationOnThread?.Invoke();
        }

        private void OnWork(IntPtr ptr)
        {
            this.Work?.Invoke(ptr);
        }

        private IntPtr OnWork2()
        {
            var ret = this.Work2?.Invoke();
            return ret ?? IntPtr.Zero;
        }

        #endregion

        #endregion

    }

}