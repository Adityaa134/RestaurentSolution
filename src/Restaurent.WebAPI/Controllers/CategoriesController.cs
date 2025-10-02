using ECommerce.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurent.Core.ServiceContracts;

namespace Restaurent.WebAPI.Controllers
{
    [AllowAnonymous]
    public class CategoriesController : CustomControllerBase
    {

        private readonly ICategoriesGetterService _categoriesGetterService;

        public CategoriesController(ICategoriesGetterService categoriesGetterService)
        {
            _categoriesGetterService = categoriesGetterService;
        }

        [HttpGet()]
        public async Task<ActionResult> GetAllCategories()
        {
            List<CategoryResponse> categories = await _categoriesGetterService.GetAllCategories();
            return Ok(categories);
        }
    }
}
