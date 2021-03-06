using BasketCore.Models;

namespace BasketServices
{
    public interface IBasketService
    {
        void AddBasket(BasketDto basketItem);

        bool StockControl(BasketDto basketItem);
    }
}
