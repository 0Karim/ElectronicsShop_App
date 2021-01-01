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

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
