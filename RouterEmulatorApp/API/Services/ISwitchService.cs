using IPv6Library.Devices;

namespace RouterEmulatorApp.API.Services
{
    public interface ISwitchService
    {
        bool TryChangeSwitchAddress(Switch @switch, string address, out string message);
        bool TryChangeSwitchPrefix(Switch @switch, string prefix, out string message);
        bool TryChangeSwitchSubnet(Switch @switch, out string message);
    }
}