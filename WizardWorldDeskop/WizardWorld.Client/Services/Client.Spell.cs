using RestSharp;
using WizardWorld.Client.Models.Spells;

namespace WizardWorld.Client.Services; 

public partial class Client {
    public async Task<List<Spell>> GetSpellsAsync(SpellQuery spellQuery) {
        var request = new RestRequest("/Spells");
        if (spellQuery is not null) {
            if (spellQuery.Name is not null) request.AddQueryParameter(nameof(spellQuery.Name), spellQuery.Name);
            if (spellQuery.Type is not null)
                request.AddQueryParameter(nameof(spellQuery.Type), spellQuery.Type.ToString());
            if (spellQuery.Incantation is not null)
                request.AddQueryParameter(nameof(spellQuery.Incantation), spellQuery.Incantation);
        }

        return await _client.GetAsync<List<Spell>>(request);
    }
}