using FindNearestChangingTableVersion1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindNearestChangingTableVersion1.Models.UserViewModels
{
    public class EditLocationViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string UserID { get; set; }
        public string Description { get; set; }
        public string Hours { get; set; }
        public string LatLng { get; set; }

        internal static List<EditLocationViewModel> DisplayList(NewHorizonsDBContext context, string userID)
        {
            var list = context.Markers.Where(l => l.UserID == userID).ToList();
            if (list.Count > 0)
            {
                List<EditLocationViewModel> locationList = new List<EditLocationViewModel>();
                foreach (var l in list)
                {
                    locationList.Add(new EditLocationViewModel()
                    {
                        ID = l.ID,
                        Name = l.Name,
                        Adress = l.Adress,
                        UserID = l.UserID,
                        Description = l.Description,
                        Hours = l.Hours,
                        LatLng = l.LatLng
                    });
                }
                return locationList;
            }
            return null;
        }
        internal static bool DeleteMarker (NewHorizonsDBContext context, int locID)
        {
            bool locationDeleted;
            var location = context.Markers.Where(l => l.ID == locID).FirstOrDefault();
            if (location != null)
            {
                context.Remove(location);
                context.SaveChanges();
                locationDeleted = true;
            }
            else
                locationDeleted = false;
            return locationDeleted;
        }
    }
}
