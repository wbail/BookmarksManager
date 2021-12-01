namespace BookmarksManager.Infrastructure.Configurations;

public class GoogleChromeBookmarksPathConfiguration
{
    public string GoogleChromeBookmarksPath { get; set; }
    public string LocalAppData { get { return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); } private set { } }
}
