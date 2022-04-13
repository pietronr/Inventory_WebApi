using System.Collections.Generic;

namespace InventoryManagement_Entities.Models
{
    public  class Seller : DbObject
    {
        public List<SellingOrder> SellingOrders { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Product> SoldProducts { get; set; }
    }
}
