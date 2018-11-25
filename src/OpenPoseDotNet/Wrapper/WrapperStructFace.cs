using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class WrapperStructFace : OpenPoseObject
    {
        #region Fields

        public static readonly Point<int> DefaultNetInputSize = new Point<int>(368, 368);

        #endregion

        #region Constructors

        public WrapperStructFace(bool enable = false,
                                 Point<int> netInputSize = default(Point<int>),
                                 RenderMode renderMode = RenderMode.Gpu,
                                 float alphaKeyPoint = OpenPose.FaceDefaultAlphaKeyPoint,
                                 float alphaHeatMap = OpenPose.FaceDefaultAlphaHeatMap,
                                 float renderThreshold = 0.4f)
        {
            using(var native = netInputSize.ToNative())
                this.NativePtr = Native.op_wrapperStructFace_new(enable,
                                                                 native.NativePtr,
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
                return Native.op_wrapperStructFace_get_enable(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                Native.op_wrapperStructFace_set_enable(this.NativePtr, value);
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

            Native.op_wrapperStructFace_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_wrapperStructFace_new(bool enable,
                                                                 IntPtr netInputSize,
                                                                 RenderMode renderMode,
                                                                 float alphaKeyPoint,
                                                                 float alphaHeatMap,
                                                                 float renderThreshold);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapperStructFace_delete(IntPtr face);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_wrapperStructFace_get_enable(IntPtr face);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapperStructFace_set_enable(IntPtr face, bool enable);

        }

    }

}
