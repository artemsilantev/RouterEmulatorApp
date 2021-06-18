using IPv6Library.Devices;

namespace RouterEmulatorApp.Models.Services
{
    public class RouterService : API.Services.IRouterService
    {
        private static RouterService _routerService;
        public static RouterService Instance => _routerService ?? (_routerService = new RouterService());
        
        public int GetFreePortIndex(Router router)
        {
            for (var i = 0; i < router.Cables.Length; i++)
            {
                if (router.Cables[i] == null)
                    return i;
            }
            return -1;
        }

        public Switch GetSwitchByIndex(Router router,int switchIndex)
        {
            Switch @switch = null;
            if (router.Cables[switchIndex].DeviceSecond is Switch)
            {
             @switch = router.Cables[switchIndex].DeviceSecond as Switch;   
            }
            return @switch;
        }

        public bool TryDeleteSwitch(Router router, int switchIndex)
        {
            if (!(router.Cables[switchIndex].DeviceSecond is Switch)) return false;
            router.Cables[switchIndex] = null;
            return true;

        }
    }
}