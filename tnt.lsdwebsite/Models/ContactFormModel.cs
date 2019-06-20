using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tnt.lsdwebsite.Models
{
    public class ContactFormModel
    {
        [Required]
        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Business name")]
        public string businessName { get; set; }

        [Required]
        [Phone]
        [DisplayName("Phone number")]
        public string phoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Questions and inquiries")]
        [DataType(DataType.MultilineText)]
        public string message { get; set; }
    }
}
