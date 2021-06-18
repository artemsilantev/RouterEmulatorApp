using System;

namespace RouterEmulatorApp.API.Views
{
    public interface IEditSwitchWindow
    {
        string[] SwitchInfo { get; }
        void Start();
        
        void Stop();
        
        void ShowErrorMessage(string header, string message);
        void SetupWindow(string header, string address, string prefix, string subnet);

        event Action SaveChangesAction;
    }
}