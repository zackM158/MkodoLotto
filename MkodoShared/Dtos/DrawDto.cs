namespace MkodoShared.Models;

public class DrawDto
{
    public string Id { get; set; } = string.Empty;
    public DateTime DrawDate { get; set; }
    public string FormattedDate => DrawDate.ToString("ddd, d MMMM yyyy").ToUpper();
    public string[] Numbers { get; set; } = [];
    public string BonusBall { get; set; } = string.Empty;
    public long TopPrize { get; set; }
    public string Jackpot => TopPrize.ToString("C0", System.Globalization.CultureInfo.CurrentCulture);
}
