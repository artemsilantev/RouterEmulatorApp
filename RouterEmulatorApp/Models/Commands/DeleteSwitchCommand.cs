using System;
using IPv6Library.Devices;
using RouterEmulatorApp.API.Models.Commands;
using RouterEmulatorApp.API.Services;
using RouterEmulatorApp.Models.Services;

namespace RouterEmulatorApp.Models.Commands
{
    public class DeleteSwitchCommand : ICommand
    {
        private readonly Router _router;
        private readonly int _switchIndex;
        private readonly IRouterService _routerService;

        public DeleteSwitchCommand(Router router, int switchIndex)
        {
            _router = router;
            _switchIndex = switchIndex;
            _routerService = RouterService.Instance;
        }

        public void Execute()
        {
            if (!_routerService.TryDeleteSwitch(_router, _switchIndex))
                throw new Exception("Switch not found");
        }
    }
}