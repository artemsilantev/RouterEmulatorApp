using IPv6Library.Devices;
using RouterEmulatorApp.API.Models;
using RouterEmulatorApp.API.Views;

namespace RouterEmulatorApp.Presenters
{
    public class EditSwitchPresenter
    {
        private readonly IEditSwitchModel _model;
        private readonly IEditSwitchWindow _window;
        public bool isSaveChange { get;  private set;}


        public EditSwitchPresenter(IEditSwitchModel model, IEditSwitchWindow window)
        {
            _model = model;
            _window = window;
            _window.SaveChangesAction += SaveChanges;
            _window.SetupWindow($"Port - {_model.Switch.Id}",_model.Switch.Address.ToString(), 
                _model.Switch.Prefix.ToString(), _model.Switch.Subnet.ToString());

        }

        private void SaveChanges()
        {
            if (!_model.TryEditSwitch(_window.SwitchInfo, out var message))
            {
                _window.ShowErrorMessage("Warning", message);
                isSaveChange = false;
                return;
            }
            isSaveChange = true;
            _window.Stop();
        }

        public void Start()
        {
            isSaveChange = false;
            _window.Start();
        }
    }
}