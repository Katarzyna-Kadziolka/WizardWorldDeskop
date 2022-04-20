using System.Collections.ObjectModel;

namespace WizardWorldDesktop.ViewModels.Ingredients; 

public class IngredientsViewModel {
    public IngredientFiltersViewModel Filters { get; set; } = new();
    public ObservableCollection<IngredientViewModel> Data { get; set; } = new();
}