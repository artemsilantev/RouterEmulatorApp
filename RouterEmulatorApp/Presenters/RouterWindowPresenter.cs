using RouterEmulatorApp.API.Models;
using RouterEmulatorApp.API.Views;

namespace RouterEmulatorApp.Presenters
{
    public class RouterWindowPresenter
    {
        private IRouterModel _model;
        private IRouterWindow _window;

        public RouterWindowPresenter(IRouterModel model, IRouterWindow window)
        {
            _model = model;
            _window = window;
            _window.AddNoteAction += AddNote;
        }


        public void Start()
        {
            _window.SetupWindow(_model.RouterToDisplay.Address.ToString());
            InitializeData();
            _window.Start();

        }

        private void AddNote()
        {
            var info = _window.NoteInfo;
            _model.AddNote(info[0],info[1],info[2]);
            InitializeData();
            
        }
        private void InitializeData()
        {
            if (!_model.TryBuildRoutingTable(out var message))
            {
                _window.ShowErrorMessage("Warning", message);
                return;
            }

            foreach (var row in _model.RouterToDisplay.Rows)
            {
                _window.FillDataGrid(row.Subnet, row.Prefix.ToString(), row.Address);
            }
        }
        
    }
}