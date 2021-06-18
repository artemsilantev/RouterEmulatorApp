using IPv6Library.Core;
using IPv6Library.Devices;
using RouterEmulatorApp.API.Services;

namespace RouterEmulatorApp.Models.Services
{
    public class SwitchService : ISwitchService
    {
        private static SwitchService _switchService;
        public static SwitchService Instance => _switchService ?? (_switchService = new SwitchService());
        
        
        public bool TryChangeSwitchAddress(Switch @switch, string address, out string message)
        {
            if (!Ipv6Parser.Instance.TryParse(address,out var ipv6,address.Length != 39))
            {
                message = "Problem with address format";
                return false;
            }
            @switch.Address = ipv6;
            message = null;
            return true;
        }
        
        public bool TryChangeSwitchPrefix(Switch @switch, string prefix, out string message)
        {
            if (!int.TryParse(prefix,out var prefixNumber)||!(prefixNumber>0&&prefixNumber<=128))
            {
                message = "Problem with prefix format";
                return false;
            }
            @switch.Prefix= prefixNumber;
            message = null;
            return true;
        }
        
        public bool TryChangeSwitchSubnet(Switch @switch, out string message)
        {
            if (!Ipv6Parser.Instance.TryParse(@switch.Address,@switch.Prefix, out Ipv6 ipv6Out))
            {
                message = "Problem with subnet";
                return false;
            }

            @switch.Subnet = ipv6Out;
            message = null;
            return true;
        }
    }
}