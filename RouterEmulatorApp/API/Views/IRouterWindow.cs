using System;

namespace RouterEmulatorApp.API.Views
{
    public interface IRouterWindow
    {
        
        string[] NoteInfo { get; }
        void Start();
        void Stop();

        void SetupWindow(string header);
        void ShowErrorMessage(string header, string message);

        void FillDataGrid(string subnet, string prefix, string gateway);

        event Action AddNoteAction;
    }
}