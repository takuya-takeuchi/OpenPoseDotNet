// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static class ConfigureError
    {

        #region Properties

        public static ErrorMode[] ErrorModes
        {
            get
            {
                var ret = NativeMethods.op_ConfigureError_getErrorModes();
                using (var vector = new StdVector<ErrorMode>(ret))
                    return vector.ToArray();
            }
            set
            {
                using (var vector = new StdVector<ErrorMode>(value ?? new ErrorMode[0]))
                    NativeMethods.op_ConfigureError_setErrorModes(vector.NativePtr);
            }
        }

        #endregion

    }

}
