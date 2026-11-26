using Entities;

namespace Services
{
    internal interface IProductService
    {
       Task<IEnumerable<Product>> GetProducts();
    }
}