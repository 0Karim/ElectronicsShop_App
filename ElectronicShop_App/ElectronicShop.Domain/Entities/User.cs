using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElectronicShop.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string NameEn { get; set; }

        public string NameAr { get; set; }

        public string FullAddress { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("Role")]
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
