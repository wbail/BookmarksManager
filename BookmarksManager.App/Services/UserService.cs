using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.App.Contracts.Services;
using BookmarksManager.Domain.Entities;

namespace BookmarksManager.App.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task AddUser(User user)
    {
        await _userRepository.AddAsync(user);
    }

    public async Task<bool> IsUserExists(string username, string password)
    {
        return await _userRepository.IsUserExists(username, password);
    }
}
