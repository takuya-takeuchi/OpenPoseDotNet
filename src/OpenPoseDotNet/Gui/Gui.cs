using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
                this.NativePtr = Native.op_Gui_new(nativeOutputSize.NativePtr,
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

            Native.op_Gui_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_Gui_new(IntPtr outputSize,
                                                   bool fullScreen,
                                                   IntPtr isRunningSharedPtr,
                                                   IntPtr videoSeekSharedPtr,
                                                   IntPtr poseExtractorNets,
                                                   IntPtr faceExtractorNets,
                                                   IntPtr handExtractorNets,
                                                   IntPtr renderers,
                                                   DisplayMode displayMode);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_Gui_delete(IntPtr gui);

        }

    }

}