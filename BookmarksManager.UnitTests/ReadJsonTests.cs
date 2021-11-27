using BookmarksManager.App.Application;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace BookmarksManager.UnitTests;

public class ReadJsonTests
{
    public ReadJsonTests()
    {
        _readJson = new ReadJson();
    }

    private readonly ReadJson _readJson;

    [Fact]
    public void BookmarksFileExists_FileExists_ReturnsTrue()
    {
        // Arrange

        // Act
        var fileExists = _readJson.BookmarksFileExists();

        // Assert
        Assert.True(fileExists);
    }

    [Fact(Skip = "TODO: Fix the test method")]
    public async void ReadJsonAsync_FileNotExists_ReturnsExcpetion()
    {
        // Arrange
        var readJsonMock = new Mock<ReadJson>();
        readJsonMock.Setup(x => x.BookmarksFileExists()).Returns(false);

        // Act
        Action act = () => _readJson.ReadJsonAsync();

        // Assert
        var exception = Assert.Throws<Exception>(act);
        Assert.Equal("File not found.", exception.Message);
    }

    [Fact]
    public async void ReadJsonAsync_BookmarksFileNotNull_ReturnsJsonString()
    {
        // Arrange

        // Act
        var jsonString = await _readJson.ReadJsonAsync();

        // Assert
        Assert.NotNull(jsonString);
    }

    [Fact]
    public async void SyncedLinksAsync_LinksExists_ReturnsList()
    {
        // Arrange

        // Act
        var links = await _readJson.GetSyncedLinks();

        // Assert
        Assert.True(links.Any());
    }

    [Fact]
    public async void GetRoot_Root_ReturnsRoot()
    {
        // Arrange

        // Act
        var root = await _readJson.GetRoot();

        // Assert
        Assert.NotNull(root);
    }
}