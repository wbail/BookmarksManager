using BookmarksManager.App.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookmarksManager.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SyncedBookmarksController : ControllerBase
{
    private readonly ILogger<SyncedBookmarksController> _logger;
    private readonly ILinkService _linkService;

    public SyncedBookmarksController(ILogger<SyncedBookmarksController> logger, ILinkService linkService)
    {
        _logger = logger;
        _linkService = linkService;
    }

    [HttpGet("links", Name = "Get All Links from Memory")]
    public async Task<IEnumerable<string>> GetAllLinksAsync()
    {
        return await _linkService.GetAll();
    }

    [HttpGet]
    public async Task<IEnumerable<string>> GetSynced()
    {
        return await _linkService.Get();
    }

    [HttpPost("last-link")]
    public async Task SaveLastLinkSynced()
    {
        await _linkService.SaveLastLinkSyncedToDatabase();
    }

    [HttpPost]
    public async Task SaveAllSynced()
    {
        await _linkService.SaveSyncedToDatabase();
    }

    [HttpGet("test-link")]
    public async Task<Dictionary<string, bool>> TestOneLink(string url)
    {
        return await _linkService.TestOneLinkAsync(url);
    }

    [HttpGet("test-saved-links")]
    public async Task<Dictionary<string, bool>> TestSavedLinks()
    {
        return await _linkService.TestSavedLinksAsync();
    }

    [HttpPut("test-and-update-url")]
    public async Task<string> TestAndUpdateUrlHealthAsync(string url)
    {
        await _linkService.TestAndUpdateUrlHealthAsync(url);

        return url;
    }

    [HttpPut("test-and-update-all-urls")]
    public async Task TestAndUpdateAllUrlsHealthAsync()
    {
        await _linkService.TestAndUpdateAllUrlsHealthAsync();
    }

    [HttpPost("export")]
    public async Task ExportToFiles()
    {
        await _linkService.ExportToFiles();
    }
}
