using System.Collections.Generic;
using System.Linq;
using System.Text;
using DroneApp.Domain;
using DroneApp.Domain.Common;
using DroneApp.Domain.DomainServices;
using DroneApp.Domain.DomainServices.Contracts;
using DroneApp.Domain.Entities;
using DroneApp.Service.IServices;
using DroneApp.Service.Services;
using Xunit;

namespace DroneApp.Tests.DomainServices
{
    public class DroneDeliveryServiceTests
    {
        private IDroneDeliveryService _droneDeliveryService;

        public DroneDeliveryServiceTests()
        {
            _droneDeliveryService = new DroneDeliveryService();
        }

        [Fact]
        public void ShouldGetNextDroneWithCapacityAvailable()
        {
            //Arrange
            var drones = new List<Drone>();
            drones.Add(new Drone("A1", 150));
            drones.Add(new Drone("B1", 50));
            var droneC = new Drone("C1", 500);
            var packageLocation = new LocationPackage("L1", 10);
            var locations = new List<LocationPackage>();
            locations.Add(packageLocation);
            droneC.AddPackages(locations);
            drones.Add(droneC);
            drones.Add(new Drone("D1", 80));
            _droneDeliveryService.Drones = drones;

            //Act
            var drone = _droneDeliveryService.GetNextDroneWithCapacity();

            //Asert
            Assert.Equal("B1", drone.Name);
        }

        [Fact]
        public void ShouldDeliverPackagesForTripsOpen()
        {
            //Arrange
            var drones = new List<Drone>();
            drones.Add(new Drone("A1", 150));
            drones.Add(new Drone("B1", 50));
            var droneC = new Drone("C1", 500);
            var packageLocation = new LocationPackage("L1", 10);
            var locations = new List<LocationPackage>();
            locations.Add(packageLocation);
            droneC.AddPackages(locations);
            drones.Add(droneC);
            drones.Add(new Drone("D1", 80));
            _droneDeliveryService.Drones = drones;

            //Act
            _droneDeliveryService.DeliverPackages();

            //Asert
            var dronesWithTripDelivered = _droneDeliveryService.Drones.Where(d => d.Trips.Where(t => t.Status == StringConstants.Delivered && t.Locations.Count() > 0).Count() > 0).ToList();
            Assert.Single(dronesWithTripDelivered);
        }


    }
}
