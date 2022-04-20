using System;
using WizardWorld.Client.Models.Spells;

namespace WizardWorldDesktop.ViewModels.Spells; 

public class SpellViewModel {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Incantation { get; set; }
    public string Effect { get; set; }
    public bool? CanBeVerbal { get; set; }
    public string Type { get; set; }
    public string Light { get; set; }
    public string Creator { get; set; }

    public SpellViewModel(Spell spell) {
        Id = spell.Id;
        Name = spell.Name;
        Incantation = spell.Incantation;
        Effect = spell.Effect;
        CanBeVerbal = spell.CanBeVerbal;
        Type = spell.Type.ToString();
        Light = spell.Light.ToString();
        Creator = spell.Creator;
    }
}