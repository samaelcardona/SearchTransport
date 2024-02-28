using Microsoft.AspNetCore.Mvc;
using SearchTransportApi.Business.Interfaces;
using SearchTransportApi.Business.Services;
using SearchTransportApi.Models.ApiModels;
using SearchTransportApi.Models.DataAccessModels;

namespace SearchTransportApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly ILogger<VehicleService> _logger;

        public VehiclesController(IVehicleService vehicleService, ILogger<VehicleService> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }

        /// <summary>
        /// Get vehicles by location.
        /// </summary>
        /// <remarks>
        /// Request example:
        ///
        ///     PUT api/Vehicles
        ///     {
        ///         "LocationName": "locacion 1",
        ///         "ClientLocationName": "locacion 2"
        ///     }
        ///
        /// </remarks>
        /// <param name="LocationName">LocationName</param>
        /// <param name="ClientLocationName">ClientLocationName</param>
        /// <returns>Vehicles</returns>
        [HttpPut]
        public  ActionResult<IEnumerable<Vehicle>> GetVehiclesByLocation(RequestVehicleByLocation request)
        {
            try
            {
                if (request == null)
                {
                    _logger.LogError($"Error bad request");
                    return BadRequest();
                }

                return Ok(new { Message = "Request ok", Data = _vehicleService.GetVehiclesByLocation(request.LocationName, request.ClientLocationName)}); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error : {ex.Message}");
                return NotFound();
            }
        }
    }
}
