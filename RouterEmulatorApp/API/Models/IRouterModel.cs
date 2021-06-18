using IPv6Library.Devices;

namespace RouterEmulatorApp.API.Models
{
    public interface IRouterModel
    {
        Router RouterToDisplay { get; }
        bool TryBuildRoutingTable(out string message);

        void AddNote(string subnet, string prefix, string gateway);

    }
}