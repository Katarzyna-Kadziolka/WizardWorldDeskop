namespace WizardWorld.Client.Models.Ingredients; 

public class Ingredient {
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public override string ToString() {
        return Name ?? "";
    }
}