namespace BookmarksManager.App.Contracts.Services;

public interface IHttpClientService
{
    Task<HttpResponseMessage> GetAsync(string url);
}
