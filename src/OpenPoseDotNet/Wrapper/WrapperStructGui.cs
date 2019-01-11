using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class WrapperStructGui : OpenPoseObject
    {

        #region Constructors

        public WrapperStructGui(DisplayMode displayMode = DisplayMode.NoDisplay,
                                bool guiVerbose = false,
                                bool fullScreen = false)
        {
            this.NativePtr = NativeMethods.op_wrapperStructGui_new(displayMode,
                                                                   guiVerbose,
                                                                   fullScreen);
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

            NativeMethods.op_wrapperStructGui_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}