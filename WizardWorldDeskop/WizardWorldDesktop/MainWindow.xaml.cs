using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WizardWorldDesktop.Extensions;
using WizardWorldDesktop.ViewModels;
using WizardWorldDesktop.ViewModels.Elixirs;

namespace WizardWorldDesktop {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public MainViewModel MainViewModel { get; set; } = new();
        public WizardWorldService WizardWorldService { get; set; }

        public MainWindow() {
            InitializeComponent();
            this.DataContext = MainViewModel;
            WizardWorldService = new WizardWorldService();
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e) {
            MainViewModel.Elixirs.Data.AddRange((await WizardWorldService.LoadElixirs())
                .Select(a => new ElixirViewModel(a)).ToList());
        }

        private void CurrentSection_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (ElixirsListView is not null) {
               ElixirsListView.Visibility = MainViewModel.CurrentSection == CurrentSectionName.Elixirs
                               ? Visibility.Visible
                               : Visibility.Collapsed; 
            }
            
        }
    }
}