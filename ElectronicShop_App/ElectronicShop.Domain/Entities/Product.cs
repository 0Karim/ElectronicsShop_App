using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElectronicShop.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string NameEn { get; set; }

        public string NameAr { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
