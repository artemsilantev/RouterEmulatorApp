using IPv6Library.Core;
using IPv6Library.Devices;
using RouterEmulatorApp.API.Models;
using RouterEmulatorApp.API.Views;
using RouterEmulatorApp.Models;
using RouterEmulatorApp.Views;

namespace RouterEmulatorApp.Presenters
{
    public class MainWindowPresenter
    {
        private readonly IMainModel _model;
        private readonly IMainWindow _window;
        private readonly App _app;

        public MainWindowPresenter(IMainModel model, IMainWindow window)
        {
            _app = App.Instance;
            _model = model;
            _window = window;
            _window.AddSwitchAction += AddSwitch;
            _window.DeleteSwitchAction += DeleteSwitch;
            _window.EditSwitchAction += EditSwitch;
            _window.DisplayRouterInfoAction += DisplayRouterInfo;
            _model.InitRoutersAndSwitches(4);
        }

        private void AddSwitch()
        {
            var @switch = new Switch(new AbstractCable[1], 0);
            if (!_model.TryAddSwitch(_window.SelectedRouterIndex, @switch, out var message))
            {
                _window.ShowErrorMessage("Warning", message);
                return;
            }
            
            _window.AddSwitch(@switch.Id.ToString(), @switch.Address.ToString(), 
                @switch.Prefix.ToString(), @switch.Subnet.ToString());
        }

        private void DeleteSwitch()
        {
            if (!_model.TryDeleteSwitch(_window.SelectedRouterIndex, _window.SelectedSwitchIndex, out var message))
            {
                _window.ShowErrorMessage("Warning", message);
                return;
            }
            _window.DeleteSwitch();
        }

        private void EditSwitch()
        {
            if (!_model.TryGetSwitch(_window.SelectedRouterIndex, _window.SelectedSwitchIndex, out string message))
            {
                _window.ShowErrorMessage("Warning", message);
                return;
            }

            var Device = _model.Device as Switch;
            var presenter = new EditSwitchPresenter(new EditSwitchModel(Device),
                new EditSwitchWindow());
            presenter.Start();
            if (!presenter.isSaveChange)
                return;
            var ipv6Converter = Ipv6Converter.Instance;
            _window.ChangeSwitchInfo(Device.Id.ToString(), ipv6Converter.ToShortAddress(Device.Address), 
                Device.Prefix.ToString(), ipv6Converter.ToShortAddress(Device.Subnet));
        }

        private void DisplayRouterInfo()
        {
            var presenter = new RouterWindowPresenter(new RouterModel(_model.Routers[_window.SelectedRouterIndex]),
                new RouterWindow());
            presenter.Start();
        }

        public void Start()
        {
            _window.Start();
        }
    }
}