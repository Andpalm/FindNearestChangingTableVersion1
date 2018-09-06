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

        internal static List<EditLocationViewModel> DisplayList(NewHorizonsDBContext context)
        {
            List<EditLocationViewModel> list = new List<EditLocationViewModel>();
            return list;
        }
    }
}
