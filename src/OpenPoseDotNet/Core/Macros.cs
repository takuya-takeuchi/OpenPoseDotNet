// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static partial class OpenPose
    {

        public static string OpenPoseName()
        {
            var ptr = NativeMethods.op_core_macros_get_OPEN_POSE_NAME_STRING();
            return StringHelper.FromStdString(ptr, true);
        }

        public static string OpenPoseVersion()
        {
            var ptr = NativeMethods.op_core_macros_get_OPEN_POSE_VERSION_STRING();
            return StringHelper.FromStdString(ptr, true);
        }

        public static string OpenPoseNameAndVersion()
        {
            var ptr = NativeMethods.op_core_macros_get_OPEN_POSE_NAME_AND_VERSION();
            return StringHelper.FromStdString(ptr, true);
        }

    }

}