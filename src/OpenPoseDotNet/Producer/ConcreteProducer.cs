using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed class ConcreteProducer : Producer
    {

        #region Constructors

        public ConcreteProducer(IntPtr ptr, bool isEnabledDispose = true) :
            base(ptr, isEnabledDispose)
        {
        }

        #endregion

        public override bool IsOpened
        {
            get;
        }

        public override void Release()
        {
        }

    }

}