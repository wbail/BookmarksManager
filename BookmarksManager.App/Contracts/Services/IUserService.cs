using BookmarksManager.Domain.Entities;

namespace BookmarksManager.App.Contracts.Services;

public interface IUserService
{
    Task AddUser(User user);
}
