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
                ViewData["Message"] = "Du har inte lagt till några skötbord";
            return View(locationList);
        }
        [Route("User/Delete/{id}")]
        [HttpGet]
        public JsonResult Delete(int id)
        {
            bool locationDeleted = EditLocationViewModel.DeleteMarker(context, id);
            return new JsonResult(locationDeleted);
        }
        [Route("User/Update/{locID}/{newName}/{newAdress}/{newHours}/{newDescription}")]
        [HttpGet]
        public JsonResult Update(int locID, string newName, string newAdress, string newHours, string newDescription)
        {
            EditLocationViewModel model = new EditLocationViewModel()
            { ID = locID, Name = newName, Adress = newAdress, Hours = newHours, Description = newDescription};
            bool locationUpdated = EditLocationViewModel.UpdateMarker(context, model);

            return new JsonResult(locationUpdated);
        }
    }
}