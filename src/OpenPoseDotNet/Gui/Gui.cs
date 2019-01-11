using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class Gui : OpenPoseObject
    {

        #region Constructors

        public Gui(Point<int> outputSize,
                   bool fullScreen,
                   IntPtr isRunningSharedPtr)
        {
            using (var nativeOutputSize = outputSize.ToNative())
                this.NativePtr = NativeMethods.op_Gui_new(nativeOutputSize.NativePtr,
                                                          fullScreen,
                                                          isRunningSharedPtr,
                                                          IntPtr.Zero,
                                                          IntPtr.Zero,
                                                          IntPtr.Zero,
                                                          IntPtr.Zero,
                                                          IntPtr.Zero,
                                                          DisplayMode.Display2D);
        }

        internal Gui(IntPtr ptr, bool isEnabledDispose = true) :
                base(isEnabledDispose)
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

            NativeMethods.op_Gui_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}