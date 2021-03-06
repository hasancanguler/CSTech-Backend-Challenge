using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProductDAL;
using ProductServices;

namespace ProductTest
{
    public class StockServiceTests
    {
        private IStockService _stockService;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<MyContext> dbContextOptions = new DbContextOptions<MyContext>();            
            MyContext context = new MyContext(dbContextOptions);
            _stockService = new StockService(context);
        }

        [Test]
        public void StockControl()
        {
            //1111 is a known productId that in stock
            var control  = _stockService.StockControl(1111, 1, 1);
            if (control)
                Assert.Pass();
            else
                Assert.Fail();

        }
    }
}