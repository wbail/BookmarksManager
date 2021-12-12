using BookmarksManager.App.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookmarksManager.Api.Controllers;

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
}
