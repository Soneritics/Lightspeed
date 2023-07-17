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

    private IShipmentService? _shipmentService;
    public IShipmentService ShipmentService => _shipmentService ??= new ShipmentService(_apiSecrets, _httpClient);
}