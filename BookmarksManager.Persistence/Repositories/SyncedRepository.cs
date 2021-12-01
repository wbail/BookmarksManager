using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.Domain.Entities;

namespace BookmarksManager.Persistence.Repositories;

public class SyncedRepository : BaseRepository<Synced>, ISyncedRepository
{
    public SyncedRepository(BookmarksManagerDbContext dbContext) : base(dbContext)
    {
    }
}
