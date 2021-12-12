using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.Domain.Entities;

namespace BookmarksManager.Persistence.Repositories;

public class ChildRepository : BaseRepository<Child>, IChildRepository
{
    private readonly BookmarksManagerDbContext _dbContext;

    public ChildRepository(BookmarksManagerDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}