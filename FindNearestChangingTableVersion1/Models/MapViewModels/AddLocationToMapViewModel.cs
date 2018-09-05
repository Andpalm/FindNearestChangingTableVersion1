using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindNearestChangingTableVersion1.Data;

namespace FindNearestChangingTableVersion1.Models.MapViewModels
{
    public class AddLocationToMapViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Hours { get; set; }
        public string Description { get; set; }
        public string LatLng { get; set; }

        internal static List<AddLocationToMapViewModel> GetAllLocations(NewHorizonsDBContext context)
        {
            var dbLocations = context.Markers
                .ToList();
            if (dbLocations != null)
            {
                List<AddLocationToMapViewModel> allLocations = new List<AddLocationToMapViewModel>();
                foreach (var location in dbLocations)
                {
                    allLocations.Add(new AddLocationToMapViewModel()
                    {
                        Name = location.Name,
                        Address = location.Adress,
                        Hours = location.Hours,
                        Description = location.Description,
                        LatLng = location.LatLng,
                    });
                }
                return allLocations;
            }
            else
                return null;
        }

        internal bool AddLocationToMap(NewHorizonsDBContext context)
        {
            bool result = true;

            Markers markers = new Markers()
            {
                UserID = UserId,
                Name = Name,
                Adress = Address,
                Hours = Hours,
                Description = Description,
                LatLng = LatLng,
            };

            try
            {
                context.Markers.Add(markers);
                context.SaveChanges();
            }
            catch 
            {
                result = false;
            }

            return result;
        }
    }
}
