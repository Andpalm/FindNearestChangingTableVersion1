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
        internal static bool DeleteUser(ApplicationDbContext context, AdminIndexViewModel model)
        {
            bool userDeleted;
            var user = context.Users.Where(l => l.Email == model.Email).FirstOrDefault();
            if (user != null)
            {
                context.Remove(user);
                context.SaveChanges();
                userDeleted = true;
            }
            else
                userDeleted = false;
            return userDeleted;
        }
    }
}
