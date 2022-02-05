using BookmarksManager.App.Contracts.Services;
using BookmarksManager.App.Services;
using BookmarksManager.Domain.Entities;
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
        _syncedServiceMock = new Mock<ISyncedService>();
        _testLinkServiceMock = new Mock<ITestLinkService>();

        _linkService = new LinkService(_syncedServiceMock.Object, _testLinkServiceMock.Object);
    }

    private readonly Mock<ISyncedService> _syncedServiceMock;
    private readonly Mock<ITestLinkService> _testLinkServiceMock;
    private readonly LinkService _linkService;

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

    [Fact]
    public async Task Get_ValidRequest_RetunsListOfLinks()
    {
        // Arrange
        var synced = GetSyncedObjectsList();
        _syncedServiceMock.Setup(x => x.Get()).ReturnsAsync(synced);

        // Act
        var links = await _linkService.Get();

        // Assert
        Assert.True(links.Any());
    }

    private IReadOnlyList<Synced> GetSyncedObjectsList()
    {
        var children = new List<Child>
        {
            new Child("13271961482990459", "aea3d950-8c34-49c0-a43a-29d440e7af1d", "67", null, "Test Name Mock", "url", "https://test.com/", null, "3", null, "13271961482990459")
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
            new Child("13271961482990459", "aea3d950-8c34-49c0-a43a-29d440e7af1d", "67", null, "Test Name Mock", "url", "https://test.com/", null, "3", null, "13271961482990459")
        };

        var synced = new Synced(children, "13279094946199199", "13283206821065132", "4cf2e351-0e85-532b-bb37-df045d8f8d0f", "3", "Mobile bookmarks", "folder");

        return synced;
    }
}
