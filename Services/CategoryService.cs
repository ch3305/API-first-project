using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    internal class CategoryService : ICategoryService
    {
        ICategoryRepository categoryRepository;
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await categoryRepository.GetCategories();
        }
       
        public async Task<Category> GetCategoryById(int id)
        {
            return await categoryRepository.GetCategoryById(id);
        }
    }
}
