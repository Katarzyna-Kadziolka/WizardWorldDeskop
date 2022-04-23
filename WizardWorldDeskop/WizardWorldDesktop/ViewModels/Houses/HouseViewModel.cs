using System;
using System.Linq;
using WizardWorld.Client.Models.Houses;

namespace WizardWorldDesktop.ViewModels.Houses; 

public class HouseViewModel {
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? HouseColours { get; set; }
    public string? Founder { get; set; }
    public string? Animal { get; set; }
    public string? Element { get; set; }
    public string? Ghost { get; set; }
    public string? CommonRoom { get; set; }
    public string? Heads { get; set; }
    public string? Traits { get; set; }

    public HouseViewModel(House house) {
        Id = house.Id;
        Name = house.Name;
        HouseColours = house.HouseColours;
        Founder = house.Founder;
        Animal = house.Animal;
        Element = house.Element;
        Ghost = house.Ghost;
        CommonRoom = house.CommonRoom;
        Heads = house.Heads is not null ? string.Join(", ", house.Heads.Select(a => a.ToString())) : string.Empty;
        Traits = house.Traits is not null ? string.Join(", ", house.Traits.Select(a => a.ToString())) : string.Empty;
    }
}