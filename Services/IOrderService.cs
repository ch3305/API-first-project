using Entities;

namespace Services
{
    internal interface IOrderService
    {
       Task<Order> PostOrder(Order order);
       Task<Order> GetOrderById(int id);
    }
}