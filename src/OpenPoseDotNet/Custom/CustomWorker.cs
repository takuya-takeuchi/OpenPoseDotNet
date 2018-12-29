using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class CustomWorker : OpenPoseObject
    {

        #region Constructors

        public CustomWorker(CustomProcessing customProcessing)
        {
            if (customProcessing == null)
                throw new ArgumentNullException(nameof(customProcessing));

            customProcessing.ThrowIfDisposed();

            this.NativePtr = Native.op_CustomWorker_new(customProcessing.NativePtr);
        }

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_CustomWorker_new(IntPtr custom_processing);

        }

    }

}