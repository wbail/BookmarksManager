using BookmarksManager.Domain.Entities;

namespace BookmarksManager.App.Contracts.Services;

public interface ISyncedService
{
    Task<Synced> GetSyncedAsync();
    Task<Synced> SaveSyncedAsync(Synced synced);
    Task<IReadOnlyList<Synced>> Get();
    Task<Child> GetLastLinkSynced();
    Task<Child> SaveLastSyncedToDatabaseAsync(Child child);
}
