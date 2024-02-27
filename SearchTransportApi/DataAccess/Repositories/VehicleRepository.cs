using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SearchTransportApi.DataAccess.Context;
using SearchTransportApi.DataAccess.Interfaces;
using SearchTransportApi.Models.DataAccessModels;

namespace SearchTransportApi.DataAccess.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly SearchTransportContext _context;
        private readonly ILogger<VehicleRepository> _logger;
        public VehicleRepository(SearchTransportContext context, ILogger<VehicleRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehiclesByLocation(string locationName, string clientLocationName)
        {
            try
            {
                //var locationId = _context.Locations.Where(l => l.LocationName.Equals(locationName))
                //                                    .Select(l => l.LocationId).FirstOrDefault();

                var vehicles = await _context.Vehicles.Where(v => v.Location.LocationName.Equals(locationName) || v.Location.LocationName.Equals(clientLocationName)).ToListAsync();
                _logger.LogInformation("GetVehiclesByLocation succesfull");
                return vehicles != null ? vehicles : new List<Vehicle>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error : {ex.Message}");
                throw new Exception($"Error : {ex.Message}") ;
            }
                
            
        }


    }
}
