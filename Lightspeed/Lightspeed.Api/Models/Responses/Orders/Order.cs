using Lightspeed.Api.Models.Generic;
using Lightspeed.Api.Models.Responses.Customers;
using Lightspeed.Api.Models.Responses.Invoices;
using Lightspeed.Api.Models.Responses.Shipments;

namespace Lightspeed.Api.Models.Responses.Orders;

public class Order
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Status { get; set; } = string.Empty;
    public int? CustomStatusId { get; set; }
    public string Channel { get; set; } = string.Empty;
    public string RemoteIp { get; set; } = string.Empty;
    public string UserAgent { get; set; } = string.Empty;
    
    public decimal PriceCost { get; set; }
    public decimal PriceExcl { get; set; }
    public decimal PriceIncl { get; set; }
    
    public int Weight { get; set; }
    public int Volume { get; set; }
    public int Colli { get; set; }
    
    public string? Gender { get; set; }
    public string? BirthDate { get; set; }
    public string? NationalId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    
    public bool Iscompany { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string CompanyCoCNumber { get; set; } = string.Empty;
    public string CompanyVatNumber { get; set; } = string.Empty;
    
    public string AddressBillingName { get; set; } = string.Empty;
    public string AddressBillingStreet { get; set; } = string.Empty;
    public string AddressBillingStreet2 { get; set; } = string.Empty;
    public string AddressBillingNumber { get; set; } = string.Empty;
    public string AddressBillingExtension { get; set; } = string.Empty;
    public string AddressBillingZipcode { get; set; } = string.Empty;
    public string AddressBillingCity { get; set; } = string.Empty;
    public string AddressBillingRegion { get; set; } = string.Empty;
    public Country? AddressBillingCountry { get; set; }
    
    public string AddressShippingCompany { get; set; } = string.Empty;
    public string AddressShippingName { get; set; } = string.Empty;
    public string AddressShippingStreet { get; set; } = string.Empty;
    public string AddressShippingStreet2 { get; set; } = string.Empty;
    public string AddressShippingNumber { get; set; } = string.Empty;
    public string AddressShippingExtension { get; set; } = string.Empty;
    public string AddressShippingZipcode { get; set; } = string.Empty;
    public string AddressShippingCity { get; set; } = string.Empty;
    public string AddressShippingRegion { get; set; } = string.Empty;
    public Country? AddressShippingCountry { get; set; }
    
    public string PaymentId { get; set; } = string.Empty;
    public string PaymentStatus { get; set; } = string.Empty;
    public bool PaymentIsPost { get; set; }
    public bool PaymentIsInvoiceExternal { get; set; }
    public decimal PaymentTaxRate { get; set; }
    public List<TaxRate> PaymentTaxRates { get; set; } = new();
    public decimal PaymentBasePriceExcl { get; set; }
    public decimal PaymentBasePriceIncl { get; set; }
    public decimal PaymentPriceExcl { get; set; }
    public decimal PaymentPriceIncl { get; set; }
    public string PaymentTitle { get; set; } = string.Empty;
    
    public string ShipmentId { get; set; } = string.Empty;
    public string ShipmentStatus { get; set; } = string.Empty;
    public bool ShipmentIsCashOnDelivery { get; set; }
    public bool ShipmentIsPickup { get; set; }
    public decimal ShipmentTaxRate { get; set; }
    public List<TaxRate> ShipmentTaxRates { get; set; } = new();
    public decimal ShipmentBasePriceExcl { get; set; }
    public decimal ShipmentBasePriceIncl { get; set; }
    public decimal ShipmentDiscountExcl { get; set; }
    public decimal ShipmentDiscountIncl { get; set; }
    public decimal ShipmentPriceExcl { get; set; }
    public decimal ShipmentPriceIncl { get; set; }
    public string ShipmentTitle { get; set; } = string.Empty;
    public Dictionary<string, object>? ShipmentData { get; set; }
    
    public List<TaxRate> TaxRates { get; set; } = new();
    public DateTime? DeliveryDate { get; set; }

    public bool IsDiscounted { get; set; }
    public string DiscountType { get; set; } = string.Empty;
    public decimal DiscountAmount { get; set; }
    public decimal DiscountPercentage { get; set; }
    public string DiscountCouponCode { get; set; } = string.Empty;
    
    public bool IsNewCustomer { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string Memo { get; set; } = string.Empty;
    public Language? Language { get; set; }
    
    public EmbeddedGeneric<Customer>? Customer { get; set; }
    public EmbeddedGeneric<List<Invoice>>? Invoices { get; set; }
    public EmbeddedGeneric<List<Shipment>>? Shipments { get; set; }
    public EmbeddedGeneric<List<OrderedProduct>>? Products { get; set; }
    public EmbeddedGeneric<List<Metafield>>? Metafields { get; set; }
}