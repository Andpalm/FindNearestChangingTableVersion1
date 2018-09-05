using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindNearestChangingTableVersion1.Data;
using FindNearestChangingTableVersion1.Models;
using FindNearestChangingTableVersion1.Models.AdminViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FindNearestChangingTableVersion1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext context;
        private UserManager<ApplicationUser> userManager;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult AdminIndex()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminIndex(AdminIndexViewModel model)
        {
            bool correctModel = TryValidateModel(model);
            if (correctModel)
            {
                if (model != null)
                {
                    ApplicationUser user = await userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                        ViewData["Message"] = $"{model.Email} har tilldelats rollen som admin";
                        return View();
                    }
                    else
                    {
                        ViewData["Message"] = "Det finns ingen användare med den här emailen";
                        return View();
                    }
                }
                else
                {
                    ViewData["Message"] = "Något gick fel försök igen";
                    return View();
                }
            }
            else
                return View();
        }
    }
}