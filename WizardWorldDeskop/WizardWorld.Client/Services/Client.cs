using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace WizardWorld.Client.Services;

public partial class Client {
    private readonly RestClient _client;

    public Client() {
        _client = new RestClient("https://wizard-world-api.herokuapp.com");
        _client.UseNewtonsoftJson();
    }
}