using System;

namespace OpenPoseDotNet
{

    /// <summary>
    /// Defines methods and properties to represent the openpose objects.
    /// </summary>
    public interface IOpenPoseObject : IDisposable
    {

        #region Properties

        /// <summary>
        /// Gets a pointer of native structure.
        /// </summary>>
        IntPtr NativePtr
        {
            get;
        }

        #endregion

        #region Methods

        /// <summary>
        /// If this object is disposed, then <see cref="System.ObjectDisposedException"/> is thrown.
        /// </summary>
        void ThrowIfDisposed();

        #endregion

    }

}