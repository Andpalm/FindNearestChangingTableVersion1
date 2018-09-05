using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindNearestChangingTableVersion1.Data;
using FindNearestChangingTableVersion1.Models;
using FindNearestChangingTableVersion1.Models.MapViewModels;
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
            List<AddLocationToMapViewModel> addLocations = AddLocationToMapViewModel.GetAllLocations(context);
            return View();
        }

        [HttpGet]
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
    }
}