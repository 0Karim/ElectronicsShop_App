using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectronicShop.Domain.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        public string RoleName { get; set; }

        public bool IsActive { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
