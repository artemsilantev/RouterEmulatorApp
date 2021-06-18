using IPv6Library.Devices;
using RouterEmulatorApp.API.Models;
using RouterEmulatorApp.Models.Commands;

namespace RouterEmulatorApp.Models
{
    public class RouterModel : IRouterModel
    {
        private Router _router;

        public RouterModel(Router router)
        {
            _router = router;
        }

        public Router RouterToDisplay { get=>_router; }

        public bool TryBuildRoutingTable(out string message)
        {
           return CommandExecuter.Execute(new BuildRoutingTableCommand(_router), out  message);
        }

        public void AddNote(string subnet, string prefix, string gateway)
        {
            _router.Rows.Add(new RoutingTableRow(gateway,subnet,int.Parse(prefix)));
        }
    }
}