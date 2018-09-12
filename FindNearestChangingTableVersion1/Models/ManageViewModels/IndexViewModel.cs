using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindNearestChangingTableVersion1.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name ="Användarnamn")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name ="E-postadress")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
