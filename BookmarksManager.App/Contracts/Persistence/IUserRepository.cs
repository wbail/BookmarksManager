using BookmarksManager.Domain.Entities;

namespace BookmarksManager.App.Contracts.Persistence;

public interface IUserRepository : IAsyncRepository<User>
{

}
