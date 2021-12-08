namespace BookmarksManager.App.Contracts.Services;

public interface ISyncedService
{
    Task<List<string>> GetAllLinksAsync();
}
