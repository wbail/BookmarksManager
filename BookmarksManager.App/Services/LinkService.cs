using BookmarksManager.App.Contracts.Services;
using System.Text;

namespace BookmarksManager.App.Services;

public class LinkService : ILinkService
{
    private readonly ISyncedService _syncedService;
    private readonly ITestLinkService _testLinkService;
    private readonly IChildValidUrlUpdateService _childValidUrlUpdateService;
    private readonly string _appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

    public LinkService(ISyncedService syncedService, ITestLinkService testLinkService, IChildValidUrlUpdateService childValidUrlUpdateService)
    {
        _syncedService = syncedService;
        _testLinkService = testLinkService;
        _childValidUrlUpdateService = childValidUrlUpdateService;
    }

    public async Task<IEnumerable<string>> Get()
    {
        var synced = await _syncedService.Get();

        synced = synced.ToList();

        var test = synced.FirstOrDefault();

        return test?.Children.Select(x => x.Url).ToList();
    }

    public async Task<IEnumerable<string>> GetAll()
    {
        var synced = await _syncedService.GetSyncedAsync();

        return synced.Children
            .Select(x => x.Url)
            .ToList();
    }

    public async Task SaveLastLinkSyncedToDatabase()
    {
        var lastSynced = await _syncedService.GetLastLinkSynced();

        await _syncedService.SaveLastSyncedToDatabaseAsync(lastSynced);
    }

    public async Task SaveSyncedToDatabase()
    {
        var synced = await _syncedService.GetSyncedAsync();

        await _syncedService.SaveSyncedAsync(synced);

        await InsertTestedLinksDatabaseAsync();
    }

    public async Task<Dictionary<string, bool>> TestSavedLinksAsync()
    {
        var urls = await GetAll();

        var dictionary = await _testLinkService.TestLinksAsync(urls);

        return dictionary;
    }

    public async Task<Dictionary<string, bool>> TestOneLinkAsync(string url)
    {
        var result = await _testLinkService.TestOneLinkAsync(url);

        return result;
    }

    public async Task TestAndUpdateUrlHealthAsync(string url)
    {
        var dictionary = await TestOneLinkAsync(url);

        await _childValidUrlUpdateService.SingleChangeIsValidStatusUpdate(dictionary.FirstOrDefault().Key);
    }

    public async Task TestAndUpdateAllUrlsHealthAsync()
    {
        var dictionary = await TestSavedLinksAsync();

        await _childValidUrlUpdateService.MultipleChangeIsValidStatusUpdate(dictionary.Keys);
    }

    private async Task InsertTestedLinksDatabaseAsync()
    {
        var dictionary = await TestSavedLinksAsync();

        await _childValidUrlUpdateService.InsertIntoDatabase(dictionary);
    }

    public async Task ExportToFiles()
    {
        var dictionary = await TestSavedLinksAsync();

        var validUrls = dictionary.Where(x => x.Value == true).Select(x => x.Key).ToList();
        var invalidUrls = dictionary.Where(x => x.Value == false).Select(x => x.Key).ToList();

        var bookmarksFolder = GetBookmarksManagerFolderPath();

        var validPath = bookmarksFolder + $"\\valid_links.txt";
        var invalidPath = bookmarksFolder + $"\\invalid_links.txt";

        CreateFolderIfNotExists();

        CreateFileIfNotExistsLinks(validPath);
        CreateFileIfNotExistsLinks(invalidPath);

        WriteFile(validPath, validUrls);
        WriteFile(invalidPath, invalidUrls);
    }

    private void WriteFile(string filePath, List<string> links)
    {
        using StreamWriter sw = File.CreateText(filePath);
        
        foreach (var link in links)
        {
            sw.WriteLine(link);
        }
    }

    private bool IsFileExists(string filePath)
    {
        return File.Exists(filePath);
    }

    private void CreateFileIfNotExistsLinks(string filePath)
    {
        if (!IsFileExists(filePath))
        {
            File.CreateText(filePath).Close();
        }
    }

    private string GetUserFolder()
    {
        string userPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        return userPath;
    }

    private void CreateFolderIfNotExists()
    {
        var userPath = GetUserFolder();
        var folderPath = userPath + $"\\{_appName}";

        if (!IsFolderExists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }

    private string GetBookmarksManagerFolderPath()
    {
        var userPath = GetUserFolder();
        var folderPath = userPath + $"\\{_appName}";

        return folderPath;
    }

    private bool IsFolderExists(string folderPath)
    {
        return Directory.Exists(folderPath);
    }
}
