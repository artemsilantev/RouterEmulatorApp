using System;
using IPv6Library.Devices;
using RouterEmulatorApp.API.Models.Commands;
using RouterEmulatorApp.API.Services;
using RouterEmulatorApp.Models.Services;

namespace RouterEmulatorApp.Models.Commands
{
    public class AddSwitchCommand : ICommand
    {
        private readonly Router _router;
        private readonly Switch _switchToAdd;
        private readonly IRouterService _routerService;
        
        public AddSwitchCommand(Router router, Switch switchToAdd)
        {
            _router = router;
            _switchToAdd = switchToAdd;
            _routerService = RouterService.Instance;
        }
        
        public void Execute()
        {
           var index = _routerService.GetFreePortIndex(_router);
           if (index == -1)
               throw new Exception("Аll ports are busy");
           _switchToAdd.Id = index;
           _router.Cables[index] = new CableRJ45(_router, _switchToAdd);
        }
    }
}