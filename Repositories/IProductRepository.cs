using Entities;

namespace Repositories
{
    internal interface IProductRepository
    {
       Task<IEnumerable<Product>> GetProducts();
    }
}