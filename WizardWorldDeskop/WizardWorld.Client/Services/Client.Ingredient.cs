using RestSharp;
using WizardWorld.Client.Models.Ingredients;

namespace WizardWorld.Client.Services;

public partial class Client {
    public async Task<List<Ingredient>?> GetIngredientsAsync(IngredientQuery? ingredientQuery = null) {
        var request = new RestRequest("/Ingredients");
        if (ingredientQuery is not null && ingredientQuery.Name is not null)
            request.AddQueryParameter(nameof(ingredientQuery.Name), ingredientQuery.Name);
        return await _client.GetAsync<List<Ingredient>>(request);
    }
}