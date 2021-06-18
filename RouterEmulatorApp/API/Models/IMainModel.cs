using IPv6Library.Devices;

namespace RouterEmulatorApp.API.Models
{
    public interface IMainModel
    {
        Router[] Routers { get; }

        AbstractElectronicDevice Device { get; }

        void InitRoutersAndSwitches(int ports);
        
        bool TryAddSwitch(int indexOfRouter, Switch switchToAdd, out string message);
        bool TryDeleteSwitch(int indexOfRouter, int indexOfSwitch, out string message);
        bool TryGetSwitch(int indexOfRouter, int indexOfSwitch, out string message);

    }
}