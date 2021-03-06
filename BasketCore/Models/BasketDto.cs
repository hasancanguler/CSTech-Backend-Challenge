using System;
using System.Collections.Generic;
using System.Text;

namespace BasketCore.Models
{
    public class BasketDto
    {
        public int Id { get; set; }
        public long CustomerId { get; set; }
        public long ProductId { get; set; }
        public decimal Amount { get; set; }
        public int Unit { get; set; }
    }
}
