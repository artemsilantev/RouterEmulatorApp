using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using IPv6Library.Devices;
using RouterEmulatorApp.Entities;

namespace RouterEmulatorApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : API.Views.IMainWindow
    {
        private List<Grid> _switchesOneGrids;
        private List<Grid> _switchesTwoGrids;
        private ImageId _selectedRouterImage;
        private ImageId _selectedSwitchImage;



        public int SelectedRouterIndex { get; private set; }
        public int SelectedSwitchIndex { get; private set; }

        public event Action AddSwitchAction;
        public event Action DeleteSwitchAction;
        public event Action EditSwitchAction;
        public event Action DisplayRouterInfoAction;
        public MainWindow()
        {
            InitializeComponent();
            _selectedRouterImage = null;
            _selectedSwitchImage = null;
            _switchesOneGrids = new List<Grid>();
            _switchesTwoGrids = new List<Grid>();
        }

        public void Start()
        {
            Application.Current.Run(this);
        }

        private void ImageRouter_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(_selectedRouterImage!=null)
                ChangeSelectedRouterColor();
            _selectedRouterImage = sender as ImageId;
            ChangeSelectedRouterColor(true);
        }

        private void ChangeSelectedRouterColor(bool isClicked = false)
        {
            _selectedRouterImage.Source = InitImage(isClicked ? "/Resources/Images/routerSelected.png" : "/Resources/Images/router.png");
        }

        private void ChangeSelectedSwitchColor(bool isClicked = false)
        {
            _selectedSwitchImage.Source = InitImage(isClicked ? "/Resources/Images/switchSelected.png" : "/Resources/Images/switch.png");
        }
        public void ShowErrorMessage(string header, string message)
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        

        public void AddSwitch( string id,  string address, string prefix, string subnet)
        {
            AddSwitch(GenerateSwitchGrid(id,address,prefix,subnet));
        }

        public void DeleteSwitch()
        {
            var gridToDelete = FindSelectedSwitchGridByRouter();
            if(gridToDelete!=null)
                DeleteSwitch(gridToDelete);
        }

        
        private ImageId FindSelectedRouterBySwitch()
        {
            return _switchesOneGrids.Any(grid => (grid.Children[0] as ImageId) == _selectedSwitchImage) ? imageRouterOne : imageRouterTwo;
        }
        private Grid FindSelectedSwitchGridByRouter()
        {
            switch (SelectedRouterIndex)
            {
                case 0:
                {
                    foreach (var grid in _switchesOneGrids.Where(grid => (grid.Children[0] as ImageId) == _selectedSwitchImage))
                    {
                        return grid;
                    }

                    break;
                }
                case 1:
                    foreach (var grid in _switchesTwoGrids.Where(grid => (grid.Children[0] as ImageId) == _selectedSwitchImage))
                    {
                        return grid;
                    }
                    break;
            }

            return null;
        }

        public void ChangeSwitchInfo(string id, string address, string prefix, string subnet)
        {
            var grid = FindSelectedSwitchGridByRouter();
            var stackPanel = grid.Children[1] as StackPanel;
            stackPanel.Children.Clear();
            stackPanel.Children.Add(GenerateBorderWithLabel("Port: "+ id));
            stackPanel.Children.Add(GenerateBorderWithLabel("Address: " + address));
            stackPanel.Children.Add(GenerateBorderWithLabel("Prefix " + prefix));
            stackPanel.Children.Add(GenerateBorderWithLabel("Network: " + subnet));
        }
        
        private Grid GenerateSwitchGrid(string id, string address, string prefix, string subnet)
        {
            var grid = new Grid {Margin = new Thickness(0, 15, 15, 0)};
            grid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(150)
            });
            grid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1,GridUnitType.Star)
            });
            var stackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
            };
            var image = new ImageId(){Width = 110, Source = InitImage("/Resources/Images/switch.png"), Id =int.Parse(id)};
            image.MouseDown += ImageSwitch_OnMouseDown;
            Grid.SetColumn(image,0);
            grid.Children.Add(image);
            stackPanel.Children.Add(GenerateBorderWithLabel("Port: "+ id));
            stackPanel.Children.Add(GenerateBorderWithLabel("Address: " + address));
            stackPanel.Children.Add(GenerateBorderWithLabel("Prefix " + prefix));
            stackPanel.Children.Add(GenerateBorderWithLabel("Network: " + subnet));
            Grid.SetColumn(stackPanel,1);
            grid.Children.Add(stackPanel);
            return grid;
        }

        private Border GenerateBorderWithLabel(string content)
        {
            return new Border()
            {
                Child = new Label()
                {
                    Content = content,
                    FontSize = 12,
                    FontWeight = FontWeights.DemiBold,
                },
                BorderBrush = new SolidColorBrush(Colors.MidnightBlue),
                BorderThickness = new Thickness(0,0,0,2)
            };
        }
        private void AddSwitch(Grid grid)
        {
            switch (SelectedRouterIndex)
            {
                case 0:
                {
                    _switchesOneGrids.Add(grid);
                    stackPanelLeftSwitches.Children.Add(grid);
                    break;
                }
                case 1:
                    _switchesTwoGrids.Add(grid);
                    stackPanelRightSwitches.Children.Add(grid);
                    break;
            }
        }
        
        private void DeleteSwitch(Grid grid)
        {
            switch (SelectedRouterIndex)
            {
                case 0:
                {
                    _switchesOneGrids.Remove(grid);
                    stackPanelLeftSwitches.Children.Remove(grid);
                    break;
                }
                case 1:
                    _switchesTwoGrids.Remove(grid);
                    stackPanelRightSwitches.Children.Remove(grid);
                    break;
            }
        }
        
        private void ImageSwitch_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(_selectedSwitchImage!=null)
                ChangeSelectedSwitchColor();
            _selectedSwitchImage = sender as ImageId;
            ChangeSelectedSwitchColor(true);
            ImageRouter_OnMouseDown(FindSelectedRouterBySwitch(), e);
        }
        
        private void ButtonAddSwitch_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedRouterImage == null)
            {
                ShowErrorMessage("Warning", "Router not found");
                return;
            }
            SelectedRouterIndex = _selectedRouterImage.Id;
            AddSwitchAction.Invoke();
        }

        private BitmapImage InitImage(string relativePath)
        {
            return new BitmapImage(new Uri(relativePath, UriKind.Relative));
        }

        private void ButtonDeleteSwitch_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedSwitchImage == null)
            {
                ShowErrorMessage("Warning", "Switch not found");
                return;
            }
            SelectedSwitchIndex = _selectedSwitchImage.Id;
            SelectedRouterIndex = _selectedRouterImage.Id;
            DeleteSwitchAction.Invoke();
            _selectedSwitchImage = null;
        }

        private void ButtonEditSwitch_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedSwitchImage == null)
            {
                ShowErrorMessage("Warning", "Switch not found");
                return;
            }
            SelectedSwitchIndex = _selectedSwitchImage.Id;
            SelectedRouterIndex = _selectedRouterImage.Id;
            EditSwitchAction.Invoke();
        }

        private void ButtonDisplayRouterInfo_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedRouterImage == null)
            {
                ShowErrorMessage("Warning", "Router not found");
                return;
            }
            SelectedRouterIndex = _selectedRouterImage.Id;
            DisplayRouterInfoAction.Invoke();
        }
    }
}