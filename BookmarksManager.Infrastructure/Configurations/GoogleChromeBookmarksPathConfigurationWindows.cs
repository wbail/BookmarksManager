namespace BookmarksManager.Infrastructure.Configurations;

public class GoogleChromeBookmarksPathConfigurationWindows
{
    public string GoogleChromeBookmarksPathWindows { get; set; }
    public string LocalAppData { get { return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); } private set { } }
}
