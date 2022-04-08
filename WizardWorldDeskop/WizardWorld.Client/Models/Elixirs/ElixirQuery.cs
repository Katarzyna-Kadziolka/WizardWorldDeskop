namespace WizardWorld.Client.Models.Elixirs; 

public class ElixirQuery {
    public string Name { get; set; }
    public ElixirDifficulty? Difficulty { get; set; }
    public string Ingredient { get; set; }
    public string InventorFullName { get; set; }
    public string Manufacturer { get; set; }
}