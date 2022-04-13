using System.Collections.Generic;

namespace InventoryManagement_Entities.Dtos
{
    public class SellerViewModel
    {
        public List<SellingOrderViewModel> SellingOrders { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<ProductViewModel> SoldProducts { get; set; }
    }
}
