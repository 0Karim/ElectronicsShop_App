using ElectronicShop.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShop.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "Username", ResourceType = typeof(Labels))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Labels))]
        public string Password { get; set; }
    }

}
