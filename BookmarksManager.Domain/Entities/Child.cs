namespace BookmarksManager.Domain.Entities;

public class Child
{
    public string DateAdded { get; set; }
    public string Guid { get; set; }
    public string Id { get; set; }
    public MetaInfo MetaInfo { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Url { get; set; }
    public List<Child> Children { get; set; }
    public string DateModified { get; set; }
}
