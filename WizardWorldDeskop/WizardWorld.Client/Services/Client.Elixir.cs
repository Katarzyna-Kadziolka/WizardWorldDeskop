using RestSharp;
using WizardWorld.Client.Models.Elixirs;

namespace WizardWorld.Client.Services;

public partial class Client {
    public async Task<List<Elixir>> GetElixirsAsync(ElixirQuery elixirQuery = null) {
        var request = new RestRequest("/Elixirs");
        if (elixirQuery is not null) {
            if (elixirQuery.Name is not null) request.AddQueryParameter(nameof(elixirQuery.Name), elixirQuery.Name);
            if (elixirQuery.Difficulty is not null)
                request.AddQueryParameter(nameof(elixirQuery.Difficulty), elixirQuery.Difficulty.ToString());
            if (elixirQuery.Ingredient is not null)
                request.AddQueryParameter(nameof(elixirQuery.Ingredient), elixirQuery.Ingredient);
            if (elixirQuery.InventorFullName is not null)
                request.AddQueryParameter(nameof(elixirQuery.InventorFullName), elixirQuery.InventorFullName);
            if (elixirQuery.Manufacturer is not null)
                request.AddQueryParameter(nameof(elixirQuery.Manufacturer), elixirQuery.Manufacturer);
        }
        return await _client.GetAsync<List<Elixir>>(request);
    }
}