using ECommerce.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurent.Core.DTO;
using Restaurent.Core.ServiceContracts;

namespace Restaurent.WebAPI.Controllers
{
    [AllowAnonymous]
    public class DishesController : CustomControllerBase
    {
        private readonly IDishGetterService _dishGetterService;
        

        public DishesController(IDishGetterService dishGetterService)
        {
            _dishGetterService = dishGetterService;
        }

        [HttpGet()]
        public async Task<ActionResult> GetDishes()
        {
            List<DishResponse> dishes  = await _dishGetterService.GetAllDishes();
            return Ok(dishes);
        }

        [HttpGet("{dishId:guid}")]
        public async Task<ActionResult> GetDishByDishId(Guid dishId)
        {
           DishResponse? dish =  await _dishGetterService.GetDishByDishId(dishId);
            if (dish == null)
                return Problem(detail: "Invalid Dish Id", statusCode: 400, title: "Dish Search");

            return Ok(dish);
        }
    }
}
