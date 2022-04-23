using System;
using System.Linq;
using WizardWorld.Client.Models.Elixirs;
using WizardWorldDesktop.Extensions;

namespace WizardWorldDesktop.ViewModels.Elixirs; 

public class ElixirViewModel {
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Effect { get; set; }
    public string? SideEffects { get; set; }
    public string? Characteristics { get; set; }
    public string? Time { get; set; }
    public string? Difficulty { get; set; }
    public string? Ingredients { get; set; }
    public string? Inventors { get; set; }
    public string? Manufacturer { get; set; }

    public ElixirViewModel(Elixir elixir) {
        Id = elixir.Id;
        Name = elixir.Name;
        Effect = elixir.Effect;
        SideEffects = elixir.SideEffects;
        Characteristics = elixir.Characteristics;
        Time = elixir.Time;
        Difficulty = elixir.Difficulty.ToString().ToSentence();
        Ingredients = elixir.Ingredients is not null ? string.Join(", ", elixir.Ingredients.Select(a => a.ToString())) : string.Empty;
        Inventors = elixir.Inventors is not null ? string.Join(", ", elixir.Inventors.Select(a => a.ToString())) : string.Empty;
        Manufacturer = elixir.Manufacturer;
    }
}