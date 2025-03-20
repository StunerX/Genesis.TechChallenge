using System.Text;
using Newtonsoft.Json;

namespace Genesis.TechChallenge.FunctionalTests.Common;

public class ApiClient
{
    private readonly HttpClient _httpClient;
    
    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<HttpResponseMessage> PostAsync(string route, object payload)
    {
        var requestContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
        
        return await _httpClient.PostAsync(route, requestContent);
    }
}