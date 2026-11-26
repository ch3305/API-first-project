using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    internal class ProductService : IProductService
    {
        IProductRepository productRepository;
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await productRepository.GetProducts();
        }
    }
}
