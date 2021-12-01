using BookmarksManager.App.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookmarksManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SyncedBookmarksController : ControllerBase
{
    private readonly ILogger<SyncedBookmarksController> _logger;
    private readonly ISyncedService _syncedService;

    public SyncedBookmarksController(ILogger<SyncedBookmarksController> logger, ISyncedService syncedService)
    {
        _logger = logger;
        _syncedService = syncedService;
    }

    [HttpGet]
    public async Task<IEnumerable<string>> Get()
    {
        return await _syncedService.GetAll();
    }
}
