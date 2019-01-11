using System;

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
            this.NativePtr = NativeMethods.op_wrapperStructExtra_new(reconstruct3d,
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

            NativeMethods.op_wrapperStructExtra_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}