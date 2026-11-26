using Entities;

namespace Repositories
{
    internal interface IOrderRepository
    {
        Task<Order> GetOrderById(int id);
        Task<Order> PostOrder(Order order);
    }
}