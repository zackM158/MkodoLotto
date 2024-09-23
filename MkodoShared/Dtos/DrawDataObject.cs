using System.Text.Json.Serialization;

namespace MkodoShared.Models;

public class DrawDataObject
{
    public string Id { get; set; } = string.Empty;
    public DateTime DrawDate { get; set; }
    public string Number1 { get; set; } = string.Empty;
    public string Number2 { get; set; } = string.Empty;
    public string Number3 { get; set; } = string.Empty;
    public string Number4 { get; set; } = string.Empty;
    public string Number5 { get; set; } = string.Empty;
    public string Number6 { get; set; } = string.Empty;

    [JsonPropertyName("bonus-ball")]
    public string BonusBall { get; set; } = string.Empty;
    public long TopPrize { get; set; }
}
