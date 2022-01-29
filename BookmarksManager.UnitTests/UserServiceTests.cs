using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.App.Contracts.Services;
using BookmarksManager.App.Services;
using BookmarksManager.Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BookmarksManager.UnitTests;

public class UserServiceTests
{
    public UserServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_userRepositoryMock.Object);
    }

    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly IUserService _userService;

    [Fact]
    public async Task AddUser_ValidUser_SaveSuccessfully()
    {
        // Arrange
        var user = new User("Test", "test777", "default");

        // Act
        await _userService.AddUser(user);

        // Assert
        Assert.NotNull(user);
        _userRepositoryMock.Verify(x => x.AddAsync(user), Times.Once);
    }

    [Theory]
    [InlineData("test", "test1")]
    [InlineData("test7", "test777")]
    public async Task IsUserExists_UserExists_ReturnsTrue(string username, string password)
    {
        // Arrange
        _userRepositoryMock.Setup(x => x.IsUserExists(username, password)).ReturnsAsync(true);

        // Act
        var result = await _userService.IsUserExists(username, password);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("test", "test1")]
    [InlineData("test7", "test777")]
    public async Task IsUserExists_UserNotExists_ReturnsFalse(string username, string password)
    {
        // Arrange
        _userRepositoryMock.Setup(x => x.IsUserExists(username, password)).ReturnsAsync(false);

        // Act
        var result = await _userService.IsUserExists(username, password);

        // Assert
        Assert.False(result);
    }
}
