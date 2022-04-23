namespace WizardWorld.Client.Models.Wizards; 

public class Wizard {
    public ICollection<WizardElixir>? Elixirs { get; set; }
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}