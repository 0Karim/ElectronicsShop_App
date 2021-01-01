using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElectronicShop.Domain.Entities
{
    public class OffersPerCustomer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int? CustomerId { get; set; }
        public User User { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public Product Product { get; set; }

        public decimal? Discount { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDiscountActive { get; set; }
    }
}
