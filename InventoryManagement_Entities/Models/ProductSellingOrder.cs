using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Entities.Models
{
    public class ProductSellingOrder 
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public SellingOrder SellingOrder { get; set; }
        public int SellingOrderId { get; set; }
        public int SoldAmount { get; set; }
    }
}
