using System.Collections.Generic;
using System.Linq;
using IPv6Library.Core;
using IPv6Library.Devices;
using RouterEmulatorApp.API.Models.Commands;
using RouterEmulatorApp.Models.Services;
// ReSharper disable LoopCanBeConvertedToQuery

namespace RouterEmulatorApp.Models.Commands
{
    public class BuildRoutingTableCommand : ICommand
    {
        private Router _router;
        private Ipv6Converter _ipv6Converter;
        private List<RoutingTableRow> _rows; 
        public BuildRoutingTableCommand(Router router)
        {
            _router = router;
            _ipv6Converter = Ipv6Converter.Instance;
        }

        public void Execute()
        {
            var switches = new List<Switch>();
            Router secondRouter = null;
            _rows = new List<RoutingTableRow>();
           
            foreach (var cables in _router.Cables.Where(cable=>cable!=null))
            {
                switch (cables.DeviceSecond)
                {
                    case Switch @switch:
                        switches.Add(@switch);
                        break;
                    case Router router:
                        secondRouter = router;
                        break;
                    default:
                        continue;
                }
            }

            foreach (var @switch in switches.Where(@switch => @switch.Subnet.Address != ""))
            {
                _rows.Add(new RoutingTableRow("On-Link", 
                   _ipv6Converter.ToShortAddress(@switch.Subnet) , @switch.Prefix));
            }
            AddToRow();
            
            if(secondRouter == null) return;
          
            switches.Clear();
            
            foreach (var cables in secondRouter.Cables.Where(cable=>cable!=null))
            {
                switch (cables.DeviceSecond)
                {
                    case Switch @switch:
                        switches.Add(@switch);
                        break;
                    default:
                        continue;
                }
            }
            
            if(switches.Count==0)
                return;
            
            foreach (var @switch in switches.Where(@switch => @switch.Subnet.Address!=""))
            {
                _rows.Add(new RoutingTableRow(_ipv6Converter.ToShortAddress(secondRouter.Address), 
                    _ipv6Converter.ToShortAddress(@switch.Subnet) , @switch.Prefix));
            }
            
            AddToRow();
        }

        private void AddToRow()
        {
            foreach (var row in _rows)
            {
                var isExists = false;
                foreach (var rowMain in _router.Rows)
                {
                    if (row.Address == rowMain.Address && row.Prefix == rowMain.Prefix)
                    {
                        isExists = true;
                        break;
                    }
                     
                }
                if (!isExists)
                {
                    _router.Rows.Add(row);
                }
            }
        }
    }
}