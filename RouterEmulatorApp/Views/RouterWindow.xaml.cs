using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using RouterEmulatorApp.API.Views;
using RouterEmulatorApp.Entities;

namespace RouterEmulatorApp.Views
{
    public partial class RouterWindow : Window, IRouterWindow
    {
        private readonly ObservableCollection<DataGridItem> _dataTable;
        
        public string[] NoteInfo { get; private set; }
       
        public event Action AddNoteAction;

        public RouterWindow()
        {
            InitializeComponent();
            _dataTable = new ObservableCollection<DataGridItem>();
            dataGridRoutingTable.ItemsSource = _dataTable;
        }
        

        public void Start()
        {
            this.ShowDialog();
        }

        public void Stop()
        {
            this.Close();
        }

        public void SetupWindow(string header)
        {
            labelAddress.Content = header;
        }

        public void ShowErrorMessage(string header, string message)
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void FillDataGrid(string subnet, string prefix, string gateway)
            => _dataTable.Add(new DataGridItem($"{subnet}/{prefix}", gateway));
        

        private void ButtonAddNote_OnClick(object sender, RoutedEventArgs e)
        {
            if (textBoxGateway.Text == "") return;
            if (textBoxNetwork.Text == "") return;
            if (textBoxPrefix.Text == "") return;
            NoteInfo = new[]
            {
                textBoxNetwork.Text,
                textBoxPrefix.Text,
                textBoxGateway.Text
            };
            
            _dataTable.Clear();
            AddNoteAction.Invoke();
            
        }

        private void TextBoxPrefix_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.Any(char.IsDigit);
        }
        
    }
}