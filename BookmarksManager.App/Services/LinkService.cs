using BookmarksManager.App.Contracts.Services;

namespace BookmarksManager.App.Services;

public class LinkService : ILinkService
{
    private readonly ISyncedService _syncedService;

    public LinkService(ISyncedService syncedService)
    {
        _syncedService = syncedService;
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

    public async Task SaveToDatabase()
    {
        var synced = await _syncedService.GetSyncedAsync();

        await _syncedService.SaveSyncedAsync(synced);
    }
}
