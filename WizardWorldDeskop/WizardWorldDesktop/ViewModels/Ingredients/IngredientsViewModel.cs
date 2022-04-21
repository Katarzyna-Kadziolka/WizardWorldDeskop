using System.Collections.ObjectModel;

namespace WizardWorldDesktop.ViewModels.Ingredients; 

public class IngredientsViewModel {
    public ObservableCollection<IngredientViewModel> Data { get; set; } = new();
}