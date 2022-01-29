using BookmarksManager.Domain.Entities;

namespace BookmarksManager.App.Contracts.Persistence;

public interface IUserRepository : IAsyncRepository<User>
{
    Task<bool> IsUserExists(string username, string password);
}
