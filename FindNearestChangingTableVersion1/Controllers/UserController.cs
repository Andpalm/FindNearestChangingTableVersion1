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
        [HttpGet]
        public IActionResult EditLocation()
        {
            string userID = userManager.GetUserId(User);
            List<EditLocationViewModel> locationList = EditLocationViewModel.DisplayList(context, userID);
            if (locationList == null)
                ViewData["Message"] = "Du har inte lagt till några locations";
            return View(locationList);
        }
        [Route("User/Delete/{id}")]
        [HttpGet]
        public JsonResult Delete(int id)
        {
            bool locationDeleted = EditLocationViewModel.DeleteMarker(context, id);
            return new JsonResult(locationDeleted);
        }
    }
}