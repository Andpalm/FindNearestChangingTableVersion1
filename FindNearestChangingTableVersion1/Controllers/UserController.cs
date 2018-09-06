using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindNearestChangingTableVersion1.Data;
using FindNearestChangingTableVersion1.Models;
using FindNearestChangingTableVersion1.Models.UserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FindNearestChangingTableVersion1.Controllers
{
    public class UserController : Controller
    {
        private NewHorizonsDBContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(NewHorizonsDBContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public IActionResult EditLocation()
        {
            List<EditLocationViewModel> locationList = EditLocationViewModel.DisplayList(context); 
            return View();
        }
    }
}