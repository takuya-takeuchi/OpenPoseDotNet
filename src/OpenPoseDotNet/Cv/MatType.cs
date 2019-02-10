using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{
    
    public struct MatType
    {

        #region Fields

        public const int CV_8U = 0;

        public const int CV_8S = 1;

        public const int CV_16U = 2;

        public const int CV_16S = 3;

        public const int CV_32S = 4;

        public const int CV_32F = 5;

        public const int CV_64F = 6;

        public const int CV_USRTYPE1 = 7;

        private static readonly int CV_CN_MAX = 512;

        private static readonly int CV_CN_SHIFT = 3;

        private static readonly int CV_DEPTH_MAX = (1 << CV_CN_SHIFT);

        public static MatType CV_8UC1 = CV_8UC(1);

        public static MatType CV_8UC2 = CV_8UC(2);

        public static MatType CV_8UC3 = CV_8UC(3);

        public static MatType CV_8UC4 = CV_8UC(4);

        public static MatType CV_8SC1 = CV_8SC(1);

        public static MatType CV_8SC2 = CV_8SC(2);

        public static MatType CV_8SC3 = CV_8SC(3);

        public static MatType CV_8SC4 = CV_8SC(4);

        public static MatType CV_16UC1 = CV_16UC(1);

        public static MatType CV_16UC2 = CV_16UC(2);

        public static MatType CV_16UC3 = CV_16UC(3);

        public static MatType CV_16UC4 = CV_16UC(4);

        public static MatType CV_16SC1 = CV_16SC(1);

        public static MatType CV_16SC2 = CV_16SC(2);

        public static MatType CV_16SC3 = CV_16SC(3);

        public static MatType CV_16SC4 = CV_16SC(4);

        public static MatType CV_32SC1 = CV_32SC(1);

        public static MatType CV_32SC2 = CV_32SC(2);

        public static MatType CV_32SC3 = CV_32SC(3);

        public static MatType CV_32SC4 = CV_32SC(4);

        public static MatType CV_32FC1 = CV_32FC(1);

        public static MatType CV_32FC2 = CV_32FC(2);

        public static MatType CV_32FC3 = CV_32FC(3);

        public static MatType CV_32FC4 = CV_32FC(4);

        public static MatType CV_64FC1 = CV_64FC(1);

        public static MatType CV_64FC2 = CV_64FC(2);

        public static MatType CV_64FC3 = CV_64FC(3);

        public static MatType CV_64FC4 = CV_64FC(4);

        #endregion

        #region Constructors

        internal MatType(int value)
        {
            this.Value = value;

        }

        #endregion

        #region Properties

        public int Value
        {
            get;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string s;
            var type = this.Value;
            var depth = Depth(type);
            switch (depth)
            {
                case CV_8U:
                    s = "CV_8U";
                    break;
                case CV_8S:
                    s = "CV_8S";
                    break;
                case CV_16U:
                    s = "CV_16U";
                    break;
                case CV_16S:
                    s = "CV_16S";
                    break;
                case CV_32S:
                    s = "CV_32S";
                    break;
                case CV_32F:
                    s = "CV_32F";
                    break;
                case CV_64F:
                    s = "CV_64F";
                    break;
                case CV_USRTYPE1:
                    s = "CV_USRTYPE1";
                    break;
                default:
                    throw new NotSupportedException($"Unsupported Type value: {type}");
            }

            var ch = Channels(type);
            return ch <= 4 ? $"{s}C{ch}" : $"{s}C({ch})";
        }

        #region Overrids

        public static implicit operator int(MatType self)
        {
            return self.Value;
        }

        public static implicit operator MatType(int value)
        {
            return new MatType(value);
        }

        #endregion

        #region Helpers

        private static MatType MakeType(int depth, int channels)
        {
            if (channels <= 0 || channels >= CV_CN_MAX)
                throw new NotSupportedException($"Channels count should be 1..{(CV_CN_MAX - 1)}");
            if (depth < 0 || depth >= CV_DEPTH_MAX)
                throw new NotSupportedException($"Data type depth should be 0..{(CV_DEPTH_MAX - 1)}");

            var value = (depth & (CV_DEPTH_MAX - 1)) + ((channels - 1) << CV_CN_SHIFT);
            return new MatType(value);
        }

        private static MatType CV_8UC(int ch)
        {
            return MakeType(CV_8U, ch);
        }

        private static MatType CV_8SC(int ch)
        {
            return MakeType(CV_8S, ch);
        }

        private static MatType CV_16UC(int ch)
        {
            return MakeType(CV_16U, ch);
        }

        private static MatType CV_16SC(int ch)
        {
            return MakeType(CV_16S, ch);
        }

        private static MatType CV_32SC(int ch)
        {
            return MakeType(CV_32S, ch);
        }

        private static MatType CV_32FC(int ch)
        {
            return MakeType(CV_32F, ch);
        }

        private static MatType CV_64FC(int ch)
        {
            return MakeType(CV_64F, ch);
        }

        internal static int Channels(int type)
        {
            return (type >> CV_CN_SHIFT) + 1;
        }

        internal static int Depth(int type)
        {
            return type & (CV_DEPTH_MAX - 1);
        }

        private static bool IsInteger(int type)
        {
            return Depth(type) < CV_32F;
        }

        #endregion

        #endregion

    }

}
