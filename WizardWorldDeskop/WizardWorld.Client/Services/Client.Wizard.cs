using RestSharp;
using WizardWorld.Client.Models.Wizards;

namespace WizardWorld.Client.Services; 

public partial class Client {
    public async Task<List<Wizard>> GetWizardsAsync(WizardQuery wizardQuery) {
        var request = new RestRequest("/Wizards");
        if (wizardQuery is not null) {
            if (wizardQuery.FirstName is not null)
                request.AddQueryParameter(nameof(wizardQuery.FirstName), wizardQuery.FirstName);
            if (wizardQuery.LastName is not null)
                request.AddQueryParameter(nameof(wizardQuery.LastName), wizardQuery.LastName);
        }

        return await _client.GetAsync<List<Wizard>>(request);
    }
}