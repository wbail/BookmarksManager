using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.App.Contracts.Services;
using BookmarksManager.App.Services;
using BookmarksManager.Domain.Entities;
using BookmarksManager.Infrastructure.Configurations;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BookmarksManager.UnitTests;

public class SyncedServiceTests
{
    public SyncedServiceTests()
    {
        _googleChromeBookmarksPathConfigurationWindows = new GoogleChromeBookmarksPathConfigurationWindows();
        _googleChromeBookmarksPathConfigurationLinux = new GoogleChromeBookmarksPathConfigurationLinux();

        _googleChromeBookmarksPathConfigurationWindows.GoogleChromeBookmarksPathWindows = "\\Google\\Chrome\\User Data\\Default\\Bookmarks";
        _googleChromeBookmarksPathConfigurationLinux.GoogleChromeBookmarksPathLinux = "~/.config/google-chrome/Default/Bookmarks";

        _readJsonService = new ReadJsonService(_googleChromeBookmarksPathConfigurationWindows, _googleChromeBookmarksPathConfigurationLinux);

        _readJsonServiceMock = new Mock<IReadJsonService>();

        _syncedRepositoryMock = new Mock<ISyncedRepository>();
        _syncedServiceMock = new Mock<ISyncedService>();

        _syncedService = new SyncedService(_readJsonService, _syncedRepositoryMock.Object);
    }

    private ReadJsonService _readJsonService;
    private readonly SyncedService _syncedService;
    private readonly GoogleChromeBookmarksPathConfigurationWindows _googleChromeBookmarksPathConfigurationWindows;
    private readonly GoogleChromeBookmarksPathConfigurationLinux _googleChromeBookmarksPathConfigurationLinux;
    private readonly Mock<ISyncedRepository> _syncedRepositoryMock;
    private readonly Mock<IReadJsonService> _readJsonServiceMock;
    private readonly Mock<ISyncedService> _syncedServiceMock;

    [Fact]
    public async Task GetSyncedAsync_RootIsNotEmptyWindows_ReturnsSynced()
    {
        // Arrange
        _readJsonService = new ReadJsonService(_googleChromeBookmarksPathConfigurationWindows, _googleChromeBookmarksPathConfigurationLinux);

        // Act
        var result = await _syncedService.GetSyncedAsync();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetLastLinkSynced_RootIsNotEmpty_ReturnsLastChild()
    {
        // Arrange

        // Act
        var result = await _syncedService.GetLastLinkSynced();

        // Assert
        Assert.IsType<Child>(result);
    }

    [Fact(Skip = "Needs to mock the string result")]
    public async Task GetSyncedAsync_RootIsNotEmptyLinux_ReturnsSynced()
    {
        // Arrange
        _readJsonService = new ReadJsonService(_googleChromeBookmarksPathConfigurationWindows, _googleChromeBookmarksPathConfigurationLinux);

        // Act
        var result = await _syncedService.GetSyncedAsync();

        // Assert
        Assert.NotNull(result);
    }

    private IReadOnlyList<Synced> GetSyncedObjectsList()
    {
        var children = new List<Child>
        {
            new Child("13271961482990459", "aea3d950-8c34-49c0-a43a-29d440e7af1d", "67", null, "Test Name Mock", "url", "https://test.com/", null, "3", null, "13271961482990459"),
            new Child("13277961482990459", "e8eac951-c488-4833-b9b2-ccc86f983c4b", "68", null, "Test1 Name Mock", "url", "https://test1.com/", null, "3", null, "12271771482990459")
        };

        var synced = new List<Synced>()
        {
            new Synced(children, "13279094946199199", "13283206821065132", "4cf2e351-0e85-532b-bb37-df045d8f8d0f", "3", "Mobile bookmarks", "folder")
        };

        return synced;
    }

    private Synced GetSyncedObject()
    {
        var children = new List<Child>
        {
            new Child("13271961482990459", "aea3d950-8c34-49c0-a43a-29d440e7af1d", "67", null, "Test Name Mock", "url", "https://test.com/", null, "3", null, "13271961482990459"),
            new Child("13277961482990459", "e8eac951-c488-4833-b9b2-ccc86f983c4b", "68", null, "Test1 Name Mock", "url", "https://test1.com/", null, "3", null, "12271771482990459")
        };

        var synced = new Synced(children, "13279094946199199", "13283206821065132", "4cf2e351-0e85-532b-bb37-df045d8f8d0f", "3", "Mobile bookmarks", "folder");

        return synced;
    }
}
