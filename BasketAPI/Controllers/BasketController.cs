using BasketCore.Models;
using BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace BasketAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost("AddBasket")]
        public ActionResult AddBasket(BasketDto basketItem)
        {
            var hasStock = _basketService.StockControl(basketItem);
            if (!hasStock)
                return StatusCode(Core.StatusCodes.Status600InsufficientStock, new Core.CustomException.InsufficientStock());

            _basketService.AddBasket(basketItem);

            return Ok();
        }
    }
}
