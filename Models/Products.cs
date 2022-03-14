using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Products
    {
        public int Id { get; set; } 
        public string ProductName { get; set; }

        public string CurrencySymbol { get; set; } = "£";

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
    }
}
