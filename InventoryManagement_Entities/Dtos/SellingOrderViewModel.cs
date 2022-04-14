using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Entities.Dtos
{
    public class SellingOrderViewModel : DbObject
    {
        public int SellerId { get; set; }
        public List<ProductViewModel> SoldProducts { get; set; }
        public double TotalValue => SoldProducts.Sum(x => x.Price);
    }
}
