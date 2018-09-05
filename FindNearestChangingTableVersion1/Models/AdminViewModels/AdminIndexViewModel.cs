using FindNearestChangingTableVersion1.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindNearestChangingTableVersion1.Models.AdminViewModels
{
    public class AdminIndexViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Du måste email på användaren som ska tilldelas Admin rättigheter")]
        public string Email { get; set; }

        public AdminIndexViewModel()
        {
        }

        private UserManager<ApplicationUser> userManager;
        public AdminIndexViewModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
    }
}
