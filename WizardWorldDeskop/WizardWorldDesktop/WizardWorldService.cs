using System.Collections.Generic;
using System.Threading.Tasks;
using WizardWorld.Client.Models.Elixirs;
using WizardWorld.Client.Models.Houses;
using WizardWorld.Client.Models.Ingredients;
using WizardWorld.Client.Models.Spells;
using WizardWorld.Client.Models.Wizards;
using WizardWorld.Client.Services;

namespace WizardWorldDesktop;

public class WizardWorldService {
    private Client _client;

    public WizardWorldService() {
        _client = new Client();
    }

    public async Task<List<Elixir>> LoadElixirs() {
        return await _client.GetElixirsAsync();
    }

    public async Task<List<House>> LoadHouses() {
        return await _client.GetHousesAsync();
    }

    public async Task<List<Ingredient>> LoadIngredients() {
        return await _client.GetIngredientsAsync();
    }

    public async Task<List<Spell>> LoadSpells() {
        return await _client.GetSpellsAsync();
    }

    public async Task<List<Wizard>> LoadWizards() {
        return await _client.GetWizardsAsync();
    }
}