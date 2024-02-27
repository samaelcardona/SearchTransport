namespace SearchTransportApi.Models.ApiModels
{
    public class RequestVehicleByLocation
    {
        public string LocationName { get; set; } = null!;

        public string ClientLocationName { get; set; } = null!;

        public RequestVehicleByLocation()
        {
            
        }

        public RequestVehicleByLocation(string locationName, string clientLocationName)
        {
            LocationName = locationName;
            ClientLocationName = clientLocationName;
        }
    }
}
