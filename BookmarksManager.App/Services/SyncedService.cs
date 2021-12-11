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

    #region Public Methods

    public async Task<IReadOnlyList<Synced>> Get()
    {
        return await _syncedRepository.Get();
    }

    public async Task<Synced> GetSyncedAsync()
    {
        var root = await GetRoot();

        var synced = root.Roots.Synced;

        return synced;
    }

    public async Task<Synced> SaveSyncedAsync(Synced synced)
    {
        return await _syncedRepository.AddAsync(synced);
    }

    #endregion

    #region Private Methods

    private async Task<Root> GetRoot()
    {
        var jsonString = await _readJsonService.ReadJsonAsync();

        return JsonConvert.DeserializeObject<Root>(jsonString);
    }

    #endregion
}
