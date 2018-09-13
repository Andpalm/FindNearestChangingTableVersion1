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
        public string Email { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }

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
        internal static bool RemoveAdmin(ApplicationDbContext context, AdminIndexViewModel model)
        {
            bool adminRemoved;
            var admin = context.Users.Where(a => a.Email == model.Email).FirstOrDefault();
            if (admin != null)
            {
                var adminStatus = context.UserRoles.Where(a => a.UserId == admin.Id).FirstOrDefault();
                if (adminStatus != null)
                {
                    context.Remove(adminStatus);
                    context.SaveChanges();
                    adminRemoved = true;
                }
                else
                    adminRemoved = false;
            }
            else
                adminRemoved = false;
            return adminRemoved;
        }
    }
}
