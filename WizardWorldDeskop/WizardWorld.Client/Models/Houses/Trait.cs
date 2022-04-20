namespace WizardWorld.Client.Models.Houses; 

public class Trait {
    public Guid Id { get; set; }
    public TraitName Name { get; set; }
    public override string ToString() {
        return Name.ToString();
    }
}