using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShop.WebUI.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string NameEn { get; set; }

        public string NameAr { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        public string CategoryNameEn { get; set; }
        public string CategoryNameAr { get; set; }
    }
}
