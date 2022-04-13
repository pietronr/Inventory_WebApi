using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Entities.Models
{
    public class SellingOrder : DbObject
    {
        public Seller Seller { get; set; }
        public int SellerId { get; set; }
        public List<Product> SoldProducts { get; set; }
        public List<ProductSellingOrder> ProductSellingOrders { get; set; }

        public double TotalValue => SoldProducts.Sum(x => x.Price);
    }
}
