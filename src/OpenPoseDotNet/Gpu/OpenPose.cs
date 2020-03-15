// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        #region Methods

        public static int GetGpuNumber()
        {
            return NativeMethods.op_getGpuNumber();
        }

        public static GpuMode GetGpuMode()
        {
            return NativeMethods.op_getGpuMode();
        }

        #endregion

    }

}
