using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using IPv6Library.Devices;
using RouterEmulatorApp.API.Views;

namespace RouterEmulatorApp.Views
{
    public partial class EditSwitchWindow : Window, IEditSwitchWindow
    {
        public string[] SwitchInfo { get; private set; }
        public event Action SaveChangesAction;
        public EditSwitchWindow()
        {
            InitializeComponent();
        }

        public void SetupWindow(string header,  string address, string prefix, string subnet)
        {
            textBlockHeader.Text = header;
            textBoxAddress.Text = address;
            textBoxPrefix.Text = prefix;
            textBoxSubnet.Text = subnet;
        }
        
        public void Start()
        {
            this.ShowDialog();
        }

        public void Stop()
        {
            this.Close();
        }

        public void ShowErrorMessage(string header, string message)
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void TextBoxPrefix_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.Any(char.IsDigit);
        }

        private void TextBoxAddress_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
        }

        private void ButtonSaveChanges_OnClick(object sender, RoutedEventArgs e)
        {
            SwitchInfo = new[]
            {
                textBoxAddress.Text,
                textBoxPrefix.Text,
            };
            SaveChangesAction.Invoke();
        }

        private void ButtonCloseWindow_OnClick(object sender, RoutedEventArgs e)
        {
            Stop();
        }
    }
}