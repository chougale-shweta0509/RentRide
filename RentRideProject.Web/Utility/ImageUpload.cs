namespace RentRideProject.Web.Utility
{
    public class ImageUpload
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageUpload (IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;


            //CreateMap<Vehicle, VehicleViewModel>();
            //CreateMap<CreateVehicleViewModel, VehicleViewModel>()
            //    .ForMember(dest => dest.VehicleImage,
            //     opt => opt.MapFrom(src => SaveImageFile(src.VehicleImageUrl)));

        }

        public string SaveImageFile(IFormFile vehicleImageUrl)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string uploadPath = Path.Combine(webRootPath, "upload");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            //if (vehicleImageUrl == null || vehicleImageUrl.Length == 0)
            //  return null;

            //Generate a unique file name using Guid
            string fileName = Guid.NewGuid().ToString() +
                Path.GetExtension(vehicleImageUrl.FileName);

            //Set the filder path where you want to save the image file
            string filePath = Path.Combine(uploadPath, fileName);

            using (var fileStream = new FileStream(filePath,
                FileMode.Create))
            {
                vehicleImageUrl.CopyTo(fileStream);
            }

            return Path.Combine("upload", fileName);
        }
    }
}
