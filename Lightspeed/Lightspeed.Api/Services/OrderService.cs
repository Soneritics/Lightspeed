using Lightspeed.Api.Authorization;
using Lightspeed.Api.Exceptions;
using Lightspeed.Api.Models.Requests;
using Lightspeed.Api.Models.Responses.Orders;
using Lightspeed.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Lightspeed.Api.Services;

public class OrderService : ServiceBase, IOrderService
{
    public OrderService(ApiSecrets apiSecrets, HttpClient httpClient) : base(apiSecrets, httpClient)
    {
    }

    public async Task<OrdersList> GetOrdersAsync(OrdersRequest ordersRequest)
    {
        var parameters = new Dictionary<string, string>()
        {
            {"since_id", ordersRequest.SinceId.ToString()},
            {"page", ordersRequest.Page.ToString()},
            {"limit", ordersRequest.Limit.ToString()},
        };

        if (ordersRequest.Customer != null)
        {
            parameters.Add("customer", ordersRequest.Customer.Value.ToString());
        }

        if (ordersRequest.Fields != null)
        {
            parameters.Add("fields", ordersRequest.Fields);
        }

        if (ordersRequest.CreatedAtMin != null)
        {
            parameters.Add(
                "created_at_min",
                ordersRequest.CreatedAtMin.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        if (ordersRequest.CreatedAtMax != null)
        {
            parameters.Add(
                "created_at_max",
                ordersRequest.CreatedAtMax.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        if (ordersRequest.UpdatedAtMin != null)
        {
            parameters.Add(
                "updated_at_min",
                ordersRequest.UpdatedAtMin.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        if (ordersRequest.UpdatedAtMax != null)
        {
            parameters.Add(
                "updated_at_max",
                ordersRequest.UpdatedAtMax.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        return await GetApiResult<OrdersList>(HttpMethod.Get, "/orders.json" + QueryString.Create(parameters))
            ?? new OrdersList();
    }

    public async Task<Order> GetOrderAsync(int orderId)
    {
        var result = await GetApiResult<OrderResponse>(HttpMethod.Get, $"/orders/{orderId}.json");
        return result?.Order ?? throw new NotFoundException();
    }

    public async Task ShipAsync(int orderId)
    {
        await UpdateOrderAsync(
            orderId,
            new
            {
                order = new
                {
                    shipmentStatus = "shipped"
                }
            });
    }

    public async Task PayAsync(int orderId)
    {
        await UpdateOrderAsync(
            orderId,
            new
            {
                order = new
                {
                    paymentStatus = "paid"
                }
            });
    }

    public async Task CancelAsync(int orderId)
    {
        await UpdateOrderAsync(
            orderId,
            new
            {
                order = new
                {
                    status = "cancelled"
                }
            });
    }

    public async Task OpenAsync(int orderId)
    {
        await UpdateOrderAsync(
            orderId,
            new
            {
                order = new
                {
                    status = "new"
                }
            });
    }

    private async Task UpdateOrderAsync(int orderId, object data)
    {
        await CallApi(HttpMethod.Post, $"/orders/{orderId}.json", data);
    }
}