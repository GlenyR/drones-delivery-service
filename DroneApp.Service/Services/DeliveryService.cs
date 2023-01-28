using System.Collections.Generic;
using System.Linq;
using DroneApp.Domain.DomainServices;
using DroneApp.Domain.DomainServices.Contracts;
using DroneApp.Domain.Entities;
using DroneApp.Service.IServices;

namespace DroneApp.Service.Services
{
    public class DeliveryService: IDeliveryService
    {
        private readonly IInstructionService _instructionService;
        private readonly ILocationPackagesService _packagesService;
        private readonly IDroneDeliveryService _dronesService;

        public DeliveryService(IInstructionService instructionService, ILocationPackagesService packagesService, IDroneDeliveryService dronesService)
        {
            _instructionService = instructionService;
            _packagesService = packagesService;
            _dronesService = dronesService;
        }

        /// <inheritdoc/>
        public List<Drone> GetDroneDeliveries(string inputs)
        {
   
            var (drones, locations) = _instructionService.ParseInstruction(inputs);

            getTripsByDrone(drones, locations);

            return drones;
        }

        /// <inheritdoc/>
        public void getTripsByDrone(List<Drone> drones, List<LocationPackage> locations)
        {

            _packagesService.SetPackages(locations);
            _dronesService.Drones = drones;

            while (_packagesService.PackagesWeight > 0)
            {
                var drone = _dronesService.GetNextDroneWithCapacity();
                if (drone != null)
                {
                    var packages = _packagesService.GetNextPackage(drone.AvailableCapacity).ToList();
                    drone.AddPackages(packages);

                    if (drones.Sum(p => p.Rank) == 0)
                    {
                        _dronesService.DeliverPackages();
                    }
                }
                else
                {
                    _dronesService.DeliverPackages();
                }
            }
            _dronesService.DeliverPackages();
        }
    }
}
