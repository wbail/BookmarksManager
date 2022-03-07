using System.ComponentModel.DataAnnotations;

namespace BookmarksManager.Domain.Entities;

public class ChildValidUrl
{
    public ChildValidUrl(string id, bool isValid, string childId, Child child, DateTime dateInserted)
    {
        Id = id;
        IsValid = isValid;
        ChildId = childId;
        Child = child;
        DateInserted = dateInserted;
    }

    public ChildValidUrl()
    {

    }

    [Key]
    public string Id { get; set; }
    public bool IsValid { get; set; }
    public string ChildId { get; set; }
    public Child Child { get; set; }
    public DateTime DateInserted { get; set; }
    public DateTime DateLastUpdate { get; set; }
}
