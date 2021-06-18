using System;
using System.Windows;
using RouterEmulatorApp.Models;
using RouterEmulatorApp.Presenters;
using RouterEmulatorApp.Views;

namespace RouterEmulatorApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static App _app;

        public static App Instance => _app ?? (_app = new App());
        private  App()
        {
            InitializeComponent();
        }
        
        [STAThread]
        public static void Main()
        {
            var presenter = new MainWindowPresenter(new MainModel(), new MainWindow());
            presenter.Start();
        }
    }
    
}