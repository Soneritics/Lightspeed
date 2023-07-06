namespace Lightspeed.Api.Models.Generic;

public class TaxRate
{
    public string Name { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public decimal Amount { get; set; }
}