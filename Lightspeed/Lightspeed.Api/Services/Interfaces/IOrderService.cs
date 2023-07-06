using Lightspeed.Api.Models.Requests;
using Lightspeed.Api.Models.Responses.Orders;

namespace Lightspeed.Api.Services.Interfaces;

public interface IOrderService
{
    Task<OrdersList> GetOrdersAsync(OrdersRequest ordersRequest);
    
    Task<Order> GetOrderAsync(int orderId);
}