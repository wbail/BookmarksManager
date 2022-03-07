using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookmarksManager.Persistence.Repositories;

public class ChildRepository : BaseRepository<Child>, IChildRepository
{
    private readonly BookmarksManagerDbContext _dbContext;

    public ChildRepository(BookmarksManagerDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Child> GetChildByUrlAsync(string url)
    {
        return await _dbContext.Child.FirstOrDefaultAsync(x => x.Url == url);
    }
}