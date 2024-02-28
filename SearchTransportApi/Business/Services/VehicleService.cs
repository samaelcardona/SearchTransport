using Microsoft.AspNetCore.Mvc;
using SearchTransportApi.Business.Interfaces;
using SearchTransportApi.DataAccess.Interfaces;
using SearchTransportApi.Models.DataAccessModels;

namespace SearchTransportApi.Business.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ILogger<VehicleService> _logger;

        public VehicleService(IVehicleRepository vehicleRepository, ILogger<VehicleService> logger)
        {
            _vehicleRepository = vehicleRepository;
            _logger = logger;
        }


        public Task<ActionResult<IEnumerable<Vehicle>>> GetVehiclesByLocation(string locationName, string clientLocationName) 
        {
            try
            {
                return _vehicleRepository.GetVehiclesByLocation(locationName, clientLocationName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error : {ex.Message}");
                throw new Exception($"Error : {ex.Message}");
            }

        }

    }
}
