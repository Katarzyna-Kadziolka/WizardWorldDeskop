using System.Collections.ObjectModel;

namespace WizardWorldDesktop.ViewModels.Elixirs;

public class ElixirsViewModel {
    public ElixirFiltersViewModel Filters { get; set; } = new();
    public ObservableCollection<ElixirViewModel> Data { get; set; } = new();
}