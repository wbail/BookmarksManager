namespace BookmarksManager.Domain.Entities;

public class Root
{
    public string Checksum { get; set; }
    public Roots Roots { get; set; }
    public string SyncMetadata { get; set; }
    public int Version { get; set; }
}
