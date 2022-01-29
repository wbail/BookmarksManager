using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.Domain.Entities;

namespace BookmarksManager.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(BookmarksManagerDbContext dbContext) : base(dbContext)
    {
        
    }
}
