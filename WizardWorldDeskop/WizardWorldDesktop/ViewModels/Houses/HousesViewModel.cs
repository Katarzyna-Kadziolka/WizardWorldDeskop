using System.Collections.ObjectModel;

namespace WizardWorldDesktop.ViewModels.Houses; 

public class HousesViewModel {
    public ObservableCollection<HouseViewModel> Data { get; set; } = new();
}