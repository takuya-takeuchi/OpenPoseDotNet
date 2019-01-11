// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public static class ConfigureLog
    {

        #region Properties

        public static LogMode[] LogModes
        {
            get
            {
                var ret = NativeMethods.op_ConfigureLog_getLogModes();
                using (var vector = new StdVector<LogMode>(ret))
                    return vector.ToArray();
            }
            set
            {
                using (var vector = new StdVector<LogMode>(value ?? new LogMode[0]))
                    NativeMethods.op_ConfigureLog_setLogModes(vector.NativePtr);
            }
        }

        public static Priority PriorityThreshold
        {
            get => NativeMethods.op_ConfigureLog_getPriorityThreshold();
            set => NativeMethods.op_ConfigureLog_setPriorityThreshold(value);
        }

        #endregion

    }

}
