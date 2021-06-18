using System.Collections.Generic;
using IPv6Library.Core;
using IPv6Library.Devices;
using RouterEmulatorApp.Models.Commands;
using RouterEmulatorApp.Models.Services;
using RouterEmulatorApp.Views;

namespace RouterEmulatorApp.Models
{
    public class MainModel : API.Models.IMainModel
    {
        public Router[] Routers { get; private set; }
        public AbstractElectronicDevice Device { get; private set; }


        public MainModel()
        {
            
        }

        public void InitRoutersAndSwitches(int ports)
        {
            Routers = new Router[2];
            for (var i = 0; i < Routers.Length; i++)
                Routers[i] = new Router(new AbstractCable[ports], i, new List<RoutingTableRow>(), Ipv6Parser.Instance.Parse($"2001:0db8:85a3:0000:0000:8a2e:0370:000{i+1}"));
            Routers[0].Cables[0] = new CableRJ45(Routers[0], Routers[1]);
            Routers[0].Rows.Add(new RoutingTableRow(Ipv6Converter.Instance.ToShortAddress(Routers[1].Address), "::",0));
            Routers[1].Rows.Add(new RoutingTableRow(Ipv6Converter.Instance.ToShortAddress(Routers[0].Address), "::",0));
            Routers[1].Cables[0] = new CableRJ45(Routers[1], Routers[0]);

        }
        
        public bool TryAddSwitch(int indexOfRouter, Switch switchToAdd, out string message)
        {
            return CommandExecuter.Execute(new AddSwitchCommand(Routers[indexOfRouter], switchToAdd), out message);
        }

        public bool TryDeleteSwitch(int indexOfRouter, int indexOfSwitch, out string message)
        {
          return CommandExecuter.Execute(new DeleteSwitchCommand(Routers[indexOfRouter], indexOfSwitch), out message);
        }

        public bool TryGetSwitch(int indexOfRouter, int indexOfSwitch, out string message)
        {
            Device = Routers[indexOfRouter].Cables[indexOfSwitch].DeviceSecond;
            if (Device == null)
            {
                message = "Switch not found";
                return false;
            }
            message = null;
            return true;
        }
    }
}