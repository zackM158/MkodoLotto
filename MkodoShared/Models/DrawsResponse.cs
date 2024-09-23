namespace MkodoShared.Models;

public class DrawsResponse
{
    public List<DrawDataObject> Draws { get; set; } = new List<DrawDataObject>();
    public bool HasError { get; set; }
}
