using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductServices;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockServices;
        public StockController(IStockService stockServices)
        {
            _stockServices = stockServices;
        }

        [HttpGet("Control/{productId}/{amount}/{Unit}")]
        public ActionResult Control(long productId, decimal amount, int Unit)
        {
            if (productId == 0 || amount == 0 || Unit == 0)
                return BadRequest();

            var hasStock = _stockServices.StockControl(productId, amount, Unit);
            if (hasStock)
                return Ok();
            else
                return StatusCode(Core.StatusCodes.Status600InsufficientStock, new Core.CustomException.InsufficientStock());
        }

    }
}
