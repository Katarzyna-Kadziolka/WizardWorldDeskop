using WizardWorldDesktop.ViewModels.Elixirs;

namespace WizardWorldDesktop.ViewModels; 

public class MainViewModel {
    public ElixirsViewModel Elixirs { get; set; } = new();
    public string CurrentSection { get; set; } = CurrentSectionName.Elixirs;
    
}