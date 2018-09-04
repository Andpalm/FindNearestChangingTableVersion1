using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindNearestChangingTableVersion1.Data;
using Microsoft.AspNetCore.Mvc;

namespace FindNearestChangingTableVersion1.Controllers
{
    public class MapController : Controller
    {
        private NewHorizonsDBContext context;

        public MapController(NewHorizonsDBContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}