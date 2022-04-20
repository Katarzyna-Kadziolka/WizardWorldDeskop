using System.Collections.ObjectModel;

namespace WizardWorldDesktop.ViewModels.Wizards; 

public class WizardsViewModel {
    public WizardFiltersViewModel Filters { get; set; } = new();
    public ObservableCollection<WizardViewModel> Data { get; set; } = new();
}