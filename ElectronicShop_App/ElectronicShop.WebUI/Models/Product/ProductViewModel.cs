using ElectronicShop.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShop.WebUI.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        public string NameEn { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        public string NameAr { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "NumbersOnly", ErrorMessageResourceType = typeof(Messages))]
        public decimal Price { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "NumbersOnly", ErrorMessageResourceType = typeof(Messages))]
        public int Quantity { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Range(1 , 10 , ErrorMessage ="Choose Category")]
        public int CategoryId { get; set; }

        public string CategoryNameEn { get; set; }
        public string CategoryNameAr { get; set; }
    }
}
