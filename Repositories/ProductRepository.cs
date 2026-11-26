using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    internal class ProductRepository : IProductRepository
    {
        StoreDbContext _dbContent;
        public ProductRepository(StoreDbContext db)
        {
            _dbContent = db;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _dbContent.Products.ToListAsync();
        }
    }
}
