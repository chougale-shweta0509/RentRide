using RentRideProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentRideProject.Repositories.Infrastructure
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetVehicles();

        Task<Vehicle> GetVehicleById(int id);

        Task InsertVehicle (Vehicle vehicle );

        Task UpdateVehicle(Vehicle vehicle);

        Task DeleteVehicle(int id);


    }
}
