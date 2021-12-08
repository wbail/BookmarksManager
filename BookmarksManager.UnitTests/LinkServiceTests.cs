using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.App.Contracts.Services;
using BookmarksManager.App.Services;
using BookmarksManager.Domain.Entities;
using BookmarksManager.Infrastructure.Configurations;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BookmarksManager.UnitTests;

public class LinkServiceTests
{
    public LinkServiceTests()
    {
        _googleChromeBookmarksPathConfiguration = new GoogleChromeBookmarksPathConfiguration();
        _googleChromeBookmarksPathConfiguration.GoogleChromeBookmarksPath = "\\Google\\Chrome\\User Data\\Default\\Bookmarks";

        _readJsonService = new ReadJsonService(_googleChromeBookmarksPathConfiguration);

        _syncedRepositoryMock = new Mock<ISyncedRepository>();

        _syncedServiceMock = new Mock<ISyncedService>();

        _linkService = new LinkService(_syncedServiceMock.Object);
    }

    private readonly Mock<ISyncedService> _syncedServiceMock;
    private readonly LinkService _linkService;

    private readonly ReadJsonService _readJsonService;
    private readonly GoogleChromeBookmarksPathConfiguration _googleChromeBookmarksPathConfiguration;
    private readonly Mock<ISyncedRepository> _syncedRepositoryMock;

    [Fact]
    public async Task GetAll_ValidRequest_RetunsListOfLinks()
    {
        // Arrange
        var synced = GetSyncedObject();
        _syncedServiceMock.Setup(x => x.GetSyncedAsync()).ReturnsAsync(synced);

        // Act
        var links = await _linkService.GetAll();

        // Assert
        Assert.True(links.Any());
    }

    private Synced GetSyncedObject()
    {
        var children = new List<Child>
        {
            new Child("13271961482990459", "aea3d950-8c34-49c0-a43a-29d440e7af1d", "67", null, "Test Name Mock", "url", "https://test.com/", null, "3", null, "13271961482990459")
        };

        var synced = new Synced(children, "13279094946199199", "13283206821065132", "4cf2e351-0e85-532b-bb37-df045d8f8d0f", "3", "Mobile bookmarks", "folder");

        return synced;
    }
}
