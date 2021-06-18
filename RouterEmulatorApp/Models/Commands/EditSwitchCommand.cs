using System;
using IPv6Library.Devices;
using RouterEmulatorApp.API.Models.Commands;
using RouterEmulatorApp.API.Services;
using RouterEmulatorApp.Models.Services;

namespace RouterEmulatorApp.Models.Commands
{
    public class EditSwitchCommand : ICommand
    {
        private readonly ISwitchService _switchService;
        private readonly Switch _switch;
        private readonly string[] _switchInfo;

        public EditSwitchCommand(Switch @switch, string[] switchInfo)
        {
            _switch = @switch;
            _switchInfo = switchInfo;
            _switchService = SwitchService.Instance;
        }

        public void Execute()
        {
            if (!_switchService.TryChangeSwitchAddress(_switch, _switchInfo[0], out var message))
                throw new FormatException(message);
            if (!_switchService.TryChangeSwitchPrefix(_switch, _switchInfo[1], out message))
                throw new FormatException(message);
            if (!_switchService.TryChangeSwitchSubnet(_switch, out message))
                throw new FormatException(message);

        }
    }
}