namespace WizardWorld.Client.Models.Elixirs; 

public class ElixirInventor {
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public override string ToString() {
        return $"{FirstName} {LastName}";
    }
}