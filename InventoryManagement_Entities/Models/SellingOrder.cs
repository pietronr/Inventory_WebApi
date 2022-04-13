using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement_Entities.Models
{
    public class SellingOrder : DbObject
    {
        public Seller Seller { get; set; }
        public int SellerId { get; set; }
        public List<Product> SoldProducts { get; set; }
        public double TotalValue => SoldProducts.Sum(x => x.Price);
    }
}
