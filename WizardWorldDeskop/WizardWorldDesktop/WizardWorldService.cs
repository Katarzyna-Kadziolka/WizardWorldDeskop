using System.Collections.Generic;
using System.Threading.Tasks;
using WizardWorld.Client.Models.Elixirs;
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
}