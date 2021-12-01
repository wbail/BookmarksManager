using BookmarksManager.Domain.Entities;

namespace BookmarksManager.App.Contracts.Persistence;

public interface ISyncedRepository : IAsyncRepository<Synced>
{
}
