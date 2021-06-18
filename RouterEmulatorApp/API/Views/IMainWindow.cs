using System;
using System.ComponentModel.Design;
using IPv6Library.Devices;

namespace RouterEmulatorApp.API.Views
{
    public interface IMainWindow
    {
        int SelectedRouterIndex { get; }
        int SelectedSwitchIndex { get;}
        void Start();
        void ShowErrorMessage(string header, string message);
        void ChangeSwitchInfo(string id, string address, string prefix, string subnet);
        
        void AddSwitch(string id, string address, string prefix, string subnet);
        void DeleteSwitch();
        
        event Action AddSwitchAction;
        event Action DeleteSwitchAction;
        event Action EditSwitchAction;
        event Action DisplayRouterInfoAction;
    }
}