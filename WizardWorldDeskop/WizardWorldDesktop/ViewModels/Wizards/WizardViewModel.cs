using System;
using System.Linq;
using WizardWorld.Client.Models.Wizards;

namespace WizardWorldDesktop.ViewModels.Wizards; 

public class WizardViewModel {
    public string Elixirs { get; set; }
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public WizardViewModel(Wizard wizard) {
        Id = wizard.Id;
        FirstName = wizard.FirstName;
        LastName = wizard.LastName;
        Elixirs = string.Join(", ", wizard.Elixirs.Select(a => a.ToString()));
    }
}