using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WizardWorld.Client.Models.Elixirs;
using WizardWorld.Client.Models.Houses;
using WizardWorld.Client.Models.Ingredients;
using WizardWorld.Client.Models.Spells;
using WizardWorld.Client.Models.Wizards;
using WizardWorld.Client.Services;
using WizardWorldDesktop.Extensions;
using WizardWorldDesktop.ViewModels.Elixirs;
using WizardWorldDesktop.ViewModels.Spells;
using WizardWorldDesktop.ViewModels.Wizards;

namespace WizardWorldDesktop;

public class WizardWorldService {
	private readonly Client _client;

	public WizardWorldService() {
		_client = new Client();
	}

	public async Task<List<Elixir>> LoadElixirs(ElixirFiltersViewModel? filters = null) {
		ElixirQuery? query = null;
		if (filters is not null) {
			query = new ElixirQuery();
			if (!string.IsNullOrEmpty(filters.Difficulty)) {
				query.Difficulty = Enum.Parse<ElixirDifficulty>(filters.Difficulty.RemoveSpaces());
			}

			if (!string.IsNullOrEmpty(filters.Ingredient)) {
				query.Ingredient = filters.Ingredient;
			}

			if (!string.IsNullOrEmpty(filters.InventorFullName)) {
				query.InventorFullName = filters.InventorFullName;
			}

			if (!string.IsNullOrEmpty(filters.Manufacturer)) {
				query.Manufacturer = filters.Manufacturer;
			}

			if (!string.IsNullOrEmpty(filters.Name)) {
				query.Name = filters.Name;
			}
		}

		return await _client.GetElixirsAsync(query) ?? new List<Elixir>();
	}

	public async Task<List<House>> LoadHouses() {
		return await _client.GetHousesAsync() ?? new List<House>();
	}

	public async Task<List<Ingredient>> LoadIngredients() {
		return await _client.GetIngredientsAsync() ?? new List<Ingredient>();
	}

	public async Task<List<Spell>> LoadSpells(SpellFiltersViewModel? filters = null) {
		SpellQuery? query = null;
		if (filters is not null) {
			query = new SpellQuery();
			if (!string.IsNullOrEmpty(filters.Incantation)) {
				query.Incantation = filters.Incantation;
			}

			if (!string.IsNullOrEmpty(filters.Name)) {
				query.Name = filters.Name;
			}

			if (!string.IsNullOrEmpty(filters.Type)) {
				query.Type = Enum.Parse<SpellType>(filters.Type.RemoveSpaces());
			}
		}

		return await _client.GetSpellsAsync(query) ?? new List<Spell>();
	}

	public async Task<List<Wizard>> LoadWizards(WizardFiltersViewModel? filters = null) {
		WizardQuery? query = null;
		if (filters is not null) {
			query = new WizardQuery();
			if (!string.IsNullOrEmpty(filters.FirstName)) {
				query.FirstName = filters.FirstName;
			}

			if (!string.IsNullOrEmpty(filters.LastName)) {
				query.LastName = filters.LastName;
			}
		}

		return await _client.GetWizardsAsync(query) ?? new List<Wizard>();
	}
}