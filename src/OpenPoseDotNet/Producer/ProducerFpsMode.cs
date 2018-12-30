// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public enum ProducerFpsMode : byte
    {

        /** The frames will be extracted at the original source fps (frames might be skipped or repeated). */
        OriginalFps,

        /** The frames will be extracted when the software retrieves them (frames will not be skipped or repeated). */
        RetrievalFps

    }

}
