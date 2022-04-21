using System;
using System.Linq;
using System.Linq.Expressions;
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
			if (ClearButton is not null) {
				ClearButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
			}
			if (FiltersCheckbox is not null) {
				FiltersCheckbox.RaiseEvent(new RoutedEventArgs(CheckBox.ClickEvent));
			}

			if (ElixirsListView is not null) {
				ElixirsListView.Visibility = MainViewModel.CurrentSection == CurrentSectionName.Elixirs
					? Visibility.Visible
					: Visibility.Collapsed;
			}

			if (HousesListView is not null) {
				HousesListView.Visibility = MainViewModel.CurrentSection == CurrentSectionName.Houses
					? Visibility.Visible
					: Visibility.Collapsed;
			}

			if (IngredientsListView is not null) {
				IngredientsListView.Visibility = MainViewModel.CurrentSection == CurrentSectionName.Ingredients
					? Visibility.Visible
					: Visibility.Collapsed;
			}

			if (SpellsListView is not null) {
				SpellsListView.Visibility = MainViewModel.CurrentSection == CurrentSectionName.Spells
					? Visibility.Visible
					: Visibility.Collapsed;
			}

			if (WizardsListView is not null) {
				WizardsListView.Visibility = MainViewModel.CurrentSection == CurrentSectionName.Wizards
					? Visibility.Visible
					: Visibility.Collapsed;
			}
		}

		private void FiltersCheckbox_OnClick(object sender, RoutedEventArgs e) {
			CheckIfCurrentSectionHasFilters();
			ElixirFiltersGrid.Visibility =
				FiltersCheckbox.IsChecked == true && MainViewModel.CurrentSection == CurrentSectionName.Elixirs
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

		private void CheckIfCurrentSectionHasFilters() {
			if (MainViewModel.CurrentSection == CurrentSectionName.Ingredients ||
			    MainViewModel.CurrentSection == CurrentSectionName.Houses) {
				FiltersCheckbox.IsChecked = false;
				FiltersCheckbox.IsEnabled = false;
			}
			else {
				FiltersCheckbox.IsEnabled = true;
			}
		}

		private void SearchButton_OnClick(object sender, RoutedEventArgs e) {
			throw new NotImplementedException();
		}

		private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) {
			var text = SearchTextBox.Text;
			if (text.Length < 3 && text.Length > 0)
				return;
			switch (MainViewModel.CurrentSection) {
				case CurrentSectionName.Elixirs:
					if (text.Length == 0) {
						ElixirsListView.ItemsSource = MainViewModel.Elixirs.Data;
					}
					else {
						var searchedElixirs = MainViewModel.Elixirs.Data.Where(a =>
							(a.Characteristics is not null &&
							 a.Characteristics.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.Difficulty is not null &&
							 a.Difficulty.ToCamelCase().Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.Effect is not null &&
							 a.Effect.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.Ingredients is not null &&
							 a.Ingredients.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.Inventors is not null &&
							 a.Inventors.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.Manufacturer is not null &&
							 a.Manufacturer.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.Name is not null && a.Name.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.Time is not null && a.Time.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.SideEffects is not null &&
							 a.SideEffects.Contains(text, StringComparison.CurrentCultureIgnoreCase))).ToList();
						ElixirsListView.ItemsSource = searchedElixirs;
					}

					break;
				case CurrentSectionName.Houses:
					if (text.Length == 0) {
						HousesListView.ItemsSource = MainViewModel.Houses.Data;
					}
					else {
						var searchedHouses = MainViewModel.Houses.Data.Where(a =>
							(a.Animal is not null &&
							 a.Animal.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.Element is not null &&
							 a.Element.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.Founder is not null &&
							 a.Founder.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.Ghost is not null &&
							 a.Ghost.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.Heads is not null &&
							 a.Heads.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.Traits is not null &&
							 a.Traits.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.Name is not null && a.Name.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.CommonRoom is not null &&
							 a.CommonRoom.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.HouseColours is not null &&
							 a.HouseColours.Contains(text, StringComparison.CurrentCultureIgnoreCase))).ToList();
						HousesListView.ItemsSource = searchedHouses;
					}

					break;
				case CurrentSectionName.Ingredients:
					if (text.Length == 0) {
						IngredientsListView.ItemsSource = MainViewModel.Ingredients.Data;
					}
					else {
						var searchedIngredients = MainViewModel.Ingredients.Data.Where(a =>
							                                       (a.Name is not null &&
							                                        a.Name.Contains(text,
								                                        StringComparison.CurrentCultureIgnoreCase)))
						                                       .ToList();
						IngredientsListView.ItemsSource = searchedIngredients;
					}

					break;
				case CurrentSectionName.Spells:
					if (text.Length == 0) {
						SpellsListView.ItemsSource = MainViewModel.Spells.Data;
					}
					else {
						var searchedSpells = MainViewModel.Spells.Data.Where(a =>
							                                  (a.Creator is not null &&
							                                   a.Creator.Contains(text,
								                                   StringComparison.CurrentCultureIgnoreCase)) ||
							                                  (a.Incantation is not null &&
							                                   a.Incantation.Contains(text,
								                                   StringComparison.CurrentCultureIgnoreCase)) ||
							                                  (a.Effect is not null &&
							                                   a.Effect.Contains(text,
								                                   StringComparison.CurrentCultureIgnoreCase)) ||
							                                  (a.Light is not null &&
							                                   a.Light.ToCamelCase().Contains(text,
								                                   StringComparison.CurrentCultureIgnoreCase)) ||
							                                  (a.Type is not null &&
							                                   a.Type.ToCamelCase().Contains(text,
								                                   StringComparison.CurrentCultureIgnoreCase)) ||
							                                  (a.CanBeVerbal is not null &&
							                                   a.CanBeVerbal.ToString().Contains(text,
								                                   StringComparison.CurrentCultureIgnoreCase)) ||
							                                  (a.Name is not null &&
							                                   a.Name.Contains(text,
								                                   StringComparison.CurrentCultureIgnoreCase)))
						                                  .ToList();
						SpellsListView.ItemsSource = searchedSpells;
					}

					break;
				case CurrentSectionName.Wizards:
					if (text.Length == 0) {
						WizardsListView.ItemsSource = MainViewModel.Wizards.Data;
					}
					else {
						var searchedWizards = MainViewModel.Wizards.Data.Where(a =>
							(a.Elixirs is not null &&
							 a.Elixirs.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.FirstName is not null &&
							 a.FirstName.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
							(a.LastName is not null &&
							 a.LastName.Contains(text, StringComparison.CurrentCultureIgnoreCase))).ToList();
						WizardsListView.ItemsSource = searchedWizards;
					}

					break;
			}
		}

		private void ClearButton_OnClick(object sender, RoutedEventArgs e) {
			SearchTextBox.Clear();
			ReturnFullLists();
			ClearFiltersTextBoxes();
		}

		private void ClearFiltersTextBoxes() {
			switch (MainViewModel.CurrentSection) {
				case CurrentSectionName.Elixirs:
					ElixirDifficulty.Clear();
					ElixirIngredients.Clear();
					ElixirInventors.Clear();
					ElixirManufacturer.Clear();
					ElixirName.Clear();
					break;
				case CurrentSectionName.Houses:
					break;
				case CurrentSectionName.Ingredients:
					break;
				case CurrentSectionName.Spells:
					SpellIncantation.Clear();
					SpellName.Clear();
					SpellType.Clear();
					break;
				case CurrentSectionName.Wizards:
					WizardFirstName.Clear();
					WizardLastName.Clear();
					break;
			}
		}

		private void ReturnFullLists() {
			if (ElixirsListView is not null) {
				ElixirsListView.ItemsSource = MainViewModel.Elixirs.Data;
			}

			if (HousesListView is not null) {
				HousesListView.ItemsSource = MainViewModel.Houses.Data;
			}

			if (IngredientsListView is not null) {
				IngredientsListView.ItemsSource = MainViewModel.Ingredients.Data;
			}

			if (SpellsListView is not null) {
				SpellsListView.ItemsSource = MainViewModel.Spells.Data;
			}

			if (WizardsListView is not null) {
				WizardsListView.ItemsSource = MainViewModel.Wizards.Data;
			}
		}
	}
}