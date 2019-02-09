using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class StdTimePoint : OpenPoseObject
    {

        #region Constructors

        internal StdTimePoint(IntPtr ptr)
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
            if (this.IsDisposed)
                return;

            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            NativeMethods.std_chrono_time_point_delete(this.NativePtr);
            this.NativePtr = IntPtr.Zero;
        }

        #endregion

        #endregion

    }

}