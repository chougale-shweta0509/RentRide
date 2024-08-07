using RentRideProject.Web.Utility;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RentRideProject.Web.Models.ViewModels.Vehicle
{
    public class ListVehicleViewModel
    {
        public IEnumerable<VehicleViewModel> VehicleList { get; set; }
        public PageInfo PageInfo { get; set; }

        public string SearchingText { get; set; }

    }
}
