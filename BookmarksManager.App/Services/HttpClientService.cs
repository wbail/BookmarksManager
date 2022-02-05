using BookmarksManager.App.Contracts.Services;

namespace BookmarksManager.App.Services;

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _httpClient;

    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> GetAsync(string url)
    {
        var response = await _httpClient.GetAsync(url);

        return response;
    }
}
