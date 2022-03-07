using System.ComponentModel.DataAnnotations;

namespace BookmarksManager.Domain.Entities;

public class Child
{
    public Child()
    {

    }

    public Child(string dateAdded, string guid, string id, MetaInfo metaInfo, string name, string type, string url, List<Child>? children, string syncedId, Synced synced, string dateModified)
    {
        DateAdded = dateAdded;
        Guid = guid;
        Id = id;
        MetaInfo = metaInfo;
        Name = name;
        Type = type;
        Url = url;
        Children = children;
        SyncedId = syncedId;
        Synced = synced;
        DateModified = dateModified;
    }

    public string DateAdded { get; set; }
    public string Guid { get; set; }

    [Key]
    public string Id { get; set; }
    public MetaInfo? MetaInfo { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Url { get; set; }
    public List<Child>? Children { get; set; }
    public string? SyncedId { get; set; }
    public Synced? Synced { get; set; }
    public List<ChildValidUrl>? ChildValidUrl { get; set; }
    public string DateModified { get; set; }
}
