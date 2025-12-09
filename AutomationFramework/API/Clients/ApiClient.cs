using Microsoft.Extensions.Configuration;
using RestSharp;

namespace AutomationFramework.API.Clients
{
    public class ApiClient
    {
        private readonly RestClient _restClient;

        //constructor
        public ApiClient(IConfiguration config) 
        {
            _restClient = new RestClient(config["apiBaseUrl"]);
        }

        public RestResponse Get(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            return _restClient.Execute(request);
        }

        public RestResponse Get(string endpoint, string token)
        {
            var request = new RestRequest(endpoint, Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");
            return _restClient.Execute(request);
        }

        public RestResponse Post(string endpoint, object data)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(data);
            return _restClient.Execute(request);
        }
    }
}