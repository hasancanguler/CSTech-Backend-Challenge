using System.ComponentModel.DataAnnotations;

namespace ProductDAL
{
    //I assume that there is a table which  is stored the stock status
    public class StockBalance
    {
        [Key]
        public int Id { get; set; }
        public long ProductId { get; set; }
        public decimal Ammount { get; set; }
        public int Unit { get; set; }

    }
}
