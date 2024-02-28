using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SearchTransportApi.Business.Services;
using SearchTransportApi.DataAccess.Interfaces;
using SearchTransportApi.Models.DataAccessModels;

namespace TestSearchTransport.Business.Services
{
    [TestClass]
    public class VehicleServiceTest
    {
        #region Dependencies

        private Mock<IVehicleRepository> _vehicleRepositoryMock;
        private Mock<ILogger<VehicleService>> _loggerMock;

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void TestInitialize()
        {
            _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            _loggerMock = new Mock<ILogger<VehicleService>>();
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public async Task GetVehiclesByLocation()
        {
            #region Arrange

            string locationName = "location 1";
            string clientLocationName = "location 2";

            var expectedVehicles = new List<Vehicle> {
                new Vehicle
                {
                    VehicleId = 1,
                    VehicleName = "vehicle 1",
                    LocationId = 1
                }
            };

            _vehicleRepositoryMock.Setup(repo => repo.GetVehiclesByLocation(locationName, clientLocationName))
                        .Returns(Task.FromResult(new ActionResult<IEnumerable<Vehicle>>(new OkObjectResult(expectedVehicles))));

            var vehicleService = new VehicleService(_vehicleRepositoryMock.Object, _loggerMock.Object);

            #endregion

            #region Act

            var result = await vehicleService.GetVehiclesByLocation(locationName, clientLocationName);

            #endregion

            #region Assert

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult)); // validate OkObjectResult
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult?.Value); // validate OkObjectResult is not null
            Assert.IsInstanceOfType(okResult.Value, typeof(List<Vehicle>)); // validate response is a List<Vehicle>
            var vehicles = okResult.Value as List<Vehicle>;
            CollectionAssert.AreEqual(expectedVehicles, vehicles); // validate the response
            int count = vehicles!=null?vehicles.Count:0;
            Assert.AreEqual(count, 1); //validate size of list

            #endregion
        }

        #endregion
    }
}
