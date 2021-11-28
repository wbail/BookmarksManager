namespace BookmarksManager.Domain.Entities;

public class Synced
{
    public List<Child> Children { get; set; }
    public string DateAdded { get; set; }
    public string DateModified { get; set; }
    public string Guid { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
}
