using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.App.Services;
using BookmarksManager.Infrastructure.Configurations;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BookmarksManager.UnitTests;

public class SyncedServiceTests
{
    public SyncedServiceTests()
    {
        _googleChromeBookmarksPathConfigurationWindows = new GoogleChromeBookmarksPathConfigurationWindows();
        _googleChromeBookmarksPathConfigurationLinux = new GoogleChromeBookmarksPathConfigurationLinux();

        _readJsonService = new ReadJsonService(_googleChromeBookmarksPathConfigurationWindows, _googleChromeBookmarksPathConfigurationLinux);

        _syncedRepositoryMock = new Mock<ISyncedRepository>();

        _syncedService = new SyncedService(_readJsonService, _syncedRepositoryMock.Object);
    }

    private ReadJsonService _readJsonService;
    private readonly SyncedService _syncedService;
    private readonly GoogleChromeBookmarksPathConfigurationWindows _googleChromeBookmarksPathConfigurationWindows;
    private readonly GoogleChromeBookmarksPathConfigurationLinux _googleChromeBookmarksPathConfigurationLinux;
    private readonly Mock<ISyncedRepository> _syncedRepositoryMock;

    [Fact]
    public async Task GetSyncedAsync_RootIsNotEmptyWindows_ReturnsSynced()
    {
        // Arrange
        _googleChromeBookmarksPathConfigurationWindows.GoogleChromeBookmarksPathWindows = "\\Google\\Chrome\\User Data\\Default\\Bookmarks";

        _readJsonService = new ReadJsonService(_googleChromeBookmarksPathConfigurationWindows, _googleChromeBookmarksPathConfigurationLinux);

        // Act
        var result = await _syncedService.GetSyncedAsync();

        // Assert
        Assert.NotNull(result);
    }

    [Fact(Skip = "Needs to mock the string result")]
    public async Task GetSyncedAsync_RootIsNotEmptyLinux_ReturnsSynced()
    {
        // Arrange
        _googleChromeBookmarksPathConfigurationLinux.GoogleChromeBookmarksPathLinux = "~/.config/google-chrome/Default/Bookmarks";

        _readJsonService = new ReadJsonService(_googleChromeBookmarksPathConfigurationWindows, _googleChromeBookmarksPathConfigurationLinux);

        // Act
        var result = await _syncedService.GetSyncedAsync();

        // Assert
        Assert.NotNull(result);
    }
}
