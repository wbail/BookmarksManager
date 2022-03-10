namespace BookmarksManager.App.Contracts.Services;

public interface ILinkService
{
    Task<IEnumerable<string>> GetAll();
    Task SaveLastLinkSyncedToDatabase();
    Task<IEnumerable<string>> Get();
    Task SaveSyncedToDatabase();
    Task<Dictionary<string, bool>> TestSavedLinksAsync();
    Task<Dictionary<string, bool>> TestOneLinkAsync(string url);
    Task TestAndUpdateUrlHealthAsync(string url);
    Task TestAndUpdateAllUrlsHealthAsync();
    Task ExportToFiles();
}
