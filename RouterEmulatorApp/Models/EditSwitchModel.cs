using IPv6Library.Devices;
using RouterEmulatorApp.API.Models;
using RouterEmulatorApp.Models.Commands;

namespace RouterEmulatorApp.Models
{
    public class EditSwitchModel : IEditSwitchModel
    {
        public Switch Switch { get; private set; }


        public EditSwitchModel(Switch @switch)
        {
            Switch = @switch;
        }
        
        public bool TryEditSwitch(string[] SwitchInfo, out string message)
        {
            return CommandExecuter.Execute(new EditSwitchCommand(Switch,SwitchInfo), out message);
        }

        
    }
}