using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class WrapperStructHand : OpenPoseObject
    {

        #region Fields

        public static readonly Point<int> DefaultNetInputSize = new Point<int>(656, 368);

        #endregion

        #region Constructors

        public WrapperStructHand(bool enable = false,
                                 Point<int> netInputSize = default (Point<int>),
                                 int scalesNumber = 1,
                                 float scaleRange = 0.4f,
                                 bool tracking = false,
                                 RenderMode renderMode = RenderMode.Gpu,
                                 float alphaKeyPoint = OpenPose.HandDefaultAlphaKeyPoint,
                                 float alphaHeatMap = OpenPose.HandDefaultAlphaHeatMap,
                                 float renderThreshold = 0.2f)
        {
            using (var native = netInputSize.ToNative())
                this.NativePtr = Native.op_wrapperStructHand_new(enable,
                                                             native.NativePtr,
                                                             scalesNumber,
                                                             scaleRange,
                                                             tracking,
                                                             renderMode,
                                                             alphaKeyPoint,
                                                             alphaHeatMap,
                                                             renderThreshold);
        }

        #endregion

        #region Properties

        public bool Enable
        {
            get
            {
                this.ThrowIfDisposed();
                return Native.op_wrapperStructHand_get_enable(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                Native.op_wrapperStructHand_set_enable(this.NativePtr, value);
            }
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

            Native.op_wrapperStructHand_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_wrapperStructHand_new(bool enable,
                                                                 IntPtr netInputSize,
                                                                 int scalesNumber,
                                                                 float scaleRange,
                                                                 bool tracking,
                                                                 RenderMode renderMode,
                                                                 float alphaKeyPoint,
                                                                 float alphaHeatMap,
                                                                 float renderThreshold);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapperStructHand_delete(IntPtr hand);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_wrapperStructHand_get_enable(IntPtr hand);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapperStructHand_set_enable(IntPtr hand, bool enable);

        }

    }

}
