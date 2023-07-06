using Lightspeed.Api.Models.Generic;

namespace Lightspeed.Api.Models.Responses.Orders;

public class OrderedProduct
{
    public string SupplierTitle { get; set; } = string.Empty;
    public string BrandTitle { get; set; } = string.Empty;
    public string ProductTitle { get; set; } = string.Empty;
    public string VariantTitle { get; set; } = string.Empty;
    public decimal TaxRate { get; set; }
    public List<TaxRate> TaxRates { get; set; } = new ();
    public int QuantityOrdered { get; set; }
    public int QuantityInvoiced { get; set; }
    public int QuantityShipped { get; set; }
    public int QuantityRefunded { get; set; }
    public int QuantityReturned { get; set; }
    public string ArticleCode { get; set; } = string.Empty;
    public string Ean { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
    public int Weight { get; set; }
    public int Volume { get; set; }
    public int Colli { get; set; }
    public int SizeX { get; set; }
    public int SizeY { get; set; }
    public int SizeZ { get; set; }
    public decimal PriceCost { get; set; }
    public decimal CustomExcl { get; set; }
    public decimal CustomIncl { get; set; }
    public decimal BasePriceExcl { get; set; }
    public decimal BasePriceIncl { get; set; }
    public decimal PriceExcl { get; set; }
    public decimal PriceIncl { get; set; }
    public decimal DiscountExcl { get; set; }
    public decimal DiscountIncl { get; set; }
}