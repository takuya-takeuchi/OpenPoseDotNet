using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public abstract class CustomWorker : OpenPoseObject
    {

        #region Delegates

        private delegate void InitializationOnThreadAction();

        private delegate void ProcessAction(IntPtr datums);

        #endregion

        #region Fields

        private readonly InitializationOnThreadAction _InitializationOnThreadAction;

        private readonly ProcessAction _ProcessAction;

        private readonly IntPtr _InitializationOnThreadActionPointer;

        private readonly IntPtr _ProcessActionPointer;

        #endregion

        #region Constructors

        protected CustomWorker()
        {
            this._InitializationOnThreadAction = this.InitializationOnThread;
            this._InitializationOnThreadActionPointer = Marshal.GetFunctionPointerForDelegate(this._InitializationOnThreadAction);

            this._ProcessAction = this.Work;
            this._ProcessActionPointer = Marshal.GetFunctionPointerForDelegate(this._ProcessAction);

            this.NativePtr = Native.op_CustomWorker_new(this._InitializationOnThreadActionPointer, this._ProcessActionPointer);
        }

        #endregion

        #region Methods

        protected virtual void InitializationOnThread()
        {

        }

        protected virtual void Work(CustomDatum[] datums)
        {
        }

        #region Helpers

        private void Work(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                this.Work(null);
                return;
            }

            var content = OpenPose.Native.op_shared_ptr_TDatums_getter(ptr);
            if (content == IntPtr.Zero)
            {
                this.Work(null);
                return;
            }

            using (var vector = new StdVector<CustomDatum>(content, false))
                this.Work(vector.ToArray());
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_CustomWorker_new(IntPtr initializationOnThread_function, IntPtr process_function);

        }

    }

}