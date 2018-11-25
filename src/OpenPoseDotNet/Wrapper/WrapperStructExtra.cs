using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class WrapperStructExtra : OpenPoseObject
    {

        #region Constructors

        public WrapperStructExtra(bool reconstruct3d = false,
                                  int minViews3d = -1,
                                  bool identification = false,
                                  int tracking = -1,
                                  int ikThreads = 0)
        {
            this.NativePtr = Native.op_wrapperStructExtra_new(reconstruct3d,
                                                              minViews3d,
                                                              identification,
                                                              tracking,
                                                              ikThreads);
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

            Native.op_wrapperStructExtra_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_wrapperStructExtra_new(bool reconstruct3d,
                                                                  int minViews3d,
                                                                  bool identification,
                                                                  int tracking,
                                                                  int ikThreads);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapperStructExtra_delete(IntPtr face);

        }

    }

}
