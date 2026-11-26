using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;    

namespace Services
{
    internal class OrderService: IOrderService
    {
        IOrderRepository orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task<Order> PostOrder(Order order)
        {
            return await orderRepository.PostOrder(order);
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await orderRepository.GetOrderById(id);
        }
    }
}
