using IPv6Library.Devices;

namespace RouterEmulatorApp.API.Services
{
    public interface IRouterService
    {
         int GetFreePortIndex(Router router);
       
         Switch GetSwitchByIndex(Router router, int switchIndex);

         bool TryDeleteSwitch(Router router, int switchIndex);

    }
}