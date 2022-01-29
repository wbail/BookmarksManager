using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookmarksManager.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly BookmarksManagerDbContext _dbContext;

    public UserRepository(BookmarksManagerDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsUserExists(string username, string password)
    {
        var user = await _dbContext.Users
            .Where(x => x.Username == username && x.Password == password)
            .FirstOrDefaultAsync();

        return user != null ? true : false;
    }
}
