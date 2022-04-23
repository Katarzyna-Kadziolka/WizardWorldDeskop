namespace WizardWorld.Client.Models.Wizards; 

public class WizardElixir {
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public override string ToString() {
        return Name ?? "";
    }
}