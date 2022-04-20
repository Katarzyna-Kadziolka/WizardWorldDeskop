using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WizardWorldDesktop.Extensions;
using WizardWorldDesktop.ViewModels;
using WizardWorldDesktop.ViewModels.Elixirs;
using WizardWorldDesktop.ViewModels.Houses;
using WizardWorldDesktop.ViewModels.Ingredients;
using WizardWorldDesktop.ViewModels.Spells;
using WizardWorldDesktop.ViewModels.Wizards;

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
            MainViewModel.Houses.Data.AddRange((await WizardWorldService.LoadHouses())
                .Select(a => new HouseViewModel(a)).ToList());
            MainViewModel.Ingredients.Data.AddRange((await WizardWorldService.LoadIngredients())
                .Select(a => new IngredientViewModel(a)).ToList());
            MainViewModel.Spells.Data.AddRange((await WizardWorldService.LoadSpells())
                .Select(a => new SpellViewModel(a)).ToList());
            MainViewModel.Wizards.Data.AddRange((await WizardWorldService.LoadWizards())
                .Select(a => new WizardViewModel(a)).ToList());
        }

        private void CurrentSection_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (FiltersCheckbox is not null) {
                FiltersCheckbox.IsEnabled = true;
                FiltersCheckbox.IsChecked = false;
            }
            if (ElixirsListView is not null) {
                ElixirsListView.Visibility = MainViewModel.CurrentSection == CurrentSectionName.Elixirs
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            } 
            if (HousesListView is not null) {
                if (FiltersCheckbox is not null && MainViewModel.CurrentSection == CurrentSectionName.Houses) {
                    FiltersCheckbox.IsEnabled = false;
                }
                HousesListView.Visibility = MainViewModel.CurrentSection == CurrentSectionName.Houses
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
        }

        private void FiltersCheckbox_OnClick(object sender, RoutedEventArgs e) {
            ElixirFiltersGrid.Visibility =
                FiltersCheckbox.IsChecked == true && MainViewModel.CurrentSection == CurrentSectionName.Elixirs
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            IngredientFiltersGrid.Visibility = 
                FiltersCheckbox.IsChecked == true && MainViewModel.CurrentSection == CurrentSectionName.Ingredients
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            SpellFiltersGrid.Visibility = 
                FiltersCheckbox.IsChecked == true && MainViewModel.CurrentSection == CurrentSectionName.Spells
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            WizardFiltersGrid.Visibility = 
                FiltersCheckbox.IsChecked == true && MainViewModel.CurrentSection == CurrentSectionName.Wizards
                    ? Visibility.Visible
                    : Visibility.Collapsed;
        }
    }
}