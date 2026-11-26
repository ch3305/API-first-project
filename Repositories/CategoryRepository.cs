using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        StoreDbContext dbContext;
        public CategoryRepository(StoreDbContext db)
        {
            dbContext = db;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await dbContext.Categories.ToListAsync();
        }
        public async Task<Category> GetCategoryById(int id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }
        //public async Task<Category> UpdateCategory(Category category)
        //{
        //    dbContext.Categories.Update(category);
        //    await dbContext.SaveChangesAsync();
        //    return category;
        //}
        //public async Task<Category> AddCategory(Category category)
        //{
        //    await dbContext.Categories.AddAsync(category);
        //    await dbContext.SaveChangesAsync();
        //    return category;
        //}
        //public async Task<bool> DeleteCategory(int id)
        //{
        //    Category category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        //    if (category != null)
        //    {
        //        dbContext.Categories.Remove(category);
        //        await dbContext.SaveChangesAsync();
        //        return true;
        //    }
        //    return false;
        //}

    }
}
