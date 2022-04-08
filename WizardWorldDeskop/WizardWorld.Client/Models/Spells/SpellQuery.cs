namespace WizardWorld.Client.Models.Spells; 

public class SpellQuery {
    public string Name { get; set; }
    public SpellType? Type { get; set; }
    public string Incantation { get; set; }
}