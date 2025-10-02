using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Restaurent.Core.Domain.Entities;
using Restaurent.Core.Domain.RepositoryContracts;
using Restaurent.Infrastructure.DBContext;

namespace Restaurent.Infrastructure.Repositories
{
    public class CategoriesRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CategoriesRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _dbContext.Categories.ToListAsync();  
        }

        public async Task<Category?> GetCategoryByCategoryId(Guid categoryId)
        {
            Category? matchingCategory = await _dbContext.Categories
                                                         .FirstOrDefaultAsync(temp=>temp.Id == categoryId);
            if (matchingCategory == null)
                return null;
            return matchingCategory;
        }
    }
}
