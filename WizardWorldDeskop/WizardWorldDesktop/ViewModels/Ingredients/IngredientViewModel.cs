using System;
using WizardWorld.Client.Models.Ingredients;

namespace WizardWorldDesktop.ViewModels.Ingredients; 

public class IngredientViewModel {
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public IngredientViewModel(Ingredient ingredient) {
        Id = ingredient.Id;
        Name = ingredient.Name;
    }
}