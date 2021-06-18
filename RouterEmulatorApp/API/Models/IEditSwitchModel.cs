using IPv6Library.Devices;

namespace RouterEmulatorApp.API.Models
{
    public interface IEditSwitchModel
    {
        Switch @Switch { get; }
        
        bool TryEditSwitch(string[] SwitchInfo, out string message);
    }
}