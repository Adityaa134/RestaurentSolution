using System;
using Restaurent.Core.Domain.Entities;
namespace Restaurent.Core.Domain.RepositoryContracts
{
    public interface ICategoryRepository
    {

        /// <summary>
        /// Returns list of all categories from data store
        /// </summary>
        /// <returns>Returns list of all categories</returns>
        Task<List<Category>> GetAllCategories();


        /// <summary>
        /// Search for category 
        /// </summary>
        /// <param name="categoryId">the category to be search</param>
        /// <returns>Returns the category based on id</returns>
        Task<Category?> GetCategoryByCategoryId(Guid categoryId);

    }
}
