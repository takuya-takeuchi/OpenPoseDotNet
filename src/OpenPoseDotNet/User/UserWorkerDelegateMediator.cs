using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed class UserWorkerDelegateMediator : OpenPoseObject
    {

        #region Delegates

        private delegate void InitializationOnThreadActionDelegate();

        private delegate void ProcessActionDelegate(IntPtr datums);

        #endregion

        #region Fields

        private readonly InitializationOnThreadActionDelegate _InitializationOnThreadAction;

        private readonly ProcessActionDelegate _ProcessAction;

        private readonly IntPtr _InitializationOnThreadActionPointer;

        private readonly IntPtr _ProcessActionPointer;

        private readonly OpenPose.DataType _DataType;

        #endregion

        #region Constructors

        public UserWorkerDelegateMediator(OpenPose.DataType dataType)
        {
            this._InitializationOnThreadAction = this.OnInitializationOnThread;
            this._InitializationOnThreadActionPointer = Marshal.GetFunctionPointerForDelegate(this._InitializationOnThreadAction);

            this._ProcessAction = this.OnWork;
            this._ProcessActionPointer = Marshal.GetFunctionPointerForDelegate(this._ProcessAction);

            this._DataType = dataType;
            this.NativePtr = OpenPose.Native.op_UserWorker_new(this._DataType,
                                                               this._InitializationOnThreadActionPointer,
                                                               this._ProcessActionPointer);
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

        #endregion

        #region Methods

        #region Helpers

        private void OnInitializationOnThread()
        {
            this.InitializationOnThread?.Invoke();
        }

        private void OnWork(IntPtr ptr)
        {
            this.Work?.Invoke(ptr);
        }

        #endregion

        #endregion

    }

}