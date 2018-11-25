// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public enum ScaleMode : byte
    {

        InputResolution,

        NetOutputResolution,

        OutputResolution,

        ZeroToOne, // [0, 1]

        PlusMinusOne, // [-1, 1]

        UnsignedChar, // [0, 255]

        NoScale

    }

}