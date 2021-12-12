namespace BookmarksManager.App.Contracts.Services;

public interface ILinkService
{
    Task<IEnumerable<string>> GetAll();
    Task SaveLastLinkSyncedToDatabase();
    Task<IEnumerable<string>> Get();
    Task SaveSyncedToDatabase();
}
