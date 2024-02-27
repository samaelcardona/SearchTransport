using Microsoft.AspNetCore.Mvc;
using SearchTransportApi.Models.DataAccessModels;

namespace SearchTransportApi.Business.Interfaces
{
    public interface IVehicleService
    {
        Task<ActionResult<IEnumerable<Vehicle>>> GetVehiclesByLocation(string locationName, string clientLocationName);
    }
}
