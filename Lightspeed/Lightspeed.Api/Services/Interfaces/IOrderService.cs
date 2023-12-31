﻿using Lightspeed.Api.Models.Requests;
using Lightspeed.Api.Models.Responses.Orders;

namespace Lightspeed.Api.Services.Interfaces;

public interface IOrderService
{
    Task<OrdersList> GetOrdersAsync(OrdersRequest ordersRequest);
    
    Task<Order> GetOrderAsync(int orderId);

    Task ShipAsync(int orderId);

    Task PayAsync(int orderId);
    
    Task CancelAsync(int orderId);
    
    Task OpenAsync(int orderId);
}