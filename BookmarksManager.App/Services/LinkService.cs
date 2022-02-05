using BookmarksManager.App.Contracts.Services;

namespace BookmarksManager.App.Services;

public class LinkService : ILinkService
{
    private readonly ISyncedService _syncedService;
    private readonly ITestLinkService _testLinkService;

    public LinkService(ISyncedService syncedService, ITestLinkService testLinkService)
    {
        _syncedService = syncedService;
        _testLinkService = testLinkService;
    }

    public async Task<IEnumerable<string>> Get()
    {
        var synced = await _syncedService.Get();

        synced = synced.ToList();

        var test = synced.FirstOrDefault();

        return test?.Children.Select(x => x.Url).ToList();
    }

    public async Task<IEnumerable<string>> GetAll()
    {
        var synced = await _syncedService.GetSyncedAsync();

        return synced.Children
            .Select(x => x.Url)
            .ToList();
    }

    public async Task SaveLastLinkSyncedToDatabase()
    {
        var lastSynced = await _syncedService.GetLastLinkSynced();

        await _syncedService.SaveLastSyncedToDatabaseAsync(lastSynced);
    }

    public async Task SaveSyncedToDatabase()
    {
        var synced = await _syncedService.GetSyncedAsync();

        await _syncedService.SaveSyncedAsync(synced);
    }

    public async Task<Dictionary<string, bool>> TestSavedLinksAsync()
    {
        var urls = await GetAll();

        var dictionary = await _testLinkService.TestLinksAsync(urls);

        return dictionary;
    }

    public async Task<Dictionary<string, bool>> TestOneLinkAsync(string url)
    {
        var result = await _testLinkService.TestOneLinkAsync(url);

        return result;
    }
}
