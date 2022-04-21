using System.Linq;
using WizardWorldDesktop.ViewModels.Elixirs;
using WizardWorldDesktop.ViewModels.Houses;
using WizardWorldDesktop.ViewModels.Ingredients;
using WizardWorldDesktop.ViewModels.Spells;
using WizardWorldDesktop.ViewModels.Wizards;

namespace WizardWorldDesktop.ViewModels; 

public class MainViewModel {
    public ElixirsViewModel Elixirs { get; set; } = new();
    public HousesViewModel Houses { get; set; } = new();
    public IngredientsViewModel Ingredients { get; set; } = new();
    public SpellsViewModel Spells { get; set; } = new();
    public WizardsViewModel Wizards { get; set; } = new();
    public string CurrentSection { get; set; } = CurrentSectionName.Elixirs;

    public void SearchWithFilters() {
        throw new System.NotImplementedException();
    }
}