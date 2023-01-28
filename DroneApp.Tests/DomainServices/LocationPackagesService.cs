using DroneApp.Domain.DomainServices.Contracts;
using DroneApp.Domain.DomainServices;
using Xunit;
using DroneApp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DroneApp.Tests.DomainServices
{
    public class LocationPackagesServiceTests
    {
        private ILocationPackagesService _locationPackagesService;

        public LocationPackagesServiceTests()
        {
            _locationPackagesService = new LocationPackagesService();
        }

        [Fact]
        public void ShouldGetOneNextPackage()
        {
            //Arrange
            var packages = new List<LocationPackage>();
            packages.Add(new LocationPackage("L1", 80));
            packages.Add(new LocationPackage("L2", 110));
            packages.Add(new LocationPackage("L3", 200));
            _locationPackagesService.SetPackages(packages);

            //Act
            var availableCapacity = 100;
            var result = _locationPackagesService.GetNextPackage(availableCapacity);

            //Assert
            Assert.True(result.Count == 1);
            Assert.True(result[0].Weight <= availableCapacity);
        }

        [Fact]
        public void ShouldGetAllNextPackages()
        {
            //Arrange
            var packages = new List<LocationPackage>();
            packages.Add(new LocationPackage("L1", 80));
            packages.Add(new LocationPackage("L2", 100));
            packages.Add(new LocationPackage("L3", 5));
            _locationPackagesService.SetPackages(packages);

            //Act
            var availableCapacity = 200;
            var result = _locationPackagesService.GetNextPackage(availableCapacity);

            //Assert
            Assert.True(result.Count == 3);
            Assert.True(result.Sum(r => r.Weight) <= availableCapacity);
        }
    }
}
