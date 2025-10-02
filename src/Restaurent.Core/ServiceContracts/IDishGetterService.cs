using System;
using Restaurent.Core.DTO;

namespace Restaurent.Core.ServiceContracts
{
    public interface IDishGetterService
    {
        /// <summary>
        /// Returns all dishes from the data store
        /// </summary>
        /// <returns>Returns all dishes</returns>
        Task<List<DishResponse>> GetAllDishes();


        /// <summary>
        /// Search for dish based on id
        /// </summary>
        /// <param name="dishId">the dish to be search</param>
        /// <returns>Retuns dish based on id</returns>
        Task<DishResponse?> GetDishByDishId(Guid? dishId);


        /// <summary>
        ///  Gives all dishes based on categoryId from the database
        /// </summary>
        /// <param name="categoryID">CategoryId baesd on which dishes will be returned</param>
        /// <returns>Returns all the dishes based on  category id</returns>
        Task<List<DishResponse>?> GetDishesBasedOnCategoryId(Guid? categoryID);

        /// <summary>
        /// Returns all dishes which matches with given  searchString
        /// </summary>
        /// <param name="searchString">search String to search</param>
        /// <returns>Returns all matching dishes based on searchString</returns>
        Task<List<DishResponse>?> SearchDish(string searchString);
    }
}
