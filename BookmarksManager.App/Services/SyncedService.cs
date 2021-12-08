using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.App.Contracts.Services;
using BookmarksManager.Domain.Entities;
using Newtonsoft.Json;

namespace BookmarksManager.App.Services;

public class SyncedService : ISyncedService
{
    private readonly IReadJsonService _readJsonService;
    private readonly ISyncedRepository _syncedRepository;

    public SyncedService(IReadJsonService readJsonService, ISyncedRepository syncedRepository)
    {
        _readJsonService = readJsonService;
        _syncedRepository = syncedRepository;
    }

    public async Task<List<string>> GetAllLinksAsync()
    {
        var root = await GetRoot();

        var synced = root.Roots.Synced;

        var links = new List<string>();

        foreach (var link in synced.Children)
        {
            links.Add(link.Url);
        }

        await _syncedRepository.AddAsync(synced);

        return links;
    }

    private async Task<Root> GetRoot()
    {
        var jsonString = await _readJsonService.ReadJsonAsync();

        return JsonConvert.DeserializeObject<Root>(jsonString);
    }
}
