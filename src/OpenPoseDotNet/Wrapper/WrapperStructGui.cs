using System;
using System.Runtime.InteropServices;

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
            this.NativePtr = Native.op_wrapperStructGui_new(displayMode,
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

            Native.op_wrapperStructGui_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_wrapperStructGui_new(DisplayMode displayMode,
                                                                bool guiVerbose,
                                                                bool fullScreen);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapperStructGui_delete(IntPtr face);

        }

    }

}
