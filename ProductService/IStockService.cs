namespace ProductServices
{
    public interface IStockService
    {
        bool StockControl(long productId, decimal amount, int Unit);
    }
}
