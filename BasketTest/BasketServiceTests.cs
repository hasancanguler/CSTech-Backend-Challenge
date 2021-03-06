using APIConnection;
using BasketCore.Cashe;
using BasketCore.Models;
using BasketServices;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace BasketTest
{
    public class BasketServiceTests
    {
        private IBasketService _basketService;
        private IAPIConnect _IAPIConnect;
        private ICasheService _ICasheService;
        [SetUp]
        public void Setup()
        {
            _IAPIConnect = new APIConnect("http://localhost:51299/api/Stock/");

            var redisOption = Options.Create(new RedisOption());
            redisOption.Value.Host = "redisHost";
            redisOption.Value.Timeout = 60;
            redisOption.Value.Port = 140;
            redisOption.Value.Expires = 1440;

            _ICasheService = new RedisCasheService(redisOption);

            _basketService = new BasketService(_IAPIConnect, _ICasheService);
        }

        [Test]
        public void StockControl()
        {
            //I assume there is db and stock
            var control = _basketService.StockControl(
                new BasketDto
                {
                    Id = 1,
                    CustomerId = 1,
                    ProductId = 1,
                    Amount = 10,
                    Unit = 1
                });

            if (control)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void AddBasket()
        {
            _basketService.AddBasket(
                new BasketDto
                {
                    Id = 1,
                    CustomerId = 1,
                    ProductId = 1,
                    Amount = 10,
                    Unit = 1
                });
            Assert.Pass();
        }
    }
}