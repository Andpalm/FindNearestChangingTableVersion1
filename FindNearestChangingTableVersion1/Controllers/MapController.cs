using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindNearestChangingTableVersion1.Data;
using FindNearestChangingTableVersion1.Models;
using FindNearestChangingTableVersion1.Models.MapViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FindNearestChangingTableVersion1.Controllers
{
    public class MapController : Controller
    {
        private NewHorizonsDBContext context;
        private readonly UserManager<ApplicationUser> userManager;


        public MapController(NewHorizonsDBContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Map/GetAllLocations")]
        public JsonResult GetAllLocations()
        {
            List<AddLocationToMapViewModel> allLocations = AddLocationToMapViewModel.GetAllLocations(context);
            return new JsonResult(allLocations);
        }

        [HttpGet]
        [Authorize]
        [Route("Map/AddLocationToMap/{name}/{address}/{hours}/{description}/{latlng}")]
        public bool AddLocationToMap(string name, string address, string hours, string description, string latlng)
        {
            string userId = userManager.GetUserId(User);
            AddLocationToMapViewModel newLocation = new AddLocationToMapViewModel()
            {
                UserId = userId,
                Name = name,
                Address = address,
                Hours = hours,
                Description = description,
                LatLng = latlng,
            };

            return newLocation.AddLocationToMap(context);
        }

        [HttpGet]
        [Route("Map/NearestLocations")]
        public IActionResult NearestLocations()
        {
            return View();
        }

        [HttpGet]
        [Route("Map/FindNearestLocations")]
        public JsonResult FindNearestLocations()
        {
            List<AddLocationToMapViewModel> allLocations = AddLocationToMapViewModel.GetAllLocations(context);
            return new JsonResult(allLocations);
        }

        [HttpGet]
        [Route("Map/ShowNearestLocation/{name}/{address}/{hours}/{description}/{position}")]
        public IActionResult ShowNearestLocation(string name, string address, string hours, string description, string position)
        {
            AddLocationToMapViewModel nearestLocation = new AddLocationToMapViewModel()
            {
                Name = name,
                Address = address,
                Hours = hours,
                Description = description,
                LatLng = position,
            };
            return View(nearestLocation);
        }

    }
}