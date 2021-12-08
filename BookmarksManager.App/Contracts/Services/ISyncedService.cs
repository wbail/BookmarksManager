using BookmarksManager.Domain.Entities;

namespace BookmarksManager.App.Contracts.Services;

public interface ISyncedService
{
    Task<Synced> GetSyncedAsync();
    Task<Synced> SaveSyncedAsync(Synced synced);
}
