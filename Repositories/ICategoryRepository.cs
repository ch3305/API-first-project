using Entities;

namespace Repositories
{
    internal interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
    }
}