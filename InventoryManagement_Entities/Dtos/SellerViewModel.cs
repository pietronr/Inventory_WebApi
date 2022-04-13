using System.Collections.Generic;

namespace InventoryManagement.Entities.Dtos
{
    public class SellerViewModel
    {
        public List<SellingOrderViewModel> SellingOrders { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<ProductViewModel> SoldProducts { get; set; }
    }
}
