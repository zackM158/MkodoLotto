namespace MkodoShared.Models;

public class Draw
{
    public string Id { get; set; } = string.Empty;
    public DateTime DrawDate { get; set; }
    public string[] Numbers { get; set; } = [];
    public string BonusBall { get; set; } = string.Empty;
    public long TopPrize { get; set; }
}
