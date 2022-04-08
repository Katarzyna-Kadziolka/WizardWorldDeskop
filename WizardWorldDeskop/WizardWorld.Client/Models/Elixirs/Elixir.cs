using WizardWorld.Client.Models.Ingredients;

namespace WizardWorld.Client.Models.Elixirs; 

public class Elixir {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Effect { get; set; }
    public string SideEffects { get; set; }
    public string Characteristics { get; set; }
    public string Time { get; set; }
    public ElixirDifficulty Difficulty { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; }
    public ICollection<ElixirInventor> Inventors { get; set; }
    public string Manufacturer { get; set; }
}