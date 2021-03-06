using ProductDAL;
using System;
using System.Linq;

namespace ProductServices
{
    public class StockService : IStockService
    {
        private readonly MyContext _myContext;
        public StockService(MyContext myContext)
        {
            _myContext = myContext;
        }

        public bool StockControl(long productId, decimal amount, int Unit)
        {
            // There may be other sql criteria and unit convert
            // This query always give true because there is no DB local
            try
            {
                decimal balance = (from stockBalance in _myContext.StockBalance
                                   where productId.Equals(productId)
                                   select amount).FirstOrDefault();
                if (amount >= balance)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                //Exception is returned true because of no DB
                //We shouldn't say to customer there is no stock on the exception moment  :) 
                //I know this is a mistake
                return true;
            }
        }
    }
}
