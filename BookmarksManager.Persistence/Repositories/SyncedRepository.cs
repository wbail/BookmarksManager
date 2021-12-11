using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookmarksManager.Persistence.Repositories;

public class SyncedRepository : BaseRepository<Synced>, ISyncedRepository
{
    private readonly BookmarksManagerDbContext _dbContext;

    public SyncedRepository(BookmarksManagerDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Synced>> Get()
    {
        return await _dbContext.Synced.Include(x => x.Children).ToListAsync();
    }
}
