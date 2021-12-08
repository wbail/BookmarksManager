using System.ComponentModel.DataAnnotations;

namespace BookmarksManager.Domain.Entities;

public class Synced
{
    public Synced()
    {

    }

    public Synced(List<Child>? children, string dateAdded, string dateModified, string guid, string id, string name, string type)
    {
        Children = children;
        DateAdded = dateAdded;
        DateModified = dateModified;
        Guid = guid;
        Id = id;
        Name = name;
        Type = type;
    }

    public List<Child>? Children { get; set; }
    public string DateAdded { get; set; }
    public string DateModified { get; set; }
    public string Guid { get; set; }

    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
}
