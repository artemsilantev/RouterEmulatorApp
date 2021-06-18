using System.Collections.Generic;
using IPv6Library.Core;

namespace IPv6Library.Devices
{
    public class Router : AbstractElectronicDevice
    {
        private List<RoutingTableRow> _rows;

        private Ipv6 _address;
       
        public List<RoutingTableRow> Rows
        {
            get => _rows;
            set => _rows = value;
        }

        public Ipv6 Address
        {
            get => _address;
            set => _address = value;
        }

        public Router(AbstractCable[] cables, int id, List<RoutingTableRow> tableRows, Ipv6 address) : base(cables, id)
        {
            _rows = tableRows;
            _address = address;
        }

    
    }
}