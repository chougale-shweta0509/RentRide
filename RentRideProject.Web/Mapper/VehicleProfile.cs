using AutoMapper;
using RentRideProject.Models;
using RentRideProject.Web.Models.ViewModels.Vehicle;
using RentRideProject.Web.Utility;

namespace RentRideProject.Web.Mapper
{
    public class VehicleProfile : Profile
    {

        private IWebHostEnvironment _WebHostEnvironment;

        public VehicleProfile(IWebHostEnvironment webHostEnvironment)
        {
            _WebHostEnvironment = webHostEnvironment;

            CreateMap<Vehicle, VehicleViewModel>();
            CreateMap<CreateVehicleViewModel, VehicleViewModel>()
                .ForMember(dest => dest.VehicleImage,
                 opt => opt.MapFrom(src => new ImageUpload(_WebHostEnvironment).SaveImageFile(src.VehicleImageUrl)));

        }
       

        
    }
}


