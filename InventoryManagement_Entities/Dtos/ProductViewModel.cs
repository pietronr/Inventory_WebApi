using System.Collections.Generic;

namespace InventoryManagement.Entities.Dtos
{
    public class ProductViewModel : DbObject
    {
        public List<SellingOrderViewModel> SellingOrders { get; set; }
        public int SellerId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

    }

    public enum Category
    {
        Clothes = 0,
        Accessories = 1,
        Footwear = 2,
        Headwear = 3
    }
}
