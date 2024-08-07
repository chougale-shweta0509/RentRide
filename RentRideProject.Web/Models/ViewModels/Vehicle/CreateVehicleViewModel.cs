﻿namespace RentRideProject.Web.Models.ViewModels.Vehicle
{
    public class CreateVehicleViewModel
    {
       public int Id { get; set; }

        public string VehicleName { get; set; }

        public string VehicleType { get; set; }

        public string VehicleModel { get; set; }

        public string VehicleNumber { get; set; }

        public string VehicleColor { get; set; }

        public string VehicleDescription { get; set; }

        public string VehicleImage { get; set; }

        public IFormFile VehicleImageUrl { get; set; }

        public decimal  VehiclePrice { get; set; }

        public bool IsAvailable { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
