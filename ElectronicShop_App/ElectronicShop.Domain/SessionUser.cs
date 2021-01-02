using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicShop.Domain
{
    public class SessionUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FullNameAr { get; set; }

        public string FullNameEn { get; set; }

        public string Role { get; set; }

        public int RoleId { get; set; }
    }
}
