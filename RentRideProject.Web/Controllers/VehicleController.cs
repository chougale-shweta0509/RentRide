using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentRideProject.Web.Models.ViewModels.Vehicle;
using VehicleRentRideProject.Repositories.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using RentRideProject.Models;


namespace RentRideProject.Web.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        private IMapper _mapper;

        public VehicleController(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int pageNumber=1, int pageSize=10, string SearchingText=null)
        {
            IEnumerable<VehicleViewModel> viewModelList;
            var vehicles = _vehicleRepository
                            .GetVehicles().GetAwaiter().GetResult()
                           .Skip((pageNumber * pageSize) - pageSize).Take(pageSize);

            var viewModel = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicles);

            if (!String.IsNullOrEmpty(SearchingText))
            {
                /*viewModelList*/
                viewModelList = viewModel.Where(x => x.VehicleNumber.Equals(SearchingText));
            }
            var VehicleViewModel = new ListVehicleViewModel
            {
                VehicleList = viewModel,
                PageInfo = new Utility.PageInfo
                {
                    ItemsPerPage = pageSize,
                    CurrentPage = pageNumber,
                    TotalItems = _vehicleRepository.GetVehicles().GetAwaiter().GetResult().Count()
                },
            };

            return View();
    
        }
        
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicleViewModel vm)
        {
            var model = _mapper.Map<Vehicle>(vm);
            await _vehicleRepository.InsertVehicle(model);
            return RedirectToAction(nameof(Index));
            
        }

    }
}
