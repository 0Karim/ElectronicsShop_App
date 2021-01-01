using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectronicShop.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string NameEn { get; set; }

        public string NameAr { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
