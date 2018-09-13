using FindNearestChangingTableVersion1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindNearestChangingTableVersion1.Models.AdminViewModels
{
    public class HandleLocationViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string UserID { get; set; }
        public string Description { get; set; }
        public string Hours { get; set; }

        internal static List<HandleLocationViewModel> GetLocations(NewHorizonsDBContext contextNH, AdminIndexViewModel model)
        {
            List<HandleLocationViewModel> locationList = new List<HandleLocationViewModel>();
            
            if(model.Name != null)
            {
                var listDB = contextNH.Markers.Where(m => m.Name.Contains(model.Name)).ToList();
                if (listDB != null)
                {
                    foreach (var m in listDB)
                    {
                        locationList.Add(new HandleLocationViewModel()
                        {
                            ID = m.ID,
                            Name = m.Name,
                            Adress = m.Adress,
                            Hours = m.Hours,
                            Description = m.Description,
                            UserID = m.UserID
                        });
                        
                    }
                    return locationList;
                }
                else
                    return null;
            }
            if (model.UserID != null)
            {
                var listDB = contextNH.Markers.Where(m => m.UserID == model.UserID).ToList();
                if (listDB != null)
                {
                    foreach (var m in listDB)
                    {
                        locationList.Add(new HandleLocationViewModel()
                        {
                            ID = m.ID,
                            Name = m.Name,
                            Adress = m.Adress,
                            Hours = m.Hours,
                            Description = m.Description,
                            UserID = m.UserID
                        });
                        
                    }
                    return locationList;
                }
                else
                    return null;

            }
            else
                return null;
        }
        internal static bool DeleteMarker(NewHorizonsDBContext context, int locID)
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
        internal static bool UpdateMarker(NewHorizonsDBContext context, HandleLocationViewModel model)
        {
            bool locationUpdated;
            var location = context.Markers.Where(l => l.ID == model.ID).FirstOrDefault();
            if (location != null)
            {
                location.Name = model.Name;
                location.Hours = model.Hours;
                location.Adress = model.Adress;
                location.Description = model.Description;
                context.SaveChanges();
                locationUpdated = true;
            }
            else
                locationUpdated = false;
            return locationUpdated;
        }

    }
}
