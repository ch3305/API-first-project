using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    internal class OrderRepository:IOrderRepository
    {
        StoreDbContext storeDb;
        public OrderRepository(StoreDbContext db)
        {
            storeDb = db;
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await storeDb.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<Order> PostOrder(Order order)
        {
            storeDb.Orders.Add(order);
            await storeDb.SaveChangesAsync();
            return order;
        }
    }
}
