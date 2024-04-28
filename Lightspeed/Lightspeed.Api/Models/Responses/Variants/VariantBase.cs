namespace Lightspeed.Api.Models.Responses.Variants;

public abstract class VariantBase
{
    public bool IsDefault { get; set; }
    public int SortOrder { get; set; }
    public string ArticleCode { get; set; }
    public string Ean { get; set; }
    public string Sku { get; set; }
    public string Hs { get; set; }
    public decimal PriceExcl { get; set; }
    public decimal PriceIncl { get; set; }
    public decimal PriceCost { get; set; }
    public decimal OldPriceExcl { get; set; }
    public decimal OldPriceIncl { get; set; }
    public string StockTracking { get; set; }
    public int StockLevel { get; set; }
    public int StockAlert { get; set; }
    public int StockMinimum { get; set; }
    public int StockSold { get; set; }
    public int StockBuyMinimum { get; set; } = 1;
    public int StockBuyMaximum { get; set; } = 10000;
    public int Weight { get; set; }
    public int Volume { get; set; }
    public int Colli { get; set; }
    public int SizeX { get; set; }
    public int SizeY { get; set; }
    public int SizeZ { get; set; }
    public string Title { get; set; }
}