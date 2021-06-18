// ReSharper disable ConvertToAutoProperty

using IPv6Library.Core;

namespace IPv6Library.Devices
{
    public class Switch : AbstractElectronicDevice
    {

        private Ipv6 _address;

        private int _prefix;
        
        private Ipv6 _subnet;
        

        public Ipv6 Address
        {
            get => _address;
            set => _address = value;
        }

        public Ipv6 Subnet
        {
            get => _subnet;
            set => _subnet = value;
        }

        public int Prefix
        {
            get => _prefix;
            set => _prefix = value;
        }

        public Switch(AbstractCable[] cables,  int id) : base(cables, id)
        {
            _address = new Ipv6();
            _prefix = 0;
            _subnet = new Ipv6();
        }
        
    }
}