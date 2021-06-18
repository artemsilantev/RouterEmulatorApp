using IPv6Library.Core;
// ReSharper disable ConvertToAutoProperty

namespace IPv6Library.Devices
{
    public abstract class AbstractCable
    {
        private AbstractElectronicDevice _deviceFirst;
        private AbstractElectronicDevice _deviceSecond;

        public AbstractElectronicDevice DeviceFirst
        {
            get => _deviceFirst;
            set => _deviceFirst = value;
        }

        public AbstractElectronicDevice DeviceSecond
        {
            get => _deviceSecond;
            set => _deviceSecond = value;
        }

        protected AbstractCable(AbstractElectronicDevice deviceFirst, AbstractElectronicDevice deviceSecond)
        {
            _deviceFirst = deviceFirst;
            _deviceSecond = deviceSecond;
        }
    }
}