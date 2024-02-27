using Microsoft.AspNetCore.Mvc;
using SearchTransportApi.Models.DataAccessModels;

namespace SearchTransportApi.DataAccess.Interfaces
{
    public interface IVehicleRepository
    {
        Task<ActionResult<IEnumerable<Vehicle>>> GetVehiclesByLocation(string locationName, string clientLocationName);
    }
}
