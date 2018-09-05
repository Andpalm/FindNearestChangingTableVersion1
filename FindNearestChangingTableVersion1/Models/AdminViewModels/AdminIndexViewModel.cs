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

        private UserManager<ApplicationUser> userManager;

        public AdminIndexViewModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        internal async Task<string> AddAdmin(ApplicationDbContext context, AdminIndexViewModel model)
        {
            if (context != null && model != null)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(model.Email);
                var User = new ApplicationUser();
                await userManager.AddToRoleAsync(user, "Admin");
            }
            return "";
        }
    }
}
