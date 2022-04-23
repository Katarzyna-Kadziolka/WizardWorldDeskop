using RestSharp;
using WizardWorld.Client.Models.Houses;

namespace WizardWorld.Client.Services; 

public partial class Client {
    public async Task<List<House>?> GetHousesAsync() {
        var request = new RestRequest("/Houses");
        return await _client.GetAsync<List<House>>(request);
    }
}