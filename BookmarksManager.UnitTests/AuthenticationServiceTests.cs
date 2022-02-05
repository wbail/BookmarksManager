using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.App.Models;
using BookmarksManager.App.Services;
using BookmarksManager.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BookmarksManager.UnitTests;

public class AuthenticationServiceTests
{
    public AuthenticationServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _jwtSettingsMock = new Mock<IOptions<JwtSettings>>();

        _authenticationService = new AuthenticationService(_userRepositoryMock.Object, _jwtSettingsMock.Object);
    }

    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IOptions<JwtSettings>> _jwtSettingsMock;
    private readonly AuthenticationService _authenticationService;

    [Fact]
    public async Task Authenticate_UserNotExists_ReturnsNull()
    {
        // Arrange
        var jwtSettings = GetJwtSettings();

        _jwtSettingsMock.Setup(x => x.Value).Returns(jwtSettings);

        var userAuthentication = new UserAuthentication { Username = "", Password = "" };

        // Act
        var result = await _authenticationService.Authenticate(userAuthentication);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Authenticate_UserExists_ReturnsToken()
    {
        // Arrange
        var jwtSettings = GetJwtSettings();

        var userAuthentication = new UserAuthentication { Username = "test", Password = "test777" };

        _jwtSettingsMock.Setup(x => x.Value).Returns(jwtSettings);

        _userRepositoryMock.Setup(x => x.IsUserExists(userAuthentication.Username, userAuthentication.Password)).ReturnsAsync(true);

        // Act
        var result = await _authenticationService.Authenticate(userAuthentication);

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result.Token);
    }

    private JwtSettings GetJwtSettings()
    {
        var jwtSettings = new JwtSettings();
        jwtSettings.Key = "7stringnullNOD9723od9237dn20937dbn239pdn2p9d3pd2938nd29p38nd2p39d7";
        jwtSettings.Issuer = "MyIssuerTest";
        jwtSettings.Audience = "MyAudienceTest";
        jwtSettings.ExpirationTimeInMinutes = 7;

        return jwtSettings;
    }
}
