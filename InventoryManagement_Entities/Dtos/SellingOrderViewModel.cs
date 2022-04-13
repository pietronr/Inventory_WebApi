using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement_Entities.Dtos
{
    public class SellingOrderViewModel
    {
        public int SellerId { get; set; }
        public List<ProductViewModel> SoldProducts { get; set; }
        public double TotalValue => SoldProducts.Sum(x => x.Price);
    }
}
