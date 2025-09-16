using Lightspeed.Api.Authorization;
using Lightspeed.Api.Services;
using Lightspeed.Api.Services.Interfaces;

namespace Lightspeed.Api;

public class LightspeedApi
{
    private readonly ApiSecrets _apiSecrets;
    
    private readonly HttpClient _httpClient;

    public LightspeedApi(ApiSecrets apiSecrets) : this(apiSecrets, new HttpClient())
    {
    }

    public LightspeedApi(ApiSecrets apiSecrets, HttpClient httpClient)
    {
        _apiSecrets = apiSecrets;
        _httpClient = httpClient;
    }

    private IWebhookService? _webhookService;
    public IWebhookService WebhookService => _webhookService ??= new WebhookService(_apiSecrets, _httpClient);

    private IOrderService? _orderService;
    public IOrderService OrderService => _orderService ??= new OrderService(_apiSecrets, _httpClient);

    private IProductService? _productService;
    public IProductService ProductService => _productService ??= new ProductService(_apiSecrets, _httpClient);

    private IProductMetafieldService? _productMetafieldService;
    public IProductMetafieldService ProductMetafieldService => _productMetafieldService ??= new ProductMetafieldService(_apiSecrets, _httpClient);

    private ICategoryService? _categoryService;
    public ICategoryService CategoryService => _categoryService ??= new CategoryService(_apiSecrets, _httpClient);

    private ICategoryProductService? _categoryProductService;
    public ICategoryProductService CategoryProductService => _categoryProductService ??= new CategoryProductService(_apiSecrets, _httpClient);
    
    private IShipmentService? _shipmentService;
    public IShipmentService ShipmentService => _shipmentService ??= new ShipmentService(_apiSecrets, _httpClient);
    
    private IVariantService? _variantService;
    public IVariantService VariantService => _variantService ??= new VariantService(_apiSecrets, _httpClient);
    
    private IRedirectService? _redirectService;
    public IRedirectService RedirectService => _redirectService ??= new RedirectService(_apiSecrets, _httpClient);
}