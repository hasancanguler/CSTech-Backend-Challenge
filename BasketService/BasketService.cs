using APIConnection;
using BasketCore.Cashe;
using BasketCore.Models;

namespace BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly IAPIConnect _APIConnect;
        private readonly ICasheService _casheService;
        public BasketService(IAPIConnect APIConnect, ICasheService casheService)
        {
            _APIConnect = APIConnect;
            _casheService = casheService;
        }
        public bool StockControl(BasketDto basketItem)
        {
            string url = "Control/" + basketItem.ProductId + "/" + basketItem.Amount + "/" + basketItem.Unit;
            var stockControl = _APIConnect.Get(url);
            if (stockControl.Result.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public void AddBasket(BasketDto basketItem)
        {
            BasketDto cashedBasketItem = _casheService.Get<BasketDto>(GetCasheKey(basketItem));
            if (cashedBasketItem != null)
            {
                //If cashe has a same product and unit, increase amount
                if (cashedBasketItem.ProductId.Equals(basketItem.ProductId) && cashedBasketItem.Unit.Equals(basketItem.Unit))
                {
                    cashedBasketItem.Amount += basketItem.Amount;
                    AddCashe(cashedBasketItem);
                }
                else
                    AddCashe(basketItem);
            }
            else
                AddCashe(basketItem);

        }
        private void AddCashe(BasketDto basketItem)
        {
            string key = GetCasheKey(basketItem);
            _casheService.Set<BasketDto>(key, basketItem);
        }

        private string GetCasheKey(BasketDto basketItem)
        {
            return basketItem.CustomerId.ToString();
        }

    }
}
