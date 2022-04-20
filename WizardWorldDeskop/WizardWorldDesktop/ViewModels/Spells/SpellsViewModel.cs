using System.Collections.ObjectModel;

namespace WizardWorldDesktop.ViewModels.Spells; 

public class SpellsViewModel {
    public SpellFiltersViewModel Filters { get; set; } = new();
    public ObservableCollection<SpellViewModel> Data { get; set; } = new();
}