using BookmarksManager.App.Domain;
using Newtonsoft.Json;

namespace BookmarksManager.App.Application;

public class ReadJson
{
    private string _localDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

    public string BookmarksPath { get => $"{_localDataPath}\\Google\\Chrome\\User Data\\Default\\Bookmarks"; set { _localDataPath = value; } }

    public bool BookmarksFileExists()
    {
        return File.Exists(BookmarksPath);
    }

    public async Task<string> ReadJsonAsync()
    {
        if (!BookmarksFileExists())
        {
            throw new Exception("File not found.");
        }

        var jsonString = await File.ReadAllTextAsync(BookmarksPath);

        return jsonString;
    }

    public async Task<Root> GetRoot()
    {
        var jsonString = await ReadJsonAsync();

        return JsonConvert.DeserializeObject<Root>(jsonString);
    }

    public async Task<List<string>> GetSyncedLinks()
    {
        var root = await GetRoot();

        var links = new List<string>();

        foreach (var link in root.Roots.Synced.Children)
        {
            links.Add(link.Url);
        }

        return links;
    }
}
