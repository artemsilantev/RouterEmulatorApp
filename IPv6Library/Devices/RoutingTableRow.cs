using IPv6Library.Core;

namespace IPv6Library.Devices
{
    public class RoutingTableRow
    {
        private  string _address;
        private string _subnet;
        private int _prefix;

        public RoutingTableRow( string address,  string subnet, int prefix)
        {
            _address = address;
            _subnet = subnet;
            _prefix = prefix;
        }

        public  string Address
        {
            get => _address;
            set => _address = value;
        }

        public  string Subnet
        {
            get => _subnet;
            set => _subnet = value;
        }

        public int Prefix
        {
            get => _prefix;
            set => _prefix = value;
        }
    }
}