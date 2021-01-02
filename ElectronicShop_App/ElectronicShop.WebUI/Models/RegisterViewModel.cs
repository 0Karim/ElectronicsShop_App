using ElectronicShop.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShop.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "English Name")] //, ResourceType = typeof(Labels))]
        public string NameEn { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "Arabic Name")] //, ResourceType = typeof(Labels))]
        public string NameAr { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "Full Address")]//, ResourceType = typeof(Labels))]
        public string FullAddress { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "Email")] //, ResourceType = typeof(Labels))]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(Messages))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "Username")] //, ResourceType = typeof(Labels))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "Password")] //, ResourceType = typeof(Labels))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "Phone Number")] //, ResourceType = typeof(Labels))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "mobileNumber", ErrorMessageResourceType = typeof(Messages))]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "Birth Date")] //, ResourceType = typeof(Labels))]
        public DateTime BirthDate { get; set; }
    }
}
